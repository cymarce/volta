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
            InitializeComponent();

            Globali.Mainform = this;

            log = log4net.LogManager.GetLogger("Main");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo("Log.xml"));

            log.Debug("Avvio");

            try
            {

                db = new DbTestContext();
                db.Tests.Load();

                this.dataGridView1.DataSource = db.Tests.Local.ToBindingList();
            }
            catch (Exception ex) 
            {
                log.Debug(ex);
            }

            delgato = new tscriptDelegate(rtxtLog_AggiungiRiga);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Info("Bottone1");
            TestCsvHelper();
            //CSVContext context = new CSVContext();
            //context.Configuration.UseDatabaseNullSemantics = true;
            //var query = from line in context.P18504_Test select line;
        }


        void TestCsvHelper()
        {
            using (var reader = new StreamReader("CSVdiEsempio\\P18504_TEST PVC.CSV"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                //acquisizione riga per riga del csv, controllo esistenza del id di prova ed eventuale inserimento nel tabase
                //TODO se possibile leggere all'indietro -- non è possibile
                //TODO prescartare le righe in basa alla data, p.e. in base ad un numero massimo di giorni all'indietro
                csv.Configuration.Delimiter = ";";
                var righe = csv.GetRecords<ClasseCsv>();

                foreach (ClasseCsv riga in righe)
                {

                    //verifica data
                    //
                    //
                    //
                    if (Properties.Settings.Default.filtragiorni)
                    {
                        //se la data è filtrata si passa la prossimo record
                        continue;
                    }


                    Guid guiddipasso = riga.guidGuiddiPassoDiProva;
                    Guid guiddiprova = riga.guidGuiddiProva;
                    //guid = Guid.Parse(riga.guidGuiddiPasso);

                    //verifica esistenza del guid prova nel database?
                    try {
                        var count = db.Tests.Where(o => (o.GuidProva == riga.guidGuiddiProva) & (o.GuidPassoProva == riga.guidGuiddiPassoDiProva)).Count();

                        if (count == 0)
                        {
                            //inserimento del dato nel db
                            Test prova = new Test();
                            prova.GuidProva= riga.guidGuiddiProva;
                            prova.GuidPassoProva= riga.guidGuiddiPassoDiProva;
                            prova.metodo = riga.metodo;
                            prova.Orario = riga.Orario;
                            prova.esitototale = riga.esitototale;
                            prova.trasferito = false;

                            db.Tests.Add(prova);
                            Debug.Print("--inserimento:" + riga.guidGuiddiPassoDiProva + " ; " + riga.passo);
                        }
                        db.SaveChanges();
                    }
                    catch (Exception ex)                     {
                        log.Debug(ex);
                    }

                }
            }
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

                Array.Copy( textBox.Lines, textBox.Lines.Length - ShrinkTo - 1, righe,  0, ShrinkTo);
                textBox.Lines = righe;

            }

            textBox.AppendText(text);
        }

        private void testsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.testsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: questa riga di codice carica i dati nella tabella 'testDBDataSet.Tests'. È possibile spostarla o rimuoverla se necessario.
            this.testsTableAdapter.Fill(this.testDBDataSet.Tests);

        }
    }


    public class DbTestContext : DbContext 
    {
        //public DbTestContext() : base("name=Comunicatore.Properties.Settings.TestDBConnectionString")
                    public DbTestContext() : base("DbTest")
        {
            Database.SetInitializer<DbTestContext>(new CreateDatabaseIfNotExists<DbTestContext>());
        }

        public DbSet<Test> Tests { get; set; }
    }


    public class Test
    {
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public Guid GuidProva{ get; set; }

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

        public bool trasferito { get; set; }
    }
}
