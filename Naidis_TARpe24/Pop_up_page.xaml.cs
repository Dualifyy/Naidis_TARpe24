
using System.Threading.Tasks;

namespace Naidis_TARpe24;

public partial class Pop_up_page : ContentPage
{
	public Pop_up_page()
	{
		Button alertButton = new Button
		{
			Text = "Teade",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
		alertButton.Clicked += AlertButton_Clicked;

		Button alertYesNoButton = new Button
		{
			Text = "Jah või ei",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
		alertYesNoButton.Clicked += AlertYesNoButton_Clicked;

		Button alertListButton = new Button
		{
			Text = "Valik",
			VerticalOptions = LayoutOptions.Start,
			HorizontalOptions = LayoutOptions.Center
		};
        alertListButton.Clicked += AlertListButton_Clicked;

		Content = new VerticalStackLayout
		{
			Spacing = 20,
			Padding = new Thickness(0, 50, 0, 0),
			Children = { alertButton, alertYesNoButton, alertListButton }
		};
	}


    private async void AlertYesNoButton_Clicked(object? sender, EventArgs e)
    {
		bool result = await DisplayAlertAsync("Kinnitus", "Kas oled kindel?", "Olen kindel", "Ei ole kindel");

		await DisplayAlertAsync("Teade", "Teie valik on: " + (result ? "Jah" : "Ei"), "OK");
    }

    private async void AlertButton_Clicked(object? sender, EventArgs e)
    {
		await DisplayAlertAsync("Teade", "Teil on uus teade", "OK");
    }
	
	private async void AlertListButton_Clicked(object? sender, EventArgs e)
	{

	}
}