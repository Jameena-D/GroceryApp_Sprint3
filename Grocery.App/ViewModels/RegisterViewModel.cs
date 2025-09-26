using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels;

public partial class RegisterViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    public RegisterViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty] string name;
    [ObservableProperty] string email;
    [ObservableProperty] string password;
    [ObservableProperty] string confirmPassword;

    [RelayCommand]
    public async Task RegisterAsync()
    {
        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            await Application.Current.MainPage.DisplayAlert("Fout", "Vull alee velden in.", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await Application.Current.MainPage.DisplayAlert("Fout", "Wahctwoord komt niet overeen.", "OK");
            return;
        }

        var client = _authService.Register(name, email, password);
        
        if (client != null)
        {
            await Application.Current.MainPage.DisplayAlert("Mislukt", "E-mailadres bestaat al.", "OK");
            return;
        }

        await Application.Current.MainPage.DisplayAlert("Succes", "Account aangemaakt. Je kan nu inloggen.", "Ok");
        await Application.Current.MainPage.Navigation.PopAsync();
    }

}
