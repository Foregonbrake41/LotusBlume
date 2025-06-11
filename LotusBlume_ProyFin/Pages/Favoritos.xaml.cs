using LotusBlume_ProyFin.Models;
using LotusBlume_ProyFin.Services;
using System.Collections.ObjectModel;

namespace LotusBlume_ProyFin.Pages
{
    public partial class Favoritos : ContentPage
    {
        public ObservableCollection<Vestidos> FavoritosList { get; } = new();
        private readonly FavoritosService _favoritosService = new();

        public Favoritos()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarFavoritos();
        }

        private async Task CargarFavoritos()
        {
            FavoritosList.Clear();
            var favoritos = await _favoritosService.GetFavoritosAsync();

            foreach (var item in favoritos)
            {
                FavoritosList.Add(item);
            }

            // Actualiza el contador
            tituloFavoritos.Text = $"Mis Favoritos ({FavoritosList.Count})";
        }

        private async void OnEliminarFavorito(object sender, EventArgs e)
        {
            if (sender is Image image && image.BindingContext is Vestidos vestido)
            {
                await _favoritosService.ToggleFavorito(vestido.Id);
                await CargarFavoritos(); // Refresca la lista
            }
        }

        private async void OnAddToCartClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Vestidos vestido)
            {
                // Implementa lógica para añadir al carrito
                await DisplayAlert("Éxito", $"{vestido.Nombre} añadido al carrito", "OK");
            }
        }
    }
}