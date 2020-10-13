using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Diagnostics;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Drawing.Text;
using log4net;
using System.Linq.Expressions;
using System.Windows.Forms.VisualStyles;

namespace Comunicatore
{
    public partial class Form1 : Form
    {

        private delegate void tscriptDelegate(string text);
        private tscriptDelegate delgato;

        public DbTestContext db;

        ILog log;

        public Form1()
        {
            
            Globali.InAvvio = true;
            InitializeComponent();

            Globali.Mainform = this;
            Globali.dblocation = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);

            Globali.Invio = new InvioTest();

            log = log4net.LogManager.GetLogger("Main");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(@"Configurazione\Log.xml"));

            log.Debug("Avvio" + '\r');

            try
            {

                db = new DbTestContext();
                //MessageBox.Show(db.Database.Connection.ConnectionString);
                db.Tests.Load();

                this.dataGridView1.DataSource = db.Tests.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                log.Debug(ex);
            }

            delgato = new tscriptDelegate(rtxtLog_AggiungiRiga);

            //Assegnazione valori ai controlli
            chkAbilitaFile1.Checked = Properties.Settings.Default.File1Abilitato;
            if (Properties.Settings.Default.File1 != "")
            {
                tabControlForm1.TabPages[1].Text = Path.GetFileName(Properties.Settings.Default.File1);
                txtFile1.Text = Properties.Settings.Default.File1;

            }
            chkAbilitaFile2.Checked = Properties.Settings.Default.File2Abilitato;
            if (Properties.Settings.Default.File2 != "")
            {
                tabControlForm1.TabPages[2].Text = Path.GetFileName(Properties.Settings.Default.File2);
                txtFile2.Text = Properties.Settings.Default.File2;

            }


            Globali.InAvvio = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Info("btn carica");
            //CSVContext context = new CSVContext();
            //context.Configuration.UseDatabaseNullSemantics = true;
            //var query = from line in context.P18504_Test select line;
            MessageBox.Show(db.Database.Connection.ConnectionString.ToString());
        }


        void ImportaFileCsv(string filename)
        {

            //string filename;
            //filename = "CSVdiEsempio\\P18504_TEST PVC.CSV";
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                log.Info("Importazione file " + Properties.Settings.Default.File1 + '\r');

                //acquisizione riga per riga del csv, controllo esistenza del id di prova ed eventuale inserimento nel tabase
                //TODO se possibile leggere all'indietro -- non è possibile
                //TODO prescartare le righe in basa alla data, p.e. in base ad un numero massimo di giorni all'indietro
                csv.Configuration.Delimiter = ";";


                try
                {
                    var righe = csv.GetRecords<ClasseCsv>();

                    try
                    {
                        foreach (ClasseCsv riga in righe)
                        {

                            //verifica data
                            //
                            //
                            //
                            bool filtra = Properties.Settings.Default.filtragiorni;
                            if (filtra)
                            {
                                //se la data è filtrata si passa la prossimo record
                                continue;
                            }


                            Guid guiddipasso = riga.guidGuiddiPassoDiProva;
                            Guid guiddiprova = riga.guidGuiddiProva;
                            //guid = Guid.Parse(riga.guidGuiddiPasso);

                            //verifica esistenza del guid prova nel database?

                            try
                            {
                                var count = db.Tests.Where(o => (o.GuidProva == riga.guidGuiddiProva) & (o.GuidPassoProva == riga.guidGuiddiPassoDiProva)).Count();

                                if (count == 0)
                                {
                                    //inserimento del dato nel db
                                    Test prova = new Test();
                                    prova.GuidProva = riga.guidGuiddiProva;
                                    prova.GuidPassoProva = riga.guidGuiddiPassoDiProva;
                                    prova.passo = riga.passo;
                                    prova.metodo = riga.metodo;
                                    prova.Orario = riga.Orario;
                                    prova.esitototale = riga.esitototale;
                                    prova.esitopasso = riga.esitopasso;
                                    prova.valore1 = riga.valore1;
                                    prova.valore1unitàdimisura = riga.valore1unitàdimisura;
                                    prova.valore2 = riga.valore2;
                                    prova.valore2unitàdimisura = riga.valore2unitàdimisura;
                                    prova.metodo = riga.metodo;
                                    prova.numerodiserie = riga.numerodiserie;
                                    prova.numeroprogetto = riga.numeroprogetto;
                                    prova.numeroprova = riga.contatoreprova;
                                    prova.nomecsv = Path.GetFileNameWithoutExtension(filename);
                                    prova.trasferito = false;

                                    db.Tests.Add(prova);
                                }
                            }



                            catch (Exception ex)
                            {
                                log.Debug(ex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Debug("errore importaione csv");
                        log.Debug(ex);
                    }
                    db.SaveChanges();


                }
                catch (Exception ex)
                {
                    log.Debug("Errore apertura file csv");
                    log.Debug(ex);
                }

            }
        }

        void InviaTest(string filename)
        {
            //cerca un test non inviato
            var count = db.Tests.Where(o => (o.trasferito != true)).Count();
            if (count == 0)
            {
                log.Info("Nessun nuovo test trovato");
                return;
            }

            //recupero il primo guid valido
            var guid = db.Tests.Where(o => (o.trasferito != true & o.errore != true)).Select(o => o.GuidProva).First();
            log.Info($"Test trovato: GUID {guid}");

            //verifica presenza di tutte le componenti
            var prove = db.Tests.Where(o => o.GuidProva == guid);
            if (prove == null) return;   //non dovrebbe capitare

            var ok1 = prove.Where(o => o.metodo == "HVAC").Count();
            var ok2 = prove.Where(o => o.metodo == "ISO").Count();

            if (!(ok1 ==1  & ok2 == 1))
                {
                //i due test non sono presenti - marcahre il test cone fallato/inviato;
                log.Info($"Test incompleto - tutte le voci sono contrassegato come invalido (guid {guid})");
                foreach (Test prova in prove)
                {
                    prova.errore = true;
                }
                db.SaveChanges();
                return;
            }

            //estrazione dati da inviare
            string serialnumber ="";
            string idmacchina ="";
            string programma = "";
            string esito = "";
            string correnterigidità = "";
            string tensionerigidità = "";
            string restistenzaisolamento = "";
            string tensioneisolamento = "";

            foreach (Test prova in prove)
            {
                if (prova.metodo == "ISO")
                {
                    serialnumber = prova.numeroprogetto.ToString() + prova.numerodiserie.ToString();
                    idmacchina = prova.numeroprogetto.ToString();
                    programma = Path.GetFileNameWithoutExtension(filename);
                    esito = prova.esitototale;
                    tensioneisolamento = prova.valore1;
                    restistenzaisolamento = prova.valore2;
                }
                if (prova.metodo == "HVAC")
                {
                    tensionerigidità = prova.valore1;
                    correnterigidità = prova.valore2;
                }
            }

            //invio dati
            try
            {
                Globali.Invio.Invio(serialnumber, idmacchina, programma, esito, correnterigidità, tensionerigidità, restistenzaisolamento,tensioneisolamento);
                //invio con successo segno come trasferiti;
                foreach (Test prova in prove)
                {
                    prova.serialegenerato = serialnumber;
                    prova.trasferito = true;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Debug("errore invio dati");
                log.Debug(ex);
                //segnare come invalido;
                foreach (Test prova in prove)
                {
                    prova.errore = true;

                }
                db.SaveChanges();
            }

            //in caso di errore generale segnare le voci relative come invalide se individuabili
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormInfo frm = new FormInfo();
            frm.ShowDialog();
        }

        public void rtxtLog_AggiungiRiga(string text)
        {
            const int ShrinkTo = 200;
            const int ShrinkTrigger = 250;
            string[] righe = null;


            if (InvokeRequired)
            {
                Invoke(delgato, text);
            }

            if (textBox.Lines.Length > ShrinkTrigger)
            {
                Array.Resize(ref righe, ShrinkTo);

                Array.Copy(textBox.Lines, textBox.Lines.Length - ShrinkTo - 1, righe, 0, ShrinkTo);
                textBox.Lines = righe;

            }

            textBox.AppendText(text);
        }



        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            String File1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File1 = openFileDialog1.FileName;
                txtFile1.Text = File1;
                btnSalvaFile1.Enabled = true;
                btnAnnullaFile1.Enabled = true;

            }
        }

        private void btnSalvaFile1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.File1 = txtFile1.Text;
            tabControlForm1.TabPages[1].Text = Path.GetFileName(txtFile1.Text);
            btnSalvaFile1.Enabled = false;
            btnAnnullaFile1.Enabled = false;
            Properties.Settings.Default.Save();
        }

        private void btnAnnullaFile1_Click(object sender, EventArgs e)
        {
            txtFile1.Text = Properties.Settings.Default.File1;
            btnSalvaFile1.Enabled = false;
            btnAnnullaFile1.Enabled = false;
        }


        private void chkAbilitaFile1_CheckedChanged(object sender, EventArgs e)
        {
            if (!Globali.InAvvio)
            {
                Properties.Settings.Default.File1Abilitato = chkAbilitaFile1.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                InviaTest(Properties.Settings.Default.File1);
            }
            catch (Exception ex)
            {
                log.Debug("Errore Invio Test");
                log.Debug(ex);
            }
        }

        //carica file
        private void button2_Click(object sender, EventArgs e)
        {
            //verifica nome file estinte, abilitazione ok e file esistente.

            if (!(Properties.Settings.Default.File1Abilitato))
            {
                log.Info("File1 non abilitato");
                return;
            }


            if (!(Properties.Settings.Default.File1 != ""))
            {
                log.Info("File1 non configurato");
                return;
            }
            if (!(File.Exists(Properties.Settings.Default.File1)))
            {
                log.Error("File '" + Properties.Settings.Default.File1 + "' non trovato");
                return;
            }

            //chiamata caricamento file
            ImportaFileCsv(Properties.Settings.Default.File1);
        }

        private void chkAbilitaFile2_CheckedChanged(object sender, EventArgs e)
        {
            if (!Globali.InAvvio)
            {
                Properties.Settings.Default.File2Abilitato = chkAbilitaFile2.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void btnSelectFile2_Click(object sender, EventArgs e)
        {
            String File2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File2 = openFileDialog1.FileName;
                txtFile2.Text = File2;
                btnSalvaFile2.Enabled = true;
                btnAnnullaFile2.Enabled = true;
            }
        }

        private void btnSalvaFile2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.File2 = txtFile2.Text;
            tabControlForm1.TabPages[2].Text = Path.GetFileName(txtFile2.Text);
            btnSalvaFile2.Enabled = false;
            btnAnnullaFile2.Enabled = false;
            Properties.Settings.Default.Save();
        }

        private void btnAnnullaFile2_Click(object sender, EventArgs e)
        {
            txtFile2.Text = Properties.Settings.Default.File2;
            btnSalvaFile2.Enabled = false;
            btnAnnullaFile2.Enabled = false;
        }

        private void tabControlForm1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (btnAnnullaFile1.Enabled | btnAnnullaFile2.Enabled)
            {
                MessageBox.Show("Salvare o Annullare");
                e.Cancel = true;
                    
            }
        }
    }





    public class TestOld
    {
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public Guid GuidProva { get; set; }

        [System.ComponentModel.DataAnnotations.Key, Column(Order = 1)]
        public Guid GuidPassoProva { get; set; }

        public string metodo { get; set; }

        public int chiavedimetodo { get; set; }

        public int passo { get; set; }

        public DateTime Orario { get; set; }

        public string esitopasso { get; set; }

        public int chiaveesitopasso { get; set; }

        public string esitototale { get; set; }

        public int chiavesitototale { get; set; }

        public float valore1 { get; set; }

        public string valore1unitàdimisura { get; set; }

        public float valore2 { get; set; }

        public string valore2unitàdimisura { get; set; }

        public int numerodiserie { get; set; }

        public int numeroprogetto { get; set; }

        public string barcode { get; set; }

        public int numeroprova { get; set; }

        public string nomecsv { get; set; }

        public bool trasferito { get; set; }
    }
}
