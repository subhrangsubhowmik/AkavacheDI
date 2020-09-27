using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AkavacheDI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AkavacheDIPage : NavigationPage
    {
        public AkavacheDIPage() : base()
        {
            InitializeComponent();
        }

        public AkavacheDIPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}