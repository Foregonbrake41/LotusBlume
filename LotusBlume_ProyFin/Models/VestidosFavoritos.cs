using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotusBlume_ProyFin.Models
{
    public class VestidosFavoritos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int VestidoId { get; set; }
    }
}
