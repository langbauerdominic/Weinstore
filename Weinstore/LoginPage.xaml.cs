using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Weinstore
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new SignUpPage();
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                App.Current.MainPage = new MainPage();
                //Navigation.InsertPageBefore(new MainPage(), this);
                //await Navigation.PopAsync();
            }
            else
            {
                //messageLabel.Text = "Login failed";
                await DisplayAlert("Anmeldung fehlgeschlagen", "Falscher Benutzername oder Passwort", "OK");
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Username && user.Password == Constants.Password;
        }

        public void Passwort_vergessen_tapped(object sender, EventArgs e)
        {
            DisplayAlert("Passwort vergessen?", "Klicken Sie auf cancel um fortzufahren", "Cancel");
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
