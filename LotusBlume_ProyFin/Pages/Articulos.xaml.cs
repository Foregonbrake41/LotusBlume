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
                ActualizarUI(); // Solo actualiza UI aqu�
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
                CargarImagenesSegunId(); // Llamar despu�s de cargar el vestido
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
                    lblDescripcion.Text = "Vestido de quincea�era con delicados bordados de encaje y cristales, corte princesa que realza la silueta. Disponible en tonos pastel con detalles brillantes que capturan la luz.";
                    break;
                case 2:
                    Imagenes.Add("vestido_xv_2.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    lblDescripcion.Text  = "Modelo de alta costura con ca�da de tul en capas, escote ilusi�n y espalda decorada con perlas. Ideal para una celebraci�n sofisticada y memorable.";
                    break;
                case 3:
                    Imagenes.Add("vestido_xv_3.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    lblDescripcion.Text  = "Dise�o inspirado en cuentos de hadas con corpi�o ajustado y falda voluminosa. Incluye aplicaciones de pedrer�a y cintur�n de sat�n para un toque real.";
                    break;
                case 4:
                    Imagenes.Add("vestido_noche_1.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    lblDescripcion.Text  = "Vestido de gala largo en seda brillante con aberturas laterales discretas y drapeado asim�trico. Perfecto para eventos formales donde la elegancia es primordial.";
                    break;
                case 5:
                    Imagenes.Add("vestido_noche_2.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    lblDescripcion.Text  = "Modelo de noche con transparencias estrat�gicas, bordado met�lico y cola recogible. Combina misterio y sofisticaci�n para una presencia impactante.";
                    break;
                case 6:
                    Imagenes.Add("vestido_noche_3.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    lblDescripcion.Text  = "Creaci�n en gasa con degrad� de colores y mangas largas transparentes. El detalle estrella es su cintura alta con lazada para una silueta estilizada.";
                    break;
                case 7:
                    Imagenes.Add("vestido_noche_4.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    lblDescripcion.Text  = "Dise�o avant-garde con mezcla de textiles: raso, organza y detalles en metal. Silueta de sirena moderna para mujeres que buscan romper esquemas.";
                    break;
                case 8:
                    Imagenes.Add("vestido_noche_5.png");
                    Imagenes.Add("accesorio_noche_1.png");
                    lblDescripcion.Text  = "Vestido corto con estructura arquitect�nica, hombros pronunciados y plisados geom�tricos. Una pieza art�stica para eventos de alta moda.";
                    break;
                case 9:
                    Imagenes.Add("vestido_picnic_1.jpg");
                    lblDescripcion.Text  = "Vestido campestre de algod�n org�nico con estampado floral y volantes en escote y mangas. Fresco, ligero y perfecto para reuniones al aire libre.";
                    break;
                case 10:
                    Imagenes.Add("vestido_picnic_2.jpg");
                    lblDescripcion.Text  = "Modelo midi con mezclilla desgastada y aplicaciones de encaje en espalda. Incluye cintur�n tejido a mano para un look boho-chic relajado.";
                    break;
                case 11:
                    Imagenes.Add("vestido_picnic_3.jpg");
                    lblDescripcion.Text  = "Vestido vaporoso en tonos celestes con mangas globo y detalle de nudo frontal. Tejido transpirable que fluye con el movimiento.";
                    break;
                case 12:
                    Imagenes.Add("vestido_picnic_4.jpg");
                    lblDescripcion.Text  = "Dise�o semi-formal con cuello mandar�n y botonadura frontal. Combina la comodidad de los picnic con un toque de refinamiento urbano.";
                    break;
                case 13:
                    Imagenes.Add("vestido_picnic_5.jpg");
                    lblDescripcion.Text  = "Minivestido oversize con bolsillos utilitarios y capucha desmontable. Est�tica contempor�nea para amantes del estilo streetwear elegante.";
                    break;
            }
        }

        private void ActualizarUI()
        {
            if (Vestido != null)
            {
                lblID.Text = $"ID: {Vestido.Id}";
                lblNombreVestido.Text = Vestido.Nombre;
                lblPrecio.Text = $"${Vestido.Precio:N2} MXN";
            }
        }

        private readonly FavoritosService _favoritosService = new();

        private async void OnFavoritoClicked(object sender, EventArgs e)
        {
            if (Vestido == null) return;

            await _favoritosService.ToggleFavorito(Vestido.Id);

            var image = (Image)sender;
            image.Source = Vestido.EsFavorito
                ? "corazon_relleno.png"
                : "corazon.png";

            // Actualiza el estado local
            Vestido.EsFavorito = !Vestido.EsFavorito;
        }
    }
}