


using LotusBlume_ProyFin.Pages;

namespace LotusBlume_ProyFin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RegistroDeCuenta();
        }
    }
}
