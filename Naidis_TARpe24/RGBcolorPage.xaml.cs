using Microsoft.Maui.Controls;

namespace Naidis_TARpe24;

public partial class RGBcolorPage : ContentPage
{
	Label redLabel;
    Label blueLabel;
    Label greenLabel;
	Stepper stepper;
	Slider redSlider;
    Slider blueSlider;
    Slider greenSlider;
    BoxView boxView;
    public RGBcolorPage()
    {
        redLabel = new Label { Text = "Red = 00" };
        greenLabel = new Label { Text = "Green = 00" };
        blueLabel = new Label { Text = "Blue = 00" };

        redSlider = new Slider
        {
            Minimum = 0,
            Maximum = 255
        };
        redSlider.ValueChanged += OnSliderValueChanged;

        greenSlider = new Slider
        {
            Minimum = 0,
            Maximum = 255
        };
        greenSlider.ValueChanged += OnSliderValueChanged;

        blueSlider = new Slider
        {
            Minimum = 0,
            Maximum = 255
        };
        blueSlider.ValueChanged += OnSliderValueChanged;

        boxView = new BoxView
        {
            HeightRequest = 150,
            WidthRequest = 150,
            HorizontalOptions = LayoutOptions.Center
        };

        stepper = new Stepper
        {
            Minimum = 0,
            Maximum = 360,
            Increment = 5,
            Value = 50,
            HorizontalOptions = LayoutOptions.Center
        };

        Content = new StackLayout
        {
            Padding = 20,
            Children =
        {
            redLabel,
            redSlider,
            greenLabel,
            greenSlider,
            blueLabel,
            blueSlider,
            boxView,
            stepper
        }
        };
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (sender == redSlider)
        {
            redLabel.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
        }
        else if (sender == greenSlider)
        {
            greenLabel.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
        }
        else if (sender == blueSlider)
        {
            blueLabel.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
        }
        boxView.Color = Color.FromRgb((int)redSlider.Value,
            (int)greenSlider.Value,
            (int)blueSlider.Value);
    }
}