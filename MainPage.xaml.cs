using ProyectoP2Final.ViewModels;

namespace ProyectoP2Final;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=viewModel;
	}

}

