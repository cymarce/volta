using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comunicatore
{
    [System.ComponentModel.DataAnnotations.Schema.Table("P18504_Test")]
    class P18504_Test
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.String Condizione { get; set; }
        public System.String Value { get; set; }
    }
}
