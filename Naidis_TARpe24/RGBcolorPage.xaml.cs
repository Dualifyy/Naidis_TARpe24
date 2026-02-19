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
        BoxView boxView = new BoxView
        {

        };
        stepper = new Stepper
        {
            Minimum = 0,
            Maximum = 360,
            Increment = 5,
            Value = 50,
            HorizontalOptions = LayoutOptions.Center
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