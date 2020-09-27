using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AkavacheDI.Models;
using AkavacheDI.ViewModels;

namespace AkavacheDI.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            //BindingContext = new NewItemViewModel();
        }
    }
}