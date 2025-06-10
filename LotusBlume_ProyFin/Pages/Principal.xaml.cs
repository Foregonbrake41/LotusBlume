using LotusBlume_ProyFin.Models;
using System.Collections.ObjectModel;

namespace LotusBlume_ProyFin.Pages
{
    public partial class Principal : ContentPage
    {
        public ObservableCollection<VestidoPreview> VestidosXV { get; } = new ObservableCollection<VestidoPreview>();
        public ObservableCollection<VestidoPreview> VestidosNoche { get; } = new ObservableCollection<VestidoPreview>();
        public ObservableCollection<VestidoPreview> VestidosPicnic { get; } = new ObservableCollection<VestidoPreview>();

        public Principal()
        {
            InitializeComponent();
            BindingContext = this;

            CargarVestidosXV();
            CargarVestidosNoche();
            CargarVestidosPicnic();
        }

        private void CargarVestidosXV()
        {
            VestidosXV.Add(new VestidoPreview { Imagen = "vestido_xv_1.png", Id = 1, Descripcion = "Único y hermoso" });
            VestidosXV.Add(new VestidoPreview { Imagen = "vestido_xv_2.png", Id = 2, Descripcion = "Elegancia pura" });
            VestidosXV.Add(new VestidoPreview { Imagen = "vestido_xv_3.png", Id = 3, Descripcion = "Estilo de princesa" });
        }

        private void CargarVestidosNoche()
        {
            VestidosNoche.Add(new VestidoPreview { Imagen = "vestido_noche_1.png", Id = 4, Descripcion = "Brilla con elegancia" });
            VestidosNoche.Add(new VestidoPreview { Imagen = "vestido_noche_2.png", Id = 5, Descripcion = "Glamour que enamora" });
            VestidosNoche.Add(new VestidoPreview { Imagen = "vestido_noche_3.png", Id = 6, Descripcion = "Una noche inolvidable" });
            VestidosNoche.Add(new VestidoPreview { Imagen = "vestido_noche_4.png", Id = 7, Descripcion = "Alguna danza rota" });
            VestidosNoche.Add(new VestidoPreview { Imagen = "vestido_noche_5.png", Id = 8, Descripcion = "Una ciudad furiosa" });
        }

        private void CargarVestidosPicnic()
        {
            VestidosPicnic.Add(new VestidoPreview { Imagen = "vestido_picnic_1.jpg", Id = 9, Descripcion = "Frescura y encanto" });
            VestidosPicnic.Add(new VestidoPreview { Imagen = "vestido_picnic_2.jpg", Id = 10, Descripcion = "La flor más bella" });
            VestidosPicnic.Add(new VestidoPreview { Imagen = "vestido_picnic_3.jpg", Id = 11, Descripcion = "Celestal cual cielo" });
            VestidosPicnic.Add(new VestidoPreview { Imagen = "vestido_picnic_4.jpg", Id = 12, Descripcion = "¿Formal acaso?" });
            VestidosPicnic.Add(new VestidoPreview { Imagen = "vestido_picnic_5.jpg", Id = 13, Descripcion = "Aestetik" });
        }

        async void OnVestidoClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton imageButton && imageButton.BindingContext is VestidoPreview vestido)
            {
                await Shell.Current.GoToAsync($"///{nameof(Articulos)}?id={vestido.Id}");
            }
        }

        async void OnVerCatalogoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///Catalogo");
        }
    }
}