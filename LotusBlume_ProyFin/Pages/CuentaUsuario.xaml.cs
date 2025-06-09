namespace LotusBlume_ProyFin.Pages;
using LotusBlume_ProyFin.Models;

public partial class CuentaUsuario : ContentPage
{
	public CuentaUsuario()
	{
		InitializeComponent();
        MostrarDatosUsuario();

    }
    private void MostrarDatosUsuario()
    {
        var usuario = SesionActual.UsuarioActivo;

        if (usuario != null)
        {
            labelNombre.Text = $"Nombre: {usuario.Nombre}";
            labelDireccion.Text = $"Direccion: {usuario.Direccion}";
            labelCorreo.Text = $"Correo: {usuario.Email}";
        }
    }
    async public void ClickedCerrarSesion(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///InicioSesion");
    }
}