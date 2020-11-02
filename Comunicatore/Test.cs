using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicatore
{
    public class Test
    {

        public Test()
        {
            //this.Orario = DateTime.MinValue;  
        }

        //campi provenienti dal file csv
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public Guid GuidProva { get; set; }

        [System.ComponentModel.DataAnnotations.Key, Column(Order = 1)]
        public Guid GuidPassoProva { get; set; }

        public int passo { get; set; }

        public string metodo { get; set; }

        public int chiavedimetodo { get; set; }

        public string valore1 { get; set; }

        public string valore1unitàdimisura { get; set; }

        public string valore2 { get; set; }

        public string valore2unitàdimisura { get; set; }

        public string esitopasso { get; set; }

        public string esitototale { get; set; }

        public int numerodiserie { get; set; }

        public string programmadiprova { get; set; }

        public DateTime Orario { get; set; }
        
        public int numeroprogetto { get; set; }

        public string datiordine1 { get; set; }

        public string datiordine2 { get; set; }

        //campi uso interno
        public string nomecsv { get; set; }
        public string serialegenerato { get; set; }
        public bool trasferito { get; set; }
        public DateTime? OrarioTrasferimetno { get; set; }
        public bool errore { get; set; }

    }
}
