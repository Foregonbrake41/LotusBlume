namespace LotusBlume_ProyFin.Pages;

public partial class Principal : ContentPage
{
    int id = 1;
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
    