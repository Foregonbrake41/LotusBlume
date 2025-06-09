
namespace LotusBlume_ProyFin.Pages;

public partial class InicioSesion : ContentPage
{
	public InicioSesion()
	{
		InitializeComponent();
	}
    private void OnTogglePasswordVisibility(object sender, EventArgs e)
    {
        entryPassword.IsPassword = !entryPassword.IsPassword;
        var button = (ImageButton)sender;
        button.Source = entryPassword.IsPassword ? "invisible_contrasena.png" : "visible_contrasena.png";
    }
    async public void RecuperarContrasena(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///RecuperarContrasena");
    }
    async public void RegistrarseBoton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///RegistroDeCuenta");
    }
}