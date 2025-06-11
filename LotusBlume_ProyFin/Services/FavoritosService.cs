using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotusBlume_ProyFin.Models;

namespace LotusBlume_ProyFin.Services
{
    public class FavoritosService
    {
        private readonly SQLiteAsyncConnection _db;

        public FavoritosService()
        {
            _db = App.SQLiteDB.GetDatabaseConnection(); // O usa inyección de dependencias
        }

        public async Task<List<Vestidos>> GetFavoritosAsync()
        {
            return await _db.Table<Vestidos>()
                          .Where(v => v.EsFavorito)
                          .ToListAsync();
        }

        public async Task ToggleFavorito(int vestidoId)
        {
            var vestido = await _db.Table<Vestidos>()
                                 .FirstOrDefaultAsync(v => v.Id == vestidoId);

            if (vestido != null)
            {
                vestido.EsFavorito = !vestido.EsFavorito;
                await _db.UpdateAsync(vestido);
            }
        }
    }
}
