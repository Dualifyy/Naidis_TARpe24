namespace Naidis_TARpe24;

public partial class LumememmPage : ContentPage
{
    Random rnd = new Random();
    public LumememmPage()
	{
		InitializeComponent();
	}
    private async void OnActionClicked(object sender, EventArgs e)
    {
        if (ActionPicker.SelectedItem == null)
            return;

        string action = ActionPicker.SelectedItem.ToString();
        ResultLabel.Text = "Valitud tegevus: " + action;

        uint speed = (uint)SpeedStepper.Value;

        switch (action)
        {
            case "Peida":
                Body.IsVisible = false;
                Head.IsVisible = false;
                Hat.IsVisible = false;
                break;

            case "Näita":
                Body.IsVisible = true;
                Head.IsVisible = true;
                Hat.IsVisible = true;
                Body.Opacity = 1;
                Head.Opacity = 1;
                Hat.Opacity = 1;
                break;

            case "Muuda värvi":
                bool confirm = await DisplayAlert("Värv",
                    "Kas muuta lumememme värvi?",
                    "Jah", "Ei");

                if (confirm)
                {
                    Color randomColor = Color.FromRgb(
                        rnd.Next(256),
                        rnd.Next(256),
                        rnd.Next(256));

                    Body.BackgroundColor = randomColor;
                    Head.BackgroundColor = randomColor;
                }
                break;

            case "Sulata":
                await Body.ScaleTo(0.5, speed);
                await Head.ScaleTo(0.5, speed);
                await Hat.ScaleTo(0.5, speed);

                await Body.FadeTo(0, speed);
                await Head.FadeTo(0, speed);
                await Hat.FadeTo(0, speed);
                break;

            case "Tantsi":
                for (int i = 0; i < 3; i++)
                {
                    await Body.TranslateTo(-50, 0, speed);
                    await Head.TranslateTo(-50, 0, speed);
                    await Hat.TranslateTo(-50, 0, speed);

                    await Body.TranslateTo(50, 0, speed);
                    await Head.TranslateTo(50, 0, speed);
                    await Hat.TranslateTo(50, 0, speed);
                }

                await Body.TranslateTo(0, 0);
                await Head.TranslateTo(0, 0);
                await Hat.TranslateTo(0, 0);
                break;
        }
    }

    private void OnSliderChanged(object sender, ValueChangedEventArgs e)
    {
        Body.Opacity = e.NewValue;
        Head.Opacity = e.NewValue;
        Hat.Opacity = e.NewValue;
    }
}