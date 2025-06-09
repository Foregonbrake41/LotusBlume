namespace LotusBlume_ProyFin.Pages;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}
    async public void EnviarArticulo(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Articulos");
    }
    async public void EnviarCatalogo(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Catalogo");
    }
}
