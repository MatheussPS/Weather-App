using WeatherApp.ViewModels;

namespace WeatherApp.Views;

public partial class MainPageView : ContentPage
{
	public MainPageView()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
	}
}