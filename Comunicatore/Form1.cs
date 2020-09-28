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
                csv.Configuration.Delimiter = ";";
                var righe = csv.GetRecords<ClasseCsv>();
                int i = 1;

                //
                //{
                //    int count = db.Tests.SelectMany<Test>;
                //    db.Tests.Add(new Test { GuidGlobale = Guid.Empty, GuidProva = Guid.Empty, Passo = 0, Trasferito = true });
                    
                //}
                
               
                foreach (ClasseCsv riga in righe)
                {
                    Guid guid;

                    guid = Guid.Parse(riga.guidGuiddiPasso);
                    //verifica esistenza del guid globale nel database

                    using (var db = new DbTestContext())
                    {
                                                var count = db.Tests.Where(o => o.Trasferito == true).Count();

                     }

                    using (var db = new DbTestContext())
                    {
                        var query = from r in db.Tests
                                    where r.GuidGlobale == guid
                                    select r;

                        //inserimento dei test nel database (come non trasferiti)



                        //come si concnatena

                        Debug.Print(riga.guidGuiddiProva + " ; " + riga.guidGuiddiPasso + " ; " + riga.passo);
                        i++;
                    }

                }


            }




        }

        class Test
        {
            [System.ComponentModel.DataAnnotations.Key]
            public Guid GuidGlobale { get; set; }
            public Guid GuidProva { get; set; }
            public string TestNome { get; set; }
            public bool Trasferito { get; set; }
            public int Passo { get; set; }
        }

        class DbTestContext : DbContext
        {
            public DbSet<Test> Tests { get; set; }
        }



        //prove varie


        private void Test_LeggiDb1()
        {

            OleDbDataAdapter myDa;
            OleDbConnection myCn;
            OleDbCommand myCm;
            DataSet myDs = new DataSet();

            myCn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Marco\\Desktop\\UAFClientConnectorLibrary\\Comunicatore\\CSVdiEsempio\\;Extended Properties=\"Text;HDR=Yes;Delimited(;)\"");
            myCm = new OleDbCommand("Select * from [P18504_Test2.csv]", myCn);
            myDa = new OleDbDataAdapter(myCm);

            myCn.Open();


            myDa.Fill(myDs);


            dataGridView1.DataSource = myDs.Tables[0];

        }

    }
}
