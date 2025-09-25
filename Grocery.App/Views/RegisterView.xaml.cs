using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
	private async void OnBackToLoginClicked(object? sender, EventArgs e)
	{
		var vm = (RegisterViewModel)BindingContext;
		await vm.RegisterAsync();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}