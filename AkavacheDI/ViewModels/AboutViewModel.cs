using AkavacheDI.Contracts;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AkavacheDI.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}