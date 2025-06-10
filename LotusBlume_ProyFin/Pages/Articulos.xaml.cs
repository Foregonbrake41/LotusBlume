using LotusBlume_ProyFin.Models;
using LotusBlume_ProyFin.Services;

namespace LotusBlume_ProyFin.Pages
{
    [QueryProperty(nameof(VestidoId), "id")]
    public partial class Articulos : ContentPage
    {
        private Vestidos _vestido;
        public Vestidos Vestido
        {
            get => _vestido;
            set
            {
                _vestido = value;
                OnPropertyChanged();
                ActualizarUI();
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
            }
        }

        private void ActualizarUI()
        {
            if (Vestido != null)
            {
                lblID.Text = $"ID: {Vestido.Id}";
                lblNombreVestido.Text = Vestido.Nombre;
                lblPrecio.Text = $"${Vestido.Precio:N2} MXN";
                lblDescripcion.Text = Vestido.Descripcion;
            }
        }

        // Evento para el botón de favoritos
        private void OnFavoritoClicked(object sender, EventArgs e)
        {
            // Cambiar entre corazón lleno/vacío
            var image = (Image)sender;
            image.Source = (image.Source as FileImageSource)?.File == "corazon.png"
                ? "corazon-relleno.png"
                : "corazon.png";
        }
    }
}