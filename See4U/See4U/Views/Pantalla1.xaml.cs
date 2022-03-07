using System.Linq;
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

namespace See4U
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pantalla1 : ContentPage

    {
        public string WebApiKey  = "AIzaSyDE2AJ4IGsNc_D2q7IHX6Blcmo7PIztGw8";


        public Pantalla1()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();

        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(txtUsername.Text, txtPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await Navigation.PushAsync(new Views.TabbedPage1());
            }
            catch (Exception )
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid email or password", "OK");
            }

        }
            /*
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegisterUserTab>().Where(u => u.UserName.Equals(txtUsername.Text) && u.Password.Equals(txtPassword.Text)).FirstOrDefault();


            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new Home());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Failed UserName or Password", "Yes", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new Pantalla1());

                    else
                    {
                        await Navigation.PushAsync(new Pantalla1());

                    }


                });

            }

        } */

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           
            Navigation.PushAsync(new Register());

        }
    }
}