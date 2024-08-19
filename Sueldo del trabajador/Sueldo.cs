using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sueldo_del_trabajador
{
    [Table("sueldo")]

    public class Sueldo
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("sueldoinicial")]
        public decimal SueldoInicial{ get; set; }
        [Column("aumentoaplicado")]
        public decimal AumentoAplicado { get; set; }
        [Column("nuevosueldo")]
        public decimal NuevoSueldo { get; set; }

      
    }
}
