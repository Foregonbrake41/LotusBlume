namespace LotusBlume_ProyFin.Pages;

public partial class CuentaUsuario : ContentPage
{
	public CuentaUsuario()
	{
		InitializeComponent();
	}
    async public void ClickedCerrarSesion(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///InicioSesion");
    }
}