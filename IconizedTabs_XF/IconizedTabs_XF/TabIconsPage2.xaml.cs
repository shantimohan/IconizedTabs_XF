﻿using IconizedTabs_XF.ViewModels;
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
    public partial class TabIconsPage2 : ContentPage
    {
        public TabIconsPage2()
        {
            InitializeComponent();

            BindingContext = new Tab2ViewModel();
        }
    }
}