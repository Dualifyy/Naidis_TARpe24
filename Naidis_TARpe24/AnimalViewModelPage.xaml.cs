using Naidis_TARpe24.Services;

namespace Naidis_TARpe24;

public partial class AnimalViewModelPage : ContentPage
{
	AnimalViewModel vm = new AnimalViewModel();
	public AnimalViewModelPage()
	{
		InitializeComponent();
		BindingContext = vm;
	}
    private void OnDogClicked(object sender, EventArgs e) => vm.ChangeAnimal("Dog");
    private void OnFishClicked(object sender, EventArgs e) => vm.ChangeAnimal("Fish");
}