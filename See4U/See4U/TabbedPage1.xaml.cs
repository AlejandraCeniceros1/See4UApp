using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using See4U.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.ComponentModel;
using System;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace See4U.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : Xamarin.Forms.TabbedPage
    {
        public TabbedPage1()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetIsSmoothScrollEnabled(true);
        }
    }
}