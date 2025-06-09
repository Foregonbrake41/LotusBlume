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
    private async void btnSolicitar_Clicked(object sender, EventArgs e)
    {
        string correo = entryCorreo.Text?.Trim().ToLower();

        if (string.IsNullOrEmpty(correo))
        {
            await DisplayAlert("Error", "Por favor ingresa tu correo electrónico.", "Aceptar");
            return;
        }

        var usuario = await App.SQLiteDB.GetUsuarioAsync(correo);

        if (usuario != null)
        {
            await DisplayAlert("Recuperación exitosa", $"Tu contraseña es: {usuario.Contrasena}", "Aceptar");
        }
        else
        {
            await DisplayAlert("Correo no encontrado", "El correo ingresado no está registrado.", "Aceptar");
        }
    }

    private void btnEnviar_Clicked(object sender, EventArgs e)
    {

    }
}