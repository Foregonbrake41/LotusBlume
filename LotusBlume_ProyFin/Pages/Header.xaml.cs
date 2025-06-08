namespace LotusBlume_ProyFin.Pages;

public partial class Header : ContentPage
{
	public Header()
	{
		InitializeComponent();
	}

    private async void ClickedPrincipal(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Principal");
    }
}