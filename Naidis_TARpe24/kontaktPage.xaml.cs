namespace Naidis_TARpe24;

public partial class kontaktPage : ContentPage
{
    Entry email_phone;
    Entry message;
    Label label;
    Label s6numLabel;
    List<string> To;
    Button buttonSms;
    Button buttonEmail;
    public kontaktPage()
    {
        label = new Label
        {
            Text = "Sisesta oma kontaktandmed"
        };
        email_phone = new Entry
        {
            Placeholder = "Email or phone number",
            Keyboard = Keyboard.Default
        };
        s6numLabel = new Label
        {
            Text = "Sisesta oma sõnum siia"
        };
        message = new Entry
        {
            Placeholder = "Tere maailm!",
            Keyboard = Keyboard.Default
        };

        Button buttonSms = new Button
        {
            Text = "Saada SMS",
            FontSize = 18,
            BackgroundColor = Colors.Black,
            TextColor = Colors.Red
        };
        buttonSms.Clicked += Saada_sms_Clicked;

        Button buttonEmail = new Button
        {
            Text = "Saada Meil",
            FontSize = 18,
            BackgroundColor = Colors.Black,
            TextColor = Colors.Red
        };
        buttonEmail.Clicked += Saada_email_Clicked;

        Content = new VerticalStackLayout
        {
            Spacing = 22,
            Children =
            {
                new Label
                {
                    Text = "Kontaktid",
                    FontSize = 28,
                    HorizontalOptions = LayoutOptions.Center
                },
                label,
                email_phone,
                s6numLabel,
                message,
                buttonSms,
                buttonEmail
            }
        };
	}
    private async void Saada_sms_Clicked(object? sender, EventArgs e)
    {
        string phone = email_phone.Text;
        var message = "Tere tulemast! Saadan sõnumi";
        SmsMessage sms = new SmsMessage(message, phone);
        if (phone != null && Sms.Default.IsComposeSupported)
        {
            await Sms.Default.ComposeAsync(sms);
        }
    }
    private async void Saada_email_Clicked(object? sender, EventArgs e)
    {
        var message = "Tere tulemast! Saada email";
        EmailMessage e_mail = new EmailMessage
        {
            Subject = email_phone.Text,
            Body = message,
            BodyFormat = EmailBodyFormat.PlainText,
            To = new List<string>(new[] { email_phone.Text })
        };
        if (Email.Default.IsComposeSupported)
        {
            await Email.Default.ComposeAsync(e_mail);
        }
        else
    	{
    		await DisplayAlertAsync("Viga", "E-maili saatmine pole selles seadmes toetatud", "OK");
    	}
    }
}