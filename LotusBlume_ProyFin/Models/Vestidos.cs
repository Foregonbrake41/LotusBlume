using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LotusBlume_ProyFin.Models
{
    [Table("Vestidos")]
    class Vestidos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string ImagenUrl { get; set; } // Ruta de la imagen
    }
}
