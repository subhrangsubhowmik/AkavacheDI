using AkavacheDI.Contracts;
using AkavacheDI.IoC;
using AkavacheDI.ViewModels;
using AkavacheDI.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AkavacheDI.Services
{
    class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication => Application.Current;
        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }


        public async Task InitializeAsync()
        {
            await NavigateToAsync<LoginViewModel>();
            //if (_authenticationService.IsUserAuthenticated())
            //{
            //    await NavigateToAsync<MainViewModel>();
            //}
            //else
            //{
            //    await NavigateToAsync<LoginViewModel>();
            //}
        }

        public Task ClearBackStack()
        {
            throw new NotImplementedException();
        }

       
        public Task NavigateBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new NotImplementedException();
        }
        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(LoginViewModel), typeof(LoginPage));
            _mappings.Add(typeof(AboutViewModel), typeof(AboutPage));
            _mappings.Add(typeof(ItemDetailViewModel), typeof(ItemDetailPage));
            _mappings.Add(typeof(ItemsViewModel), typeof(ItemsPage));
            _mappings.Add(typeof(NewItemViewModel), typeof(NewItemPage));
         }
        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }
        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            BaseViewModel viewModel = ApplicationContainer.Resolve(viewModelType) as BaseViewModel;
            page.BindingContext = viewModel;

            return page;
        }
        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is LoginPage )//BA ABOUT US PAGE O HOTE PARE
            {
                Application.Current.MainPage = page;
            }
            //else if (page is LoginView)
            //{
            //    CurrentApplication.MainPage = page;
            //}
            else
            {
                var navigationPage = Application.Current.MainPage as AkavacheDIPage;
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    Application.Current.MainPage = new AkavacheDIPage(page);
                }
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);

            //else if (Application.Current.MainPage is MainView)
            //{
            //    var mainPage = Application.Current.MainPage as MainView;

            //    if (mainPage.Detail is BethanyNavigationPage navigationPage)
            //    {
            //        var currentPage = navigationPage.CurrentPage;

            //        if (currentPage.GetType() != page.GetType())
            //        {
            //            await navigationPage.PushAsync(page);
            //        }
            //    }
            //    else
            //    {
            //        navigationPage = new BethanyNavigationPage(page);
            //        mainPage.Detail = navigationPage;
            //    }

            //    mainPage.IsPresented = false;
            //}
            //else
            //{
            //    var navigationPage = Application.Current.MainPage as BethanyNavigationPage;

            //    if (navigationPage != null)
            //    {
            //        await navigationPage.PushAsync(page);
            //    }
            //    else
            //    {
            //        Application.Current.MainPage = new BethanyNavigationPage(page);
            //    }
            //}

            //await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }
    }
}
