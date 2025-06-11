using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using LotusBlume_ProyFin.Models;
using SQLite;

namespace LotusBlume_ProyFin.Services
{
    public class DatabaseServices
    {
        private SQLiteAsyncConnection _db;

        public DatabaseServices(string dbPath)
        {
            try
            { 
                // Ruta de la base de datos
                _db = new SQLiteAsyncConnection(dbPath);

                // Crea las tablas si no existen
                _db.CreateTableAsync<Vestidos>().Wait();
                _db.CreateTableAsync<Usuarios>().Wait();

                Debug.WriteLine("✅ Base de datos creada en: " + dbPath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("❌ Error al iniciar la BD: " + ex.Message);
            }
        }
        public SQLiteAsyncConnection GetDatabaseConnection()
        {
            return _db; // Método público para acceder a _db
        }

        // Métodos CRUD para Vestidos
        public async Task<List<Vestidos>> GetVestidosAsync()
        {
            return await _db.Table<Vestidos>().ToListAsync();
        }
        
        public async Task MarcarComoFavorito(int vestidoId, bool esFavorito)
        {
            var vestido = await _db.Table<Vestidos>().FirstOrDefaultAsync(v => v.Id == vestidoId);
            if (vestido != null)
            {
                vestido.EsFavorito = esFavorito;
                await _db.UpdateAsync(vestido);
            }
        }
        public async Task<int> SaveVestidoAsync(Vestidos vestido)
        {
            if (vestido.Id == 0)
                return await _db.InsertAsync(vestido);
            else
                return await _db.UpdateAsync(vestido);
        }

            public async Task<int> DeleteVestidoAsync(Vestidos vestido)
        {
            return await _db.DeleteAsync<Vestidos>(vestido.Id);
        }

        // Métodos para Usuarios
        public async Task<Usuarios> GetUsuarioAsync(string email)
        {
            return await _db.Table<Usuarios>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<int> SaveUsuarioAsync(Usuarios usuario)
        {
            if (usuario.Id == 0)
                return await _db.InsertAsync(usuario);
            else
                return await _db.UpdateAsync(usuario);
        }
        //Obtener vestidos por ID
        public async Task<Vestidos> GetVestidoByIdAsync(int id)
        {
            return await _db.Table<Vestidos>().FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
