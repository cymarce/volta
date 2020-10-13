using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicatore
{
    class ClasseCsv
    {
        [Index(0)][Key]
        public Guid guidGuiddiProva { get; set; }

        [Index(1)][Key]
        public Guid guidGuiddiPassoDiProva { get; set; }

        [Index(2)]
        public int passo { get; set; }

        [Index(3)]
        public string metodo { get; set; }
        
        [Index(4)]
        public int chiavedimetodo { get; set; }

        [Index(7)]
        public string valore1unitàdimisura { get; set; }

        [Index(8)]
        public string valore1{ get; set; }

        [Index(11)]
        public string valore2unitàdimisura { get; set; }

        [Index(12)]
        public string valore2 { get; set; }


        [Index(16)]
        public string esitopasso { get; set; }

        [Index(17)]
        public int chiaveesitopasso { get; set; }

        [Index(18)]
        public string esitototale { get; set; }

        [Index(19)]
        public int echiavesitototale { get; set; }

        [Index(23)]
        public int numerodiserie { get; set; }

        [Index(30)]
        public DateTime Orario { get; set; }

        [Index(31)]
        public int numeroprogetto { get; set; }

        [Index(54)]
        public string barcode { get; set; }

        [Index(63)]
        public int contatoreprova { get; set; }

    }

}
