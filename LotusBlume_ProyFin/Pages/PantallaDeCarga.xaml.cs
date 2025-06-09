namespace LotusBlume_ProyFin.Pages;

public partial class PantallaDeCarga : ContentPage
{
	public PantallaDeCarga()
	{
		InitializeComponent();
        Lanzamiento();
    }

	public async void Lanzamiento()
	{
        // Temporizador para redirigir despu�s de 3 segundos
        try
        {
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                Shell.Current.GoToAsync("///InicioSesion");
                return false;
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurri� un error: {ex.Message}", "OK");
        }
    }

}