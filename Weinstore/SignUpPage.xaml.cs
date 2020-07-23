using System;
using System.Linq;
using Xamarin.Forms;
using XamarinFirebase.Helper;
using XamarinFirebase.Model;
using Firebase;

namespace Weinstore
{
    public partial class SignUpPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public SignUpPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }

        async void SignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text,
                Email = emailEntry.Text
            };
            Constants.Username = usernameEntry.Text;
            Constants.Password = passwordEntry.Text;
            Constants.Email = emailEntry.Text;
            // Sign up logic goes here

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    await Navigation.PopToRootAsync();
                    //await Navigation.PopModalAsync();
                    App.Current.MainPage = new MainPage();
                    //Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                }

            }
            else
            {
                messageLabel.Text = "Sign up failed";
            }

            await firebaseHelper.AddPerson(usernameEntry.Text, passwordEntry.Text, emailEntry.Text);
            usernameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
            emailEntry.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }

        /**** FIREBASE */


        //private async void OnSignUpButtonClicked(object sender, EventArgs e)
        //{
        //    await firebaseHelper.AddPerson(Convert.ToInt32(usernameEntry.Text), passwordEntry.Text);
        //    usernameEntry.Text = string.Empty;
        //    passwordEntry.Text = string.Empty;
        //    await DisplayAlert("Success", "Person Added Successfully", "OK");
        //    var allPersons = await firebaseHelper.GetAllPersons();
        //    //lstPersons.ItemsSource = allPersons;
        //}

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetPerson(usernameEntry.Text);
            if (person != null)
            {
                usernameEntry.Text = person.Username.ToString();
                passwordEntry.Text = person.Password;
                emailEntry.Text = person.Email;
                await DisplayAlert("Success", "Person Retrive Successfully", "OK");

            }
            else
            {
                await DisplayAlert("Success", "No Person Available", "OK");
            }

        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.UpdatePerson(usernameEntry.Text, passwordEntry.Text, emailEntry.Text);
            usernameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
            emailEntry.Text = string.Empty;
            await DisplayAlert("Success", "Person Updated Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }


    }
}
