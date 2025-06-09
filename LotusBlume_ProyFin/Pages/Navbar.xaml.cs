namespace LotusBlume_ProyFin.Pages;

public partial class Navbar : ContentView
{
	public Navbar()
	{
		InitializeComponent();
	}
    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Principal");
    }

    private async void OnFavoritosClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Favoritos");
    }

    private async void OnCarritoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Carrito");
    }

    private async void OnPerfilClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///CuentaUsuario");
    }
}