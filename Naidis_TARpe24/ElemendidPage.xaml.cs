using System.Collections.Generic;
using System.Collections.ObjectModel;
using static Naidis_TARpe24.ElemendidPage;

namespace Naidis_TARpe24;

public partial class ElemendidPage : ContentPage
{
	public static ObservableCollection<Telefon> telefons { get; set; }
    public class Telefon
    {
        public string Nimetus { get; set; }
        public string Tootja { get; set; }
        public int Hind { get; set; }
        public string Pilt { get; set; }
    }
    public ElemendidPage()
	{
		string[] phones = new string[] { "iPhone 7", "Samsung Galaxy S8", "Huawei P10", "LG G6" };
		ListView listView = new ListView();

		listView.ItemsSource = phones;
		telefons = new ObservableCollection<Telefon>
		{
			new Telefon { Nimetus =	"Samsung Galaxy S22 Ultra", Tootja= "Samsung", Hind= 1349, Pilt= "Galaxy.png" },
			new Telefon { Nimetus =	"Xiaomi Mi 11 Lite 5G NE", Tootja= "Xiaomi", Hind= 399, Pilt= "Xiaomi5GNE.png" },
			new Telefon { Nimetus = "iPhone 13 mini", Tootja = "Apple", Hind = 1179, Pilt = "iPhone13.png" }
		};
        // Seome sündmuse ListView-ga
        list.ItemTapped += List_ItemTapped;
    }
    ListView list = new ListView
    {
        HasUnevenRows = true, // Lubab ridadel olla erineva kõrgusega
        ItemsSource = telefons,
        ItemTemplate = new DataTemplate(() =>
        {
            Label nimetus = new Label { FontSize = 20 };
            nimetus.SetBinding(Label.TextProperty, "Nimetus"); // Seome klassi omadusega "Nimetus"

            Label hind = new Label();
            hind.SetBinding(Label.TextProperty, "Hind");

            return new ViewCell  
            {
                View = new StackLayout
                {
                    Padding = new Thickness(0, 5),
                    Orientation = StackOrientation.Vertical,
                    Children = { nimetus, hind }
                }
            };
        })
    };
    // Sündmuse töötleja (Event handler)
    private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        // Konverteerime valitud elemendi (e.Item) Telefon objektiks
        Telefon selectedPhone = e.Item as Telefon;

        // Kontrollime alati, kas konverteerimine õnnestus ega poleks null
        if (selectedPhone != null)
        {
            // Kuvame ekraanil hüpikakna
            await DisplayAlert("Valitud mudel", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "OK");
        }
    }
    private void Kustuta_Clicked(object sender, EventArgs e)
    {
        Telefon phone = list.SelectedItem as Telefon;

        if (phone != null)
        {
            telefons.Remove(phone);
            list.SelectedItem = null; // Tühistame valiku visuaalselt
        }
    }

}