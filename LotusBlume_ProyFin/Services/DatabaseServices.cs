using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotusBlume_ProyFin.Models;
using SQLite;

namespace LotusBlume_ProyFin.Services
{
    internal class DatabaseServices
    {
        private SQLiteConnection _db;

        public DatabaseServices()
        {
            try
            {
                // Ruta de la base de datos
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "amazon.db");
                _db = new SQLiteConnection(dbPath);

                // Crea las tablas si no existen
                _db.CreateTable<Vestidos>();
                _db.CreateTable<Usuario>();

                Debug.WriteLine("✅ Base de datos creada en: " + dbPath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("❌ Error al iniciar la BD: " + ex.Message);
            }
        }

        // Métodos CRUD para Vestidos
        public List<Vestidos> GetVestidos() => _db.Table<Vestidos>().ToList();
        public int SaveVestido(Vestidos vestido) => vestido.Id == 0 ? _db.Insert(vestido) : _db.Update(vestido);
        public int DeleteVestido(Vestidos vestido) => _db.Delete<Vestidos>(vestido.Id);

        // Métodos para Usuarios
        public Usuario GetUsuario(string email) => _db.Table<Usuario>().FirstOrDefault(u => u.Email == email);
        public int SaveUsuario(Usuario usuario) => usuario.Id == 0 ? _db.Insert(usuario) : _db.Update(usuario);
    }
}
