namespace Naidis_TARpe24;

public class CarouselProgra
{
	public string Title { get; set; }
	public string ImageUrl { get; set; }
	public string TextBoxHelloWorld { get; set; }
}
public partial class PrograPortfoolio : ContentPage
{
	private CarouselView carouselProgra;
	private List<CarouselItem> items;
	private int position = 0;
	public PrograPortfoolio()
	{
		Title = "Karuselli näide";

		var items = new List<CarouselProgra>
		{
			new CarouselProgra { Title = "Rust", ImageUrl = "https://rust-on-nails.com/blog/rust-complicated/rust.jpg", TextBoxHelloWorld = "\"\"\r\nfn main() {\r\n println!(\"Hello, World!\");\r\n}\r\n\"\""},
			new CarouselProgra { Title = "Assembly", ImageUrl = "https://media.licdn.com/dms/image/v2/D4D12AQEM9F_-u1OT5Q/article-cover_image-shrink_600_2000/article-cover_image-shrink_600_2000/0/1658763190886?e=2147483647&v=beta&t=aEp72fzTRZC_0EilFbT0wVV2jw6O-Bqt759qLG4pLrw", TextBoxHelloWorld = "\"\"\r\n section .data\r\n msg db \"Hello, World!\", 10\r\n msg_len equ $ - msg\r\n\r\n section .text\r\n global _start\r\n\r\n _start:\r\n mov rax, 1\r\n mov rdi, 1\r\n mov rsi, msg\r\n mov rdx, msg_len\r\n syscall\r\n\r\n mov rax, 60\r\n mov rdi, 0\r\n syscall\r\n  \"\""},
            new CarouselProgra { Title = "C++", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/ISO_C%2B%2B_Logo.svg/1280px-ISO_C%2B%2B_Logo.svg.png", TextBoxHelloWorld = "\"\"\r\n#include <iostream>\r\n\r\n int main() {\r\n std::cout << \"Hello, World!\" << std::endl;\r\n return 0;\r\n }\r\n \"\""},
            new CarouselProgra { Title = "C", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/C_Programming_Language.svg/960px-C_Programming_Language.svg.png?utm_source=commons.wikimedia.org&utm_campaign=index&utm_content=thumbnail", TextBoxHelloWorld = "\"\"\r\n #include <stdio.h>\r\n\r\n int main() {\r\n printf(\"Hello, World!\\n\");\r\n return 0;\r\n }\r\n \"\""},
            new CarouselProgra { Title = "HolyC", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/HolyC_Logo.svg/1920px-HolyC_Logo.svg.png?utm_source=commons.wikimedia.org&utm_campaign=index&utm_content=thumbnail", TextBoxHelloWorld = "\"\"\r\n U0 HelloWorld()\r\n {\r\n \"Hello, World!\\n\";\r\n }\r\n HelloWorld;\r\n \"\""},
        };
		var carouselProgra = new CarouselView
		{
			ItemsSource = items,
			HeightRequest = 300,
			IsBounceEnabled = true
		};

		carouselProgra.ItemTemplate = new DataTemplate(() =>
		{
			var frame = new Frame
			{
				CornerRadius = 20,
				HasShadow = true,
				Padding = 0,
				Margin = new Thickness(10),
				BackgroundColor = Colors.Transparent
			};

			var grid = new Grid();

			var image = new Image
			{
				Aspect = Aspect.AspectFill
			};

			image.SetBinding(Image.SourceProperty, "ImageUrl");

			var gradient = new BoxView
			{
				Background = new LinearGradientBrush
				{
					StartPoint = new Point(0, 1),
					EndPoint = new Point(0, 0),
					GradientStops = new GradientStopCollection
					{
						new GradientStop(Colors.Black.WithAlpha(0.6f), 0),
						new GradientStop(Colors.Transparent, 1)
					}
				},
				Opacity = 0.7
			};
			var label = new Label
			{
				TextColor = Colors.White,
				FontSize = 24,
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Start
			};
			label.SetBinding(Label.TextProperty, "Title");

			var tap = new TapGestureRecognizer();
			tap.Tapped += async (s, e) =>
			{
				var tappedItem = ((Frame)s).BindingContext as CarouselProgra;
				await DisplayAlertAsync("Kuidas kirjutada tere maailm?", tappedItem?.TextBoxHelloWorld ?? "Pole olemas", "OK");
			};
			frame.GestureRecognizers.Add(tap);

			grid.Children.Add(image);
			grid.Children.Add(gradient);
			grid.Children.Add(label);

			frame.Content = grid;
			return frame;
		});

		var indicatorView = new IndicatorView
		{
			IndicatorColor = Colors.Gray,
			SelectedIndicatorColor = Colors.Blue,
			HorizontalOptions = LayoutOptions.Center,
			Margin = new Thickness(0, 10)
		};
		carouselProgra.IndicatorView = indicatorView;

		Device.StartTimer(TimeSpan.FromSeconds(4), () =>
		{
			if (items.Count == 0)
				return false;

			position = (position + 1) % items.Count;
			carouselProgra.Position = position;

			return true; //timer laheb edasi
		});
		Content = new StackLayout
		{
			Padding = 20,
			Children =
			{
				carouselProgra,
				indicatorView
			}
		};
	}
}