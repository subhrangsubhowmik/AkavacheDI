using AkavacheDI.Contracts;
using AkavacheDI.Models;
using AkavacheDI.Services;
using AkavacheDI.ViewModels;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkavacheDI.IoC
{
    class ApplicationContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<AboutViewModel>();
            builder.RegisterType<ItemDetailViewModel>();
            builder.RegisterType<NewItemViewModel>();
            builder.RegisterType<ItemsViewModel>();
            //builder.RegisterType<ShoppingCartViewModel>().SingleInstance();


            //services - data

            //builder.RegisterType<OrderDataService>().As<IOrderDataService>();
            builder.RegisterType<MockDataStore>().As<IDataStore<Item>>();//BUT ETA ERKOM HOBE NA , FOR DIFF MODEL DIFF IDataService THAKBE

            //services - general
            builder.RegisterType<NavigationService>().As<INavigationService>();


            //General
            //builder.RegisterType<GenericRepository>().As<IGenericRepository>();//MockDataStore

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
