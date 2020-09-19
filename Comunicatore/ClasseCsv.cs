using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicatore
{
    class ClasseCsv
    {

        [Index(0)]
        public string guid1 { get; set; }

        [Index(1)]
        public string guid2 { get; set; }


        [Index(2)]
        public string passo { get; set; }
    }

}
