using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AkavacheDI.Services;
using AkavacheDI.Views;
using System.Threading.Tasks;
using AkavacheDI.Contracts;
using AkavacheDI.IoC;
using AkavacheDI.ViewModels;

namespace AkavacheDI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            InitializeApp();
            InitializeNavigation();
            //DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
        }

        private async Task InitializeNavigation()
        {
            var navigationService = ApplicationContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        private void InitializeApp()
        {
            ApplicationContainer.RegisterDependencies();

            var loginViewModel = ApplicationContainer.Resolve<LoginViewModel>();
            //loginViewModel.InitializeMessenger();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
