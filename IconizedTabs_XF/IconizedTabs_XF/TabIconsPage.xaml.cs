using IconizedTabs_XF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IconizedTabs_XF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabIconsPage : ContentPage
    {
        public TabIconsPage()
        {
            InitializeComponent();

            BindingContext = new Tab1ViewModel()
            {
                IsSelected = true
            };
        }
    }
}