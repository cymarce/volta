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
        public string guidGuiddiProva { get; set; }

        [Index(1)]
        [Key]
        public string guidGuiddiPasso { get; set; }


        [Index(2)]
        public string passo { get; set; }
    }

}
