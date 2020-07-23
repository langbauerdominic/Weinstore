using System;
using System.Linq;
using Xamarin.Forms;
using XamarinFirebase.Helper;
using XamarinFirebase.Model;
using Firebase;

namespace Weinstore
{
    public partial class HomePage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public HomePage()
        {
            InitializeComponent();
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            App.Current.MainPage = new LoginPage();
            //Navigation.InsertPageBefore(new LoginPage(), this);
            //await Navigation.PopAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {

            await firebaseHelper.DeletePerson(Constants.Username);
            await DisplayAlert("Success", "Person Deleted Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;

        }
    }
}
