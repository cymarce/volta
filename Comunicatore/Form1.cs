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
using System.Security.Policy;
using System.Text.RegularExpressions;

// TODO: aggiungere una modalità per andare all'inditro al max di tot giorni durante la ricerca di un test non inviato

// TODO: pulsante aggiorna per la tabella e possibilità di filtrare i recrod recuperati 


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

            //binding della griglia
            try
            {


                db = new DbTestContext();

                //db.Tests.Load();
                //dataGridView1.DataSource = db.Tests.Local.ToBindingList();
                var query = db.Tests.OrderByDescending(o => o.Orario).Where(o  => o.trasferito == true).Take(1000);
                var ultimitestimportati = query.ToList();
                dataGridView1.DataSource = ultimitestimportati;
            }
            catch
            {
                MessageBox.Show("Database non presente");
                Globali.InArresto = true;
                Load += (s, e) => Close();
                return;

                //TODO: dialogbox più uscita?
            }

            delgato = new tscriptDelegate(rtxtLog_AggiungiRiga);

            //Assegnazione valori ai controlli
            chkAbilitaFile1.Checked = Properties.Settings.Default.File1Abilitato;
            log.Debug("File1Abilitato: " + Properties.Settings.Default.File1Abilitato);
            if (Properties.Settings.Default.File1 != "")
            {
                tabControlForm1.TabPages[1].Text = Path.GetFileName(Properties.Settings.Default.File1);
                txtFile1.Text = Properties.Settings.Default.File1;
            }
            chkAbilitaFile2.Checked = Properties.Settings.Default.File2Abilitato;
            log.Debug("File2Abilitato: " + Properties.Settings.Default.File2Abilitato);
            if (Properties.Settings.Default.File2 != "")
            {
                tabControlForm1.TabPages[2].Text = Path.GetFileName(Properties.Settings.Default.File2);
                txtFile2.Text = Properties.Settings.Default.File2;

            }

            chkMonitoraggioAutomatico.Checked = Properties.Settings.Default.MonitoraggioFile;
            log.Debug("Monitoraggio file abilitato: " + Properties.Settings.Default.MonitoraggioFile);
            chkInoltroAutomatico.Checked = Properties.Settings.Default.InvioAutomatico;
            log.Debug("Invio sutomatico ablilitato: " + Properties.Settings.Default.InvioAutomatico);

            Globali.InAvvio = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrAttivitàIniziali.Enabled = true;
        }



        void ImportaFileCsv(string filename)
        {

            //string filename;
            //filename = "CSVdiEsempio\\P18504_TEST PVC.CSV";
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                log.Debug("Importazione file " + Properties.Settings.Default.File1 + '\r');

                //acquisizione riga per riga del csv, controllo esistenza del id di prova ed eventuale inserimento nel tabase
                //TODO se possibile leggere all'indietro -- non è possibile
                //TODO prescartare le righe in basa alla data, p.e. in base ad un numero massimo di giorni all'indietro
                csv.Configuration.Delimiter = ";";
                var i = 0;

                try
                {
                    var righe = csv.GetRecords<ClasseCsv>();
                    var nuovirecord = 0;
                    var nuovirecordinseriti = 0;
                    var nuovirecordconerrori = 0;
                    try
                    {
                        foreach (ClasseCsv riga in righe)
                        {
                            i += 1;
                            //verifica data
                            //
                            //
                            //
                            bool filtra = Properties.Settings.Default.filtragiorni;
                            if (filtra)
                            {
                                //controllo data
                                var data = riga.Orario;
                                if ((DateTime.Now - data).TotalDays > Properties.Settings.Default.giorni)
                                //se la data è filtrata si passa la prossimo record
                                continue;
                            }
                            Guid guiddipasso = riga.guidGuiddiPassoDiProva;
                            Guid guiddiprova = riga.guidGuiddiProva;


                                //verifica se la riga è gia stata inserita nel database
                                var count = db.Tests.Where(o => (o.GuidProva == riga.guidGuiddiProva) & (o.GuidPassoProva == riga.guidGuiddiPassoDiProva)).Count();
                                if (count == 0)
                                {
                                //inserimento dei campi neccessari della riga csv dato nel database
                                nuovirecord += 1;
                                Test prova = new Test();
                                try
                                {

                                    prova.GuidProva = riga.guidGuiddiProva;
                                    prova.GuidPassoProva = riga.guidGuiddiPassoDiProva;
                                    prova.Orario = riga.Orario;   //
                                    prova.passo = riga.passo;
                                    prova.metodo = riga.metodo;
                                    prova.valore1 = riga.valore1;
                                    prova.valore1unitàdimisura = riga.valore1unitàdimisura;
                                    prova.valore2 = riga.valore2;
                                    prova.valore2unitàdimisura = riga.valore2unitàdimisura;
                                    prova.esitopasso = riga.esitopasso;
                                    prova.esitototale = riga.esitototale;
                                    prova.numerodiserie = int.Parse(riga.numerodiserie);
                                    prova.programmadiprova = riga.programmadiprova;
                                    
                                    prova.numeroprogetto = riga.numeroprogetto;
                                    prova.datiordine1 = Regex.Replace(riga.datiordine1, "{.*}", "");
                                    prova.datiordine2 = Regex.Replace(riga.datiordine2, "{.*}", "");

                                    prova.nomecsv = Path.GetFileNameWithoutExtension(filename);
                                    prova.trasferito = false;
                                    db.Tests.Add(prova);
                                    nuovirecordinseriti += 1;
                                    log.Debug($"Riga {i} inserita");
                                }
                                catch (Exception ex)
                                {
                                    //errore di traslazione dei valori dai campi csv ai campi database, inserisco comunque il dato nel db per non riloggarlo nelle successivie importazioni
                                    //log.Debug("errore di traslazione dei valori dai campi csv ai campi database - riga " + i);
                                    //log.Debug(ex);
                                    //TODO  registre il reocor se il guid è stao rilevato - se esistese la possibilità di errore fin dal guid valutare di registre la righa in altra struttura per saltarla alle sucessive acquisiioni
                                    if (prova.GuidProva != Guid.Empty)
                                    {
                                        //log.Debug(prova.Orario);
                                        prova.errore = true;
                                        db.Tests.Add(prova);
                                        nuovirecordconerrori += 1;
                                        log.Warn($"Riga {i} inserita (incompleta)");
                                    }
                                }
                            }
                            else
                            {
                                //log.Debug($"Riga {i} già presente");
                            }

                        }
                        log.Info($"Lettura {Path.GetFileName(filename)} -- Record Totali: {i} - Nuovi: {nuovirecord} - Inseriti {nuovirecordinseriti} - Inseriti con errori: {nuovirecordconerrori} ");
                    }
                    catch (Exception ex)
                    {
                        //errore di interpretazione di uno o più campi di una riga
                        log.Error("errore di interpretazione di uno o più campi di una riga file - csv non conforme");
                        log.Debug(ex);
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    //errore di GetRecords
                    log.Error("Errore apertura file csv");
                    log.Debug(ex);
                }
            }
        }

        bool InviaPrimoTestDisponible()
        {
            Globali.InvioInCorso = true;
            //cerca un test non inviato
            var count = db.Tests.Where(o => (o.trasferito != true & o.errore != true & o.datiordine1 != "" & o.datiordine2 != "")).Select(o => o.GuidProva).Count();
            if (count == 0)
            {
                log.Debug("Nessun nuovo test trovato");
                Globali.InvioInCorso = false;
                return true;
            }

            //recupero il primo guid valido
           
            var guid = db.Tests.Where(o => (o.trasferito != true & o.errore != true & o.datiordine1 != "" & o.datiordine2 != "")).OrderBy(o=>o.Orario).Select(o => o.GuidProva).First();
            log.Info($"Test trovato: GUID {guid}");



            //verifica presenza di tutte le righe ncessarie per importare la prova
            var prove = db.Tests.Where(o => o.GuidProva == guid).OrderBy(t => t.Orario);
            if (prove == null) return true;   //non dovrebbe capitare

            var ok1 = prove.Where(o => o.metodo == "HVAC").Count();
            var ok2 = prove.Where(o => o.metodo == "ISO").Count();

            if (!(ok1 ==1  & ok2 == 1))
                {
                //non tutte le righe sono presenti - marca le righe esistenti il test cone fallato/inviato;
                log.Info($"Test incompleto - tutte le voci sono contrassegate come invalide e non saranno più valuate (guid {guid})");
                foreach (Test prova in prove)
                {
                    prova.errore = true;
                }
                db.SaveChanges();
                Globali.InvioInCorso = false;
                return true;
            }

            //estrazione dati da inviare

            DatiPerInvioTest Dato = new DatiPerInvioTest();
            string esitoHVAC = "";
            string esitoISO = "";
            foreach (Test prova in prove)
            {
                if (prova.metodo == "ISO")
                {
                    Dato.nomeccsv = prova.nomecsv; //passato per voci di log
                    Dato.guid = prova.GuidProva;  //passato per voci di log
       
                    Dato.tensioneisolamento = prova.valore1;
                    Dato.restistenzaisolamento = prova.valore2;
                    
                    Dato.esito =  (prova.esitototale.ToLower()=="go") ? "PASS":"Fail";
                    esitoISO = (prova.esitototale.ToLower() == "go") ? "PASS" : "Fail";

                    Dato.serialnumber = prova.numerodiserie.ToString() + prova.numeroprogetto.ToString();
                    Dato.idprogramma = prova.programmadiprova;
                    Dato.nomeprogramma = prova.datiordine1;
                    Dato.finalmaterial = prova.datiordine2;
                }
                if (prova.metodo == "HVAC")
                {
                    Dato.tensionerigidità = prova.valore1;
                    Dato.correnterigidità = prova.valore2;
                    esitoHVAC = (prova.esitototale.ToLower() == "go") ? "PASS" : "Fail";
                }
            }
            Dato.descrizioneesito = $"ISO: {esitoISO} - HVAC: {esitoHVAC}";

            //invio dati
            try
            {
                var res = Globali.Invio.Invio(Dato);
                //invio con successo segno come trasferiti;
                if (res) { 
                foreach (Test prova in prove)
                {
                    prova.OrarioTrasferimetno = DateTime.Now;
                    prova.serialegenerato = Dato.serialnumber;
                    prova.trasferito = true;
                }
                db.SaveChanges();
                }
                else
                {
                    //invio non effettutato da imputare alla libreria (connettivita, nome server, rete, etc.)
                    //i recrodo non vengono rimarcati e il tantativo verra ripetutto dopo aver fattto passare un intervallo più lungo;
                    log.Warn("Invio non risucito, verra riprovato tra 60 secondi");
                    Globali.InvioInCorso = false;
                    return false;
                }
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
                Globali.InvioInCorso = false;
                return false;
            }
            
            // aggiorna tabella con i test importati
            try
            { 
            var query1 = db.Tests.Where(o => o.trasferito == true).OrderByDescending(o => o.Orario).Take(100);
            var ultimitestimportati1 = query1.ToList();
            bindingSource1.DataSource = ultimitestimportati1;
            dataGridView1.DataSource = bindingSource1;
            }
            catch 
            { 
            
            }

            Globali.InvioInCorso = false;
            return true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
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
                if (chkAbilitaFile1.Checked) { 

                if (Properties.Settings.Default.MonitoraggioFile)
                {
                    fileSystemWatcher1.Path = Path.GetDirectoryName(Properties.Settings.Default.File1);
                    fileSystemWatcher1.Filter = Path.GetFileName(Properties.Settings.Default.File1);
                    fileSystemWatcher1.EnableRaisingEvents = true;
                    tmrLeggiFile1.Start();
                }
                                }
                else
                {
                    tmrLeggiFile1.Stop();
                }
                Properties.Settings.Default.File1Abilitato = chkAbilitaFile1.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void chkAbilitaFile2_CheckedChanged(object sender, EventArgs e)
        {
            if (!Globali.InAvvio)
            {
                if (chkAbilitaFile2.Checked)
                {

                    if (Properties.Settings.Default.MonitoraggioFile)
                    {
                        fileSystemWatcher2.Path = Path.GetDirectoryName(Properties.Settings.Default.File2);
                        fileSystemWatcher2.Filter = Path.GetFileName(Properties.Settings.Default.File2);
                        fileSystemWatcher2.EnableRaisingEvents = true;
                        tmrLeggiFile1.Start();
                    }
                }
                else
                {
                    tmrLeggiFile2.Stop();
                }
                Properties.Settings.Default.File2Abilitato = chkAbilitaFile2.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void btnInoltroSingoloTest_Click(object sender, EventArgs e)
        {
            try
            {
                InviaPrimoTestDisponible();
            }
            catch (Exception ex)
            {
                log.Debug("Errore Invio Test");
                log.Debug(ex);
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

        private void btnCancellaTutti_Click(object sender, EventArgs e)
        {
           
            db.Tests.RemoveRange(db.Tests);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globali.InArresto) return;
            this.Hide();
            e.Cancel = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                Hide();
        }


        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globali.InArresto = true;
            Application.Exit();
        }

        private void tmrInvioDati_Tick(object sender, EventArgs e)
        {
            bool esitoinvio;
            tmrInvioDati.Stop();
            try
            {
                if (Properties.Settings.Default.InvioAutomatico)
                {
                    if (!Globali.InvioInCorso)
                    {
                        esitoinvio = InviaPrimoTestDisponible();
                        if (esitoinvio)
                        {
                            tmrInvioDati.Interval = 60 * 1000;
                            tmrInvioDati.Start();
                        }
                        else
                        {
                            Debug.Print("Invio dati non risucito; passaggio a intervallo di 120 secondi");
                            tmrInvioDati.Interval = 60 * 2* 1000;
                        }
                    }
                }
                else
                {
                    //lascio il timer disattivato
                    return;
                }
            }
            catch 
            {
                log.Debug("Errore sconosciuto durante l'invio automatico dei test, pasaggio ad intervalli di 60 secondi");
                tmrInvioDati.Interval = 60 * 1000;
            }
            //reinnesco del timer intervallo dipendente dall'esito dell'invio
            tmrInvioDati.Start();
        }


        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            if (!Properties.Settings.Default.File1Abilitato | !Properties.Settings.Default.MonitoraggioFile)
            {
                fileSystemWatcher1.EnableRaisingEvents = false;
            }

            log.Debug("modificato file " + e.Name + " (" + e.ChangeType.ToString() + ")");
            tmrLeggiFile1.Start();
        }

        private void fileSystemWatcher2_Changed(object sender, FileSystemEventArgs e)
        {
            if (!Properties.Settings.Default.File2Abilitato | !Properties.Settings.Default.MonitoraggioFile)
            {
                fileSystemWatcher2.EnableRaisingEvents = false;
            }

            log.Debug("modificato file " + e.Name + " (" + e.ChangeType.ToString() + ")");
            tmrLeggiFile2.Start();
        }


        private void apriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void chkMonitoraggioAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            if (!Globali.InAvvio)
            {
                if (chkMonitoraggioAutomatico.Checked)
                {
                    if (chkAbilitaFile1.Checked)
                    {
                        fileSystemWatcher1.Path = Path.GetDirectoryName(Properties.Settings.Default.File1);
                        fileSystemWatcher1.Filter = Path.GetFileName(Properties.Settings.Default.File1);
                        fileSystemWatcher1.EnableRaisingEvents = true;
                        tmrLeggiFile1.Start();
                    }
                    if (chkAbilitaFile2.Checked)
                    {
                        fileSystemWatcher2.Path = Path.GetDirectoryName(Properties.Settings.Default.File2);
                        fileSystemWatcher2.Filter = Path.GetFileName(Properties.Settings.Default.File2);
                        fileSystemWatcher2.EnableRaisingEvents = true;
                        tmrLeggiFile2.Start();
                    }
                }
                else
                {
                    tmrLeggiFile1.Stop();
                    tmrLeggiFile2.Stop();
                }
                Properties.Settings.Default.MonitoraggioFile = chkMonitoraggioAutomatico.Checked;
                Properties.Settings.Default.Save();
                log.Debug("Monitoraggio file abilitato: " + Properties.Settings.Default.MonitoraggioFile);

            }
        }

        private void chkInoltroAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            if (!Globali.InAvvio)
            {
                Properties.Settings.Default.InvioAutomatico = chkInoltroAutomatico.Checked;
                Properties.Settings.Default.Save();
                if (Properties.Settings.Default.InvioAutomatico)
                {
                    tmrInvioDati.Interval = 5 * 1000;
                    tmrInvioDati.Start();
                }
                else
                {
                    tmrInvioDati.Stop();
                }
                log.Debug("Invio sutomatico ablilitato: " + Properties.Settings.Default.InvioAutomatico);
            }
        }

        private void tmrLeggiFile1_Tick(object sender, EventArgs e)
        {
            tmrLeggiFile1.Stop();  //viene reinesscato da una modifica del file (systemfilewatcher) o da una riabilitazione della ceckbox
            if (File.Exists(Properties.Settings.Default.File1))
            {
                log.Debug("Archivio modificato: " + Properties.Settings.Default.File1);
                ImportaFileCsv(Properties.Settings.Default.File1);
            }

        }

        private void tmrLeggiFile2_Tick(object sender, EventArgs e)
        {
            tmrLeggiFile2.Stop();  //viene reinesscato da una modifica del file (systemfilewatcher) o da una riabilitazione della ceckbox
            if (File.Exists(Properties.Settings.Default.File2))
            {
                log.Debug("Archivio modificato: " + Properties.Settings.Default.File2);
                ImportaFileCsv(Properties.Settings.Default.File2);
            }
        }

        private void tmrAttivitàIniziali_Tick(object sender, EventArgs e)
        {
            tmrAttivitàIniziali.Stop();

            if (Properties.Settings.Default.MonitoraggioFile)
            {
                if (Properties.Settings.Default.File1Abilitato)
                {
                    fileSystemWatcher1.Path = Path.GetDirectoryName(Properties.Settings.Default.File1);
                    fileSystemWatcher1.Filter = Path.GetFileName(Properties.Settings.Default.File1);
                    fileSystemWatcher1.EnableRaisingEvents = true;
                    tmrLeggiFile1.Start();
                }
                if (Properties.Settings.Default.File2Abilitato)
                {
                    fileSystemWatcher2.Path = Path.GetDirectoryName(Properties.Settings.Default.File2);
                    fileSystemWatcher2.Filter = Path.GetFileName(Properties.Settings.Default.File2);
                    fileSystemWatcher2.EnableRaisingEvents = true;
                    tmrLeggiFile2.Start();
                }
            }

                if (Properties.Settings.Default.InvioAutomatico)
                {
                    tmrInvioDati.Interval = 5 * 1000;
                    tmrInvioDati.Start();
                }
            
        }

        private void btnLeggiFile1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.File1))
            {
                log.Debug("acquisizione " + Properties.Settings.Default.File1);
                ImportaFileCsv(Properties.Settings.Default.File1);
            }
            else
            {
                MessageBox.Show("Selezionare un file e salvare l'impostazione");
            }
        }

        private void btnLeggiFile2_Click(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.File2))
            {
                log.Debug("acquisizione " + Properties.Settings.Default.File2);
                ImportaFileCsv(Properties.Settings.Default.File2);
            }
            else
            {
                MessageBox.Show("Selezionare un file e salvare l'impostazione");
            }
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (debugToolStripMenuItem.Checked)
            {
                debugToolStripMenuItem.Checked = false;
                btnCancellaTutti.Visible = false;
                btnSalva.Visible = false;
                dataGridView1.ReadOnly = true;
            }
            else
            {
                debugToolStripMenuItem.Checked = true;
                btnCancellaTutti.Visible = true;
                btnSalva.Visible = true;
                dataGridView1.ReadOnly = false;
            }
        }


        private void visualizzaTuttiIRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.Tests.Load();
            dataGridView1.DataSource = db.Tests.Local.ToBindingList();
        }

        private void visualizzaUltimiRecordImporatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = db.Tests.OrderByDescending(o => o.Orario).Take(1000);
            var ultimitestimportati = query.ToList();
            bindingSource1.DataSource = ultimitestimportati;
            dataGridView1.DataSource = ultimitestimportati;
        }

        private void visualizzaUltimiRecordTrasferitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = db.Tests.OrderByDescending(o => o.Orario).Where(o => o.trasferito == true).Take(1000);
            var ultimitestimportati = query.ToList();
            bindingSource1.DataSource = ultimitestimportati;
            dataGridView1.DataSource = ultimitestimportati;
        }

        private void visualizzaUltimiRecordConErroriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = db.Tests.OrderByDescending(o => o.Orario).Where(o => o.errore == true).Take(1000);
            var ultimitestimportati = query.ToList();
            bindingSource1.DataSource = ultimitestimportati;
            dataGridView1.DataSource = ultimitestimportati;
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globali.InArresto = true;
            Application.Exit();
        }

        private void visualizzaDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBoxAppender app = null;
            foreach (var appender in LogManager.GetRepository().GetAppenders())
            {
                if (appender.GetType() == typeof(TextBoxAppender))
                    app = (TextBoxAppender)appender;
            }
            if (app == null) return;

            if (visualizzaDebugToolStripMenuItem.Checked)
            {
                    app.Threshold = log4net.Core.Level.Debug;
            }
            else
            {
                    app.Threshold = log4net.Core.Level.Info;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("StartManager.exe"));
        }
    }
    }




