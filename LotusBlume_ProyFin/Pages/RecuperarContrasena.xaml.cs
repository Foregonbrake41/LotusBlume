namespace LotusBlume_ProyFin.Pages;

public partial class RecuperarContrasena : ContentPage
{
	public RecuperarContrasena()
	{
		InitializeComponent();
	}
    async public void ClickedRegresar(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///InicioSesion");
    }
}