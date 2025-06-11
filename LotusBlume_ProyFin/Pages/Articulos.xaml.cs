using LotusBlume_ProyFin.Helpers;
using LotusBlume_ProyFin.Models;
using LotusBlume_ProyFin.Services;
using System.Collections.ObjectModel;

namespace LotusBlume_ProyFin.Pages
{
    [QueryProperty(nameof(VestidoId), "id")]
    public partial class Articulos : ContentPage
    {
        public ObservableCollection<string> Imagenes { get; } = new();
        private Vestidos _vestido;

        public Vestidos Vestido
        {
            get => _vestido;
            set
            {
                _vestido = value;
                OnPropertyChanged();
                ActualizarUI(); // Solo actualiza UI aquí
            }
        }

        public int VestidoId { get; set; }

        public Articulos()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (VestidoId > 0)
            {
                Vestido = await App.SQLiteDB.GetVestidoByIdAsync(VestidoId);
                CargarImagenesSegunId(); // Llamar después de cargar el vestido
            }
        }

        private void CargarImagenesSegunId()
        {
            Imagenes.Clear();

            // Usamos el ID del vestido ya cargado
            switch (Vestido?.Id)
            {
                case 1:
                    Imagenes.Add("vestido_xv_1.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    break;
                case 2:
                    Imagenes.Add("vestido_xv_2.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    break;
                case 4:
                    Imagenes.Add("vestido_noche_1.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    break;
                    // Agrega más casos según necesites
            }
        }

        private void ActualizarUI()
        {
            if (Vestido != null)
            {
                lblID.Text = $"ID: {Vestido.Id}";
                lblNombreVestido.Text = Vestido.Nombre;
                lblPrecio.Text = $"${Vestido.Precio:N2} MXN";
                lblDescripcion.Text = Vestido.Descripcion; // Asegúrate de asignar esto también
            }
        }

        private void OnFavoritoClicked(object sender, EventArgs e)
        {
            var image = (Image)sender;
            image.Source = (image.Source as FileImageSource)?.File == "corazon.png"
                ? "corazon_relleno.png"
                : "corazon.png";
        }
    }
}