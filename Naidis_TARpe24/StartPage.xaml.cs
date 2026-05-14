using Naidis_TARpe24.TTTViews;
using Naidis_TARpe24.EuroopaRiigid;
namespace Naidis_TARpe24;

public partial class StartPage : ContentPage
{
	VerticalStackLayout vst;
	ScrollView sv;
	public List<ContentPage> Lehed = new List<ContentPage>() { new TextPage(), new FigurePage(), new DateTime_Page(), new StepperSliderPage(), new RGBcolorPage(), new LumememmPage(), new Pop_up_page(), new MoistatusPage(), new PickerImageGridPage(), new TripsTrapsTrullPage(), new TripsTrapsTrullInfoPage(), new TableView_Page(), new kontaktPage(), new EuroopaPage(), new KarussellPage(), new PrograPortfoolio()};
	public List<string> LeheNimed = new List<string> { "Tekst", "Kujund", "Kellaaeg", "Slaiderid", "RGB", "Lumememm", "Pop up page", "Moistatused", "Grid leht", "Trips Traps Trull", "TTT INFO LEHT", "Tabelivaade", "Kontaktileht", "Euroopa riigid", "Karusell", "Progra keeled" };

	public StartPage()
	{
		//InitializeComponent();
		//Title = "Avaleht";
		vst = new VerticalStackLayout { Padding = 20, Spacing = 15 };
		for (int i = 0; i < Lehed.Count; i++)
		{
			Button nupp = new Button
			{
				Text = LeheNimed[i],
				FontSize = 36,
				BackgroundColor = Color.FromRgb(100, 200, 100),
				TextColor = Color.FromRgb(10, 20, 15),
				FontFamily = "MMudah",
				CornerRadius = 10,
				HeightRequest = 60,
				ZIndex = i
			};
			vst.Add(nupp);
			nupp.Clicked += (sender, e) =>
			{
				var valik = Lehed[nupp.ZIndex];
				Navigation.PushAsync(valik);
			};
		}
		Button nulliNupp = new Button
		{
			Text = "Nulli seaded (Testsimiseks)",
			BackgroundColor = Colors.Red,
			TextColor = Colors.White,
			CornerRadius = 10,
			HeightRequest = 50,
			Margin = new Thickness(0, 30, 0, 0)
		};

		nulliNupp.Clicked += async (sender, e) =>
		{
			Preferences.Default.Remove("EsimeneKäivitamine");
			await DisplayAlertAsync("Edukalt nullitud", "Mälu on tühjendatud. Kui sa lehe uuesti avad, käivitub äpp nagu täiesti uus!", "OK");
		};
		vst.Add(nulliNupp);
		sv = new ScrollView { Content = vst };
		Content = sv;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		bool onEsimeneStart = Preferences.Default.Get("EsimeneKäivitamine", true);

		if (onEsimeneStart)
		{
			bool vastus = await DisplayAlertAsync("Tere tulemast!",
				"Tundub, et avasid selle rakenduse esimest korda. Kas sa soovid näha" +
				"lühikest juhendit?",
				"Jah, palun",
				"Ei, saan ise hakkama");

			if (vastus)
			{
				await DisplayAlertAsync("Juhend",
					"Siin on sinu lühike juhend: vali menüüst sobiv teema ja uuri, kuidas elemendid töötavad!",
					"Selge");
			}

			Preferences.Default.Set("EsimeneKäivitamine", false);
		}
	}
}