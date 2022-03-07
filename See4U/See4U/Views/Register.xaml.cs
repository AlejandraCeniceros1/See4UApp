using System;
using System.Collections.Generic;
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


namespace See4U
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public string WebApiKey = "AIzaSyDE2AJ4IGsNc_D2q7IHX6Blcmo7PIztGw8";

        public Register()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(txtUsername.Text, txtPassword.Text);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert", gettoken, "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }
            //
            

        }
        /*
        var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
        var db = new SQLiteConnection(dbpath);
        db.CreateTable<RegisterUserTab>();

        var item = new RegisterUserTab()
        {
            UserName = txtUsername.Text,
            Password = txtPassword.Text,
            Email = EntryUserEmail.Text,
            FirstName = EntryName.Text,
        };

        db.Insert(item);
        Device.BeginInvokeOnMainThread(async () =>
           {
               var result = await this.DisplayAlert("Welcome", "UserRegistrationSuccesfull", "Yes", "Cancel");

               if (result)
                   await Navigation.PushAsync(new Pantalla1());

           });
        */
        // Navigation.PushAsync(new Pantalla1());
    }
}
