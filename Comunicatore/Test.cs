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

        public string valore1 { get; set; }

        public string valore1unitàdimisura { get; set; }

        public string valore2 { get; set; }

        public string valore2unitàdimisura { get; set; }

        public int numerodiserie { get; set; }

        public int numeroprogetto { get; set; }

        public string barcode { get; set; }

        public int numeroprova { get; set; }

        public string nomecsv { get; set; }

        public bool trasferito { get; set; }
    }
}
