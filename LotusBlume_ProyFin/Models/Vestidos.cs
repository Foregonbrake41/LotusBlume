using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LotusBlume_ProyFin.Models
{
    [Table("Vestidos")]
    public class Vestidos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public double Precio { get; set; }
    }

}
