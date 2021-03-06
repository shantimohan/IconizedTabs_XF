﻿using IconizedTabs_XF.Interfaces;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconizedTabs_XF.ViewModels
{
    class Tab1ViewModel : BaseViewModel, IIconChange
    {
        public Tab1ViewModel()
        {
            Title = "Tab1";
        }

        bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (SetProperty(ref isSelected, value))
                    OnPropertyChanged(nameof(CurrentIcon));
            }
        }
        public string CurrentIcon
        {
            get => IsSelected ? "tab_target.png" : "tab_chat.png";
        }
    }
}
