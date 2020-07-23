using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Weinstore
{
    public partial class SearchClickedPage : ContentPage
    {
        public SearchClickedPage()
        {
            InitializeComponent();
        }
        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
