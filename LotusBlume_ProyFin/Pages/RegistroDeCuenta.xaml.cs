using LotusBlume_ProyFin.Models;
using System;
namespace LotusBlume_ProyFin.Pages;

public partial class RegistroDeCuenta : ContentPage
{
	public RegistroDeCuenta()
	{
		InitializeComponent();
	}
    private void OnTogglePasswordVisibility(object sender, EventArgs e)
    {
        entryContrasena.IsPassword = !entryContrasena.IsPassword;
        var button = (ImageButton)sender;
        button.Source = entryContrasena.IsPassword ? "invisible_contrasena.png" : "visible_contrasena.png";
    }
    
    async public void ClickedRegresar(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///InicioSesion");
    }
    private async void OnRegistrarClicked(object sender, EventArgs e)
    {
        var nuevoUsuario = new Usuarios
        {
            Nombre = entryNombre.Text,
            Direccion = entryDireccion.Text,
            Email = entryCorreo.Text,
            Usuario = entryUsuario.Text,
            Contrasena = entryContrasena.Text
        };

        try
        {
            await App.SQLiteDB.SaveUsuarioAsync(nuevoUsuario);
            await DisplayAlert("Éxito", "Usuario registrado", "OK");
            await Shell.Current.GoToAsync("///InicioSesion");
        }
        catch (Exception ex)
        {//Una cuenta con ese correo ya existe"
            await DisplayAlert("Error",$"Ocurrió un error: {ex.Message}", "OK");
            return;
        }
    }
}