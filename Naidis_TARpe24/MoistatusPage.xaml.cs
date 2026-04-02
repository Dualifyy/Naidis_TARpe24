namespace Naidis_TARpe24;

public partial class MoistatusPage : ContentPage
{
    public MoistatusPage()
    {
        Button startGameButton = new Button
        {
            Text = "Alusta mõistatuste mängu",
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };

        startGameButton.Clicked += StartGame_Clicked;

        Content = new VerticalStackLayout
        {
            Spacing = 20,
            Padding = new Thickness(0, 50, 0, 0),
            Children = { startGameButton }
        };
    }

    private async void StartGame_Clicked(object? sender, EventArgs e)
    {
        await StartGame();
    }

    private async Task StartGame()
    {
        // 1
        await DisplayAlert("Esimene mõistatus",
            "Mõista mõista mis see on:\n\npaks kui lehm ja sünnitas sind",
            "OK");

        string vastus = await DisplayActionSheetAsync(
            "Vali vastus",
            "Cancel",
            null,
            "Su ema", "Su isa", "Sina ise");

        if (vastus != "Su ema")
        {
            await GameOver();
            return;
        }

        // 2
        await DisplayAlert("Teine mõistatus",
            "Mõista mõista mis see on:\n\nühel emal seitse last",
            "OK");

        vastus = await DisplayActionSheetAsync(
            "Vali vastus",
            "Cancel",
            null,
            "Kärgpere", "7 põialpoissi", "Nädal");

        if (vastus != "Nädal")
        {
            await GameOver();
            return;
        }

        // 3
        await DisplayAlert("Kolmas mõistatus",
            "Mõista mõista mis see on:\n\nMagusam kui mesi, tugevam kui lõvi",
            "OK");

        vastus = await DisplayActionSheetAsync(
            "Vali vastus",
            "Cancel",
            null,
            "Uni", "Fentanüül", "Georg Teemus");

        if (vastus != "Uni")
        {
            await GameOver();
            return;
        }

        // 4
        await DisplayAlert("Neljas mõistatus",
            "Mõista mõista mis see on:\n\nEi ole toas ega õues",
            "OK");

        vastus = await DisplayActionSheetAsync(
            "Vali vastus",
            "Cancel",
            null,
            "Ukselink", "Aken", "Lukk");

        if (vastus != "Aken")
        {
            await GameOver();
            return;
        }

        bool restart = await DisplayAlert(
            "Palju õnne!",
            "Sa vastasid kõigile õigesti!",
            "Alusta uuesti",
            "Tagasi");

        if (restart)
            await StartGame();
        else
            await Navigation.PopAsync();
    }
    //said üle
    private async Task GameOver()
    {
        bool restart = await DisplayAlert(
            "Game Over",
            "Vale vastus!",
            "Proovi uuesti",
            "Tagasi");

        if (restart)
            await StartGame();
        else
            await Navigation.PopAsync();
    }
}