using LotusBlume_ProyFin.Pages;

namespace LotusBlume_ProyFin
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            OnAppearing();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Precarga las páginas en segundo plano
            var pages = new List<ContentPage>
            {
                new Articulos(),
                new Carrito(),
                new Catalogo(),
                new CuentaUsuario(),
                new Favoritos(),
                new Header(),
                new InicioSesion(),
                new PantallaDeCarga(),
                new Principal(),
                new RecuperarContrasena(),
                new RegistroDeCuenta(),
            };

            foreach (var page in pages)
            {
                await Task.Run(() => {
                    // Renderiza la página sin mostrarla
                    var _ = page.Handler;
                });
            }
        }
    }
}
