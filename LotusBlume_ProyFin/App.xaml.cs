    using LotusBlume_ProyFin.Services;
    using LotusBlume_ProyFin.Models;
    using SQLite;

    namespace LotusBlume_ProyFin
    {
        public partial class App : Application
        {
            static DatabaseServices db;
            public App()
            {
                InitializeComponent();
                MainPage = new AppShell();
                InsertarVestidosSiBaseEstaVacia();
            }
            public static DatabaseServices SQLiteDB
            {
                get
                {
                    if (db == null)
                    {
                        db = new DatabaseServices(Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "manolito.db"));
                    }
                    return db;
                }
            }
            private async Task InsertarVestidosSiBaseEstaVacia()
            {
                var lista = await App.SQLiteDB.GetVestidosAsync();
                if (lista.Count == 0)
                {
                    var vestidos = new List<Vestidos>
            {
                new() { Nombre = "Vestido Esencia Roja", Precio = 2499 },
                new() { Nombre = "Encanto de Encaje", Precio = 2799 },
                new() { Nombre = "Sueño de Tul", Precio = 3099 },
                new() { Nombre = "Noche Carmesí", Precio = 1899 },
                new() { Nombre = "Brillo Nocturno", Precio = 2099 },
                new() { Nombre = "Perla Negra", Precio = 1799 },
                new() { Nombre = "Estrella Azul", Precio = 2299 },
                new() { Nombre = "Velvet Dreams", Precio = 2399 },
                new() { Nombre = "Amanecer Floral", Precio = 1299 },
                new() { Nombre = "Tarde Soleada", Precio = 1499 },
                new() { Nombre = "Verano Pastel", Precio = 1399 },
                new() { Nombre = "Sueño Lavanda", Precio = 1599 },
                new() { Nombre = "Jardín Encantado", Precio = 1349 },
            };

                    foreach (var vestido in vestidos)
                    {
                        await App.SQLiteDB.SaveVestidoAsync(vestido);
                    }
                }
            }

        }
    }
