namespace Naidis_TARpe24.TTTViews;

public partial class TripsTrapsTrullInfoPage : ContentPage
{
	public TripsTrapsTrullInfoPage()
	{
		InitializeComponent();

	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        int xWins = Preferences.Get("xWins", 0);
        int oWins = Preferences.Get("oWins", 0);
        int draws = Preferences.Get("draws", 0);

        XWinsLabel.Text = $"X võidud: {xWins}";
        OWinsLabel.Text = $"O võidud: {oWins}";
        DrawsLabel.Text = $"Viigid: {draws}";
    }
}