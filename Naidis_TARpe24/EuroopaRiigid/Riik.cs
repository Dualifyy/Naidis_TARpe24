using System.ComponentModel;

public class Riik : INotifyPropertyChanged
{
    private string nimi;
    private string pealinn;
    private int rahvaarv;
    private string lipp;

    public string Nimi
    {
        get => nimi;
        set { nimi = value; OnPropertyChanged(nameof(Nimi)); }
    }

    public string Pealinn
    {
        get => pealinn;
        set { pealinn = value; OnPropertyChanged(nameof(Pealinn)); }
    }

    public int Rahvaarv
    {
        get => rahvaarv;
        set { rahvaarv = value; OnPropertyChanged(nameof(Rahvaarv)); }
    }

    public string Lipp
    {
        get => lipp;
        set { lipp = value; OnPropertyChanged(nameof(Lipp)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string nimi)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nimi));
    }
}