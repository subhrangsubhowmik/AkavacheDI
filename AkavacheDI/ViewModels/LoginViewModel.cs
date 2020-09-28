using AkavacheDI.Contracts;
using AkavacheDI.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AkavacheDI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        //public Command LoginCommand { get; }

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
        public ICommand LoginCommand => new Command(OnLoginClicked);
        //LoginCommand = new Command(OnLoginClicked);
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            await _navigationService.NavigateToAsync<AboutViewModel>();
        }
    }
}
