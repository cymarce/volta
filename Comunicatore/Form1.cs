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

namespace Comunicatore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

                //
                //{
                //    int count = db.Tests.SelectMany<Test>;
                //    db.Tests.Add(new Test { GuidGlobale = Guid.Empty, GuidProva = Guid.Empty, Passo = 0, Trasferito = true });

                //}



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


                    Guid guid = riga.guidGuiddiPasso;
                    //guid = Guid.Parse(riga.guidGuiddiPasso);



                    using (var db = new DbTestContext())
                    {
                        
                        //verifica esistenza del guid prova nel database?
                        var count = db.Tests.Where(o => o.GuidProva == guid).Count();

                        if (count == 0)
                        {
                            //inserimento del dato nel db
                            Test prova = new Test();
                            prova.GuidGlobale = riga.guidGuiddiProva;
                            prova.GuidProva = riga.guidGuiddiPasso;
                            prova.metodo = riga.metodo;
                            prova.Orario = riga.Orario;
                            prova.esitototale = riga.esitototale;
                            prova.trasferito = false;

                            db.Tests.Add(prova);
                            Debug.Print("--inserimento:" + riga.guidGuiddiPasso + " ; " + riga.passo);
                        }
                        db.SaveChanges();
                    }
                }
            }
        }
    }

    class DbTestContext : DbContext 
    {
        public DbTestContext() : base("TestDB")
            {}

        public DbSet<Test> Tests { get; set; }
    }


    class Test
    {
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public Guid GuidGlobale { get; set; }

        [System.ComponentModel.DataAnnotations.Key, Column(Order = 1)]
        public Guid GuidProva { get; set; }

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
