using System.Collections.ObjectModel;

namespace LotusBlume_ProyFin.Pages
{
    public partial class Articulos : ContentPage
    {
        public ObservableCollection<string> Imagenes { get; set; }

        public Articulos()
        {
            InitializeComponent();

            Imagenes = new ObservableCollection<string>
            {
                "vestido_noche_1.png",
                "accesorio_noche_1.jpg"
            };

            BindingContext = this;
        }
    }
}
