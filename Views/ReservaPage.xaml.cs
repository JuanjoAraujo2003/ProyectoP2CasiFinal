using ProyectoP2Final.ViewModels;
namespace ProyectoP2Final.Views;

public partial class ReservaPage : ContentPage
{
	public ReservaPage(ReservaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=viewModel;
	}
}