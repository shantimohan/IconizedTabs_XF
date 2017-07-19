using System;
using System.IO;
using System.Linq;
using Android.Support.Design.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using IconizedTabs_XF;
using IconizedTabs_XF.Droid;
using IconizedTabs_XF.Interfaces;

[assembly: ExportRenderer(typeof(MyTabbedPage), typeof(MyTabsRenderer))]
namespace IconizedTabs_XF.Droid
{
    public class MyTabsRenderer : TabbedPageRenderer
    {
        //bool setup;
        TabLayout layout;
        public MyTabsRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            if (Element != null)
            {
                ((MyTabbedPage)Element).UpdateIcons += Handle_UpdateIcons;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);


            if (layout == null && e.PropertyName == "Renderer")
            {
                layout = (TabLayout)ViewGroup.GetChildAt(1);
            }
        }

        void Handle_UpdateIcons(object sender, EventArgs e)
        {
            TabLayout tabs = layout;

            if (tabs == null)
                return;

            for (var i = 0; i < Element.Children.Count; i++)
            {
                var child = Element.Children[i].BindingContext as IIconChange;
                var icon = child.CurrentIcon;
                if (string.IsNullOrEmpty(icon))
                    continue;

                TabLayout.Tab tab = tabs.GetTabAt(i);
                SetCurrentTabIcon(tab, icon);
            }
        }

        void SetCurrentTabIcon(TabLayout.Tab tab, string icon)
        {
            tab.SetIcon(IdFromTitle(icon, ResourceManager.DrawableClass));
        }

        int IdFromTitle(string title, Type type)
        {
            string name = Path.GetFileNameWithoutExtension(title);
            int id = GetId(type, name);
            return id;
        }

        int GetId(Type type, string memberName)
        {
            object value = type.GetFields().FirstOrDefault(p => p.Name == memberName)?.GetValue(type)
                ?? type.GetProperties().FirstOrDefault(p => p.Name == memberName)?.GetValue(type);
            if (value is int)
                return (int)value;
            return 0;
        }
    }
}