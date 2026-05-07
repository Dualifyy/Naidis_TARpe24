using System.Collections.ObjectModel;
using System.Linq;

namespace Naidis_TARpe24.EuroopaRiigid;

public partial class EuroopaPage : ContentPage
{
    ObservableCollection<Riik> riigid;
    Riik valitudRiik;
    public EuroopaPage()
	{
        InitializeComponent();

        riigid = new ObservableCollection<Riik>
        {
            new Riik { Nimi="Eesti", Pealinn="Tallinn", Rahvaarv=1330000, Lipp="estonia.png"},
            new Riik { Nimi="Soome", Pealinn="Helsingi", Rahvaarv=5500000, Lipp="finland.png"},
            new Riik { Nimi="Rootsi", Pealinn="Stockholm", Rahvaarv=10500000, Lipp="sweden.png"}
        };

        riigidListView.ItemsSource = riigid;
    }

    // ITEM TAPPED → popup + täitmine
    private async void RiikTapped(object sender, ItemTappedEventArgs e)
    {
        valitudRiik = e.Item as Riik;

        if (valitudRiik == null) return;

        await DisplayAlertAsync("Info",
            $"Riik: {valitudRiik.Nimi}\nPealinn: {valitudRiik.Pealinn}\nRahvaarv: {valitudRiik.Rahvaarv} inimest",
            "OK");

        // täidame väljad
        nimiEntry.Text = valitudRiik.Nimi;
        pealinnEntry.Text = valitudRiik.Pealinn;
        rahvaarvEntry.Text = valitudRiik.Rahvaarv.ToString();
        lippEntry.Text = valitudRiik.Lipp;
    }

    // LISAMINE
    private async void LisaNupp_Clicked(object sender, EventArgs e)
    {
        string uusNimi = nimiEntry.Text;

        bool olemas = riigid.Any(r =>
            r.Nimi.Equals(uusNimi, StringComparison.OrdinalIgnoreCase));

        if (olemas)
        {
            await DisplayAlertAsync("Viga", "See riik on juba olemas!", "OK");
            return;
        }

        riigid.Add(new Riik
        {
            Nimi = nimiEntry.Text,
            Pealinn = pealinnEntry.Text,
            Rahvaarv = int.Parse(rahvaarvEntry.Text),
            Lipp = lippEntry.Text
        });
    }

    // KUSTUTAMINE
    private void KustutaNupp_Clicked(object sender, EventArgs e)
    {
        if (valitudRiik != null)
        {
            riigid.Remove(valitudRiik);
            valitudRiik = null;
        }
    }

    // MUUTMINE
    private void SalvestaNupp_Clicked(object sender, EventArgs e)
    {
        if (valitudRiik == null) return;

        valitudRiik.Nimi = nimiEntry.Text;
        valitudRiik.Pealinn = pealinnEntry.Text;
        valitudRiik.Rahvaarv = int.Parse(rahvaarvEntry.Text);
        valitudRiik.Lipp = lippEntry.Text;
    }
}