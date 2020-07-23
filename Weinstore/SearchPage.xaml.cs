using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Weinstore
{
    public partial class SearchPage : ContentPage
    {
        private ObservableCollection<WineriesGroup> _allGroups;
        private ObservableCollection<WineriesGroup> _expandedGroups;

        public SearchPage()
        {
            InitializeComponent();
            _allGroups = WineriesGroup.All;
            UpdateListContent();
        }

        private void HeaderTapped(object sender, EventArgs args)
        {
            int selectedIndex = _expandedGroups.IndexOf(
                ((WineriesGroup)((Button)sender).CommandParameter));
            _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
            UpdateListContent();
        }

        private void UpdateListContent()
        {
            _expandedGroups = new ObservableCollection<WineriesGroup>();
            foreach (WineriesGroup group in _allGroups)
            {
                //Create new WineriesGroups so we do not alter original list
                WineriesGroup newGroup = new WineriesGroup(group.Title, group.ShortName, group.Expanded);
                //Add the count of winery items for Lits Header Titles to use
                newGroup.WineryCount = group.Count;
                if (group.Expanded)
                {
                    foreach (Winery winery in group)
                    {
                        newGroup.Add(winery);
                    }
                }
                _expandedGroups.Add(newGroup);
            }
            GroupedView.ItemsSource = _expandedGroups;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        private async void SearchBtn_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SearchPage());
        }

        async void OnUpcomingAppointmentsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchClickedPage());
        }
    }
}
