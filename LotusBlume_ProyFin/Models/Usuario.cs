using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LotusBlume_ProyFin.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string PasswordHash { get; set; } // ¡Nunca guardes contraseñas en texto plano!
    }
}
