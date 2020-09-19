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
                foreach (ClasseCsv riga in righe)
                {
                    Debug.Print(riga.guid1+" ; "+ riga.guid2 + " ; " + riga.passo);
                    i++;
                }

            }


        }

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
        private void Test_LeggiDb2()
        {



        }


    }
}
