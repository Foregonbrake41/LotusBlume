using System.Collections.ObjectModel;
using LotusBlume_ProyFin.Models;
using SQLite;

namespace LotusBlume_ProyFin.Pages
{
    public partial class Articulos : ContentPage
    {
        public ObservableCollection<string> Imagenes { get; set; }

        public Articulos()
        {
            InitializeComponent();
            //MostrarDatosVestidos();

            Imagenes = new ObservableCollection<string>
            {
                "vestido_noche_1.png",
                "accesorio_noche_1.jpg"
            };

            BindingContext = this;
        }
        //private void MostrarDatosVestidos()
        //{
        //    var id_vestido = 1;

        //    if (id_vestido != null)
        //    {
        //        lblID.Text = $"{Vestidos.Id}";
        //        lblNombreVestido.Text = $"Direccion: {Vestidos.Direccion}";
        //        lblPrecio.Text = $"${Vestidos.Precio}";

        //    }
        //}
    }
}
