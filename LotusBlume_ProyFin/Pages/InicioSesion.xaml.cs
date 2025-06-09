using LotusBlume_ProyFin.Models;
using Microsoft.Maui.Controls;
using System;
namespace LotusBlume_ProyFin.Pages;

public partial class InicioSesion : ContentPage
{
	public InicioSesion()
	{
		InitializeComponent();
	}
    private async void ClickedInicioSesion(object sender, EventArgs e)
    {
        string usuario = entryCorreo.Text?.Trim();
        string contrasena = entryContrasena.Text;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
        {
            await DisplayAlert("Error", "Por favor completa todos los campos", "OK");
            return;
        }

        var cuenta = await App.SQLiteDB.GetUsuarioAsync(usuario);

        if (cuenta != null && cuenta.Contrasena == contrasena)
        {
            await DisplayAlert("Bienvenido", $"Hola {cuenta.Nombre}", "OK");
            // Aquí puedes navegar a otra página, ejemplo:
            await Shell.Current.GoToAsync("///Principal");
        }
        else
        {
            await DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
        }
    }
    private void OnTogglePasswordVisibility(object sender, EventArgs e)
    {
        entryContrasena.IsPassword = !entryContrasena.IsPassword;
        var button = (ImageButton)sender;
        button.Source = entryContrasena.IsPassword ? "invisible_contrasena.png" : "visible_contrasena.png";
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