using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public string ImagenesJson { get; set; }  // Campo real en la base de datos

        [Ignore]
        public List<string> Imagenes
        {
            get => string.IsNullOrEmpty(ImagenesJson) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(ImagenesJson);
            set => ImagenesJson = JsonSerializer.Serialize(value);
        }
        [Ignore]
        public string ImagenPrincipal => Imagenes?.FirstOrDefault() ?? "imagen_default.png";
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        [Ignore]
        public bool EsFavorito { get; set; } // No se persiste en DB
    }

}
