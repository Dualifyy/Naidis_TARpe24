namespace Naidis_TARpe24;

public partial class TextPage : ContentPage
{
	Label lbl;
	Editor editor;
	HorizontalStackLayout hsl;
	List<string> nupud = new List<string> { "Tagasi", "Avaleht", "Edasi" };
	VerticalStackLayout vsl;
	public TextPage()
	{
		//InitializeComponent();
		lbl = new Label
		{
			Text = "Pealkiri",
			TextColor = Color.FromRgb(100, 10, 10),
			FontFamily = "MMudah",
			FontAttributes = FontAttributes.Bold,
			TextDecorations = TextDecorations.Underline,
			HorizontalTextAlignment = TextAlignment.Center,
			VerticalTextAlignment = TextAlignment.Center,
			FontSize = 28
		};
		editor = new Editor
		{
			Placeholder = "Vihje:Sisesta siia tekst",
			PlaceholderColor = Color.FromRgb(100, 10, 10),
			TextColor = Color.FromRgb(200, 200, 100),
			BackgroundColor = Color.FromRgb(100, 50, 200),
			FontSize = 28,
			FontAttributes = FontAttributes.Italic
		};
		editor.TextChanged += (sender, e) =>
		{
			lbl.Text = editor.Text;
		};
		hsl = new HorizontalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };
		for (int j = 0; j < nupud.Count; j++)
		{
			Button nupp = new Button
			{
				Text = nupud[j],
				FontSize = 28,
				FontFamily = "MMudah",
				TextColor = Colors.BlueViolet,
				BackgroundColor = Colors.LightGray,
				CornerRadius = 10,
				HeightRequest = 50,
				ZIndex = j
			};
			hsl.Add(nupp);
            nupp.Clicked += Liikumine;
		}
		vsl = new VerticalStackLayout
		{
			Padding = 20,
			Spacing = 15,
			Children = { lbl, editor, hsl },
			HorizontalOptions = LayoutOptions.Center
		};
		Content = vsl;
	}

    private void Liikumine(object? sender, EventArgs e)
    {
		Button nupp = sender as Button;
		if(nupp.ZIndex == 0)
		{
			Navigation.PopAsync();
		}
		else if (nupp.ZIndex == 1)
		{
			Navigation.PopToRootAsync();
		}
		else if (nupp.ZIndex == 2)
		{
			Navigation.PushAsync(new FigurePage());
		}
    }
}