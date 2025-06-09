namespace LotusBlume_ProyFin.Pages;

public partial class PantallaDeCarga : ContentPage
{
	public PantallaDeCarga()
	{
		InitializeComponent();

        // Temporizador para redirigir después de 3 segundos
        Device.StartTimer(TimeSpan.FromSeconds(7), () =>
        {
            Shell.Current.GoToAsync("///InicioSesion");
            return false;
        });
    }

}