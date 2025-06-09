namespace LotusBlume_ProyFin.Pages;

public partial class RegistroDeCuenta : ContentPage
{
	public RegistroDeCuenta()
	{
		InitializeComponent();
	}
    private void OnTogglePasswordVisibility(object sender, EventArgs e)
    {
        entryPassword.IsPassword = !entryPassword.IsPassword;
        var button = (ImageButton)sender;
        button.Source = entryPassword.IsPassword ? "invisible_contrasena.png" : "visible_contrasena.png";
    }
}