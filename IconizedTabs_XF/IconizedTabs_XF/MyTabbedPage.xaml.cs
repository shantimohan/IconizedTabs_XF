using IconizedTabs_XF.Interfaces;
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
    public partial class MyTabbedPage : TabbedPage
    {
        Page currentPage;

        public event EventHandler UpdateIcons;

        public MyTabbedPage()
        {
            InitializeComponent();

            Children.Add(new TabIconsPage()
            {

            });

            Children.Add(new TabIconsPage2()
            {

            });

            currentPage = Children[0];
            this.CurrentPageChanged += MyTabbedPage_CurrentPageChanged;
        }

        private void MyTabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            var currentBinding = currentPage.BindingContext as IIconChange;
            if (currentBinding != null)
                currentBinding.IsSelected = false;

            currentPage = CurrentPage;
            currentBinding = currentPage.BindingContext as IIconChange;
            if (currentBinding != null)
                currentBinding.IsSelected = true;

            UpdateIcons?.Invoke(this, EventArgs.Empty);
        }
    }
}