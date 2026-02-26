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

    BoxView redBox;
    BoxView greenBox;
    BoxView blueBox;

    public RGBcolorPage()
    {
        redLabel = new Label { Text = "Red = 00" };
        greenLabel = new Label { Text = "Green = 00" };
        blueLabel = new Label { Text = "Blue = 00" };

        redSlider = new Slider { Minimum = 0, Maximum = 255 };
        redSlider.ValueChanged += OnSliderValueChanged;

        greenSlider = new Slider { Minimum = 0, Maximum = 255 };
        greenSlider.ValueChanged += OnSliderValueChanged;

        blueSlider = new Slider { Minimum = 0, Maximum = 255 };
        blueSlider.ValueChanged += OnSliderValueChanged;

        // Väikesed ruudud
        redBox = new BoxView { HeightRequest = 60, WidthRequest = 60 };
        greenBox = new BoxView { HeightRequest = 60, WidthRequest = 60 };
        blueBox = new BoxView { HeightRequest = 60, WidthRequest = 60 };

        // Suur ruut
        boxView = new BoxView
        {
            HeightRequest = 250,
            WidthRequest = 250,
            HorizontalOptions = LayoutOptions.Center
        };

        stepper = new Stepper
        {
            Minimum = 100,
            Maximum = 400,
            Increment = 25,
            Value = 250,
            HorizontalOptions = LayoutOptions.Center
        };
        stepper.ValueChanged += OnStepperValueChanged;

        Content = new StackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children =
            {
                new HorizontalStackLayout
                {
                    HorizontalOptions = LayoutOptions.Center,
                    Spacing = 15,
                    Children =
                    {
                        redBox,
                        greenBox,
                        blueBox
                    }
                },

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
        redLabel.Text = $"Red = {(int)redSlider.Value:X2}";
        greenLabel.Text = $"Green = {(int)greenSlider.Value:X2}";
        blueLabel.Text = $"Blue = {(int)blueSlider.Value:X2}";

        redBox.Color = Color.FromRgb((int)redSlider.Value, 0, 0);
        greenBox.Color = Color.FromRgb(0, (int)greenSlider.Value, 0);
        blueBox.Color = Color.FromRgb(0, 0, (int)blueSlider.Value);

        boxView.Color = Color.FromRgb(
            (int)redSlider.Value,
            (int)greenSlider.Value,
            (int)blueSlider.Value);
    }

    void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        boxView.WidthRequest = e.NewValue;
        boxView.HeightRequest = e.NewValue;
    }
}