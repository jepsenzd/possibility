using possibilityZC.Models;
using possibilityZC.ViewModels.Navigation;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace possibilityZC.Views.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationListCardPage : ContentPage
    {
        NavigationViewModel vm;
        SearchBar searchBar = null;
        public NavigationListCardPage()
        {
            InitializeComponent();
            vm = new NavigationViewModel();
            BindingContext = vm;
            restListView.ItemTapped += ItemTappedAsync;
            restListView.SelectionChanged += (sender, args) => restListView.SelectedItem = null;

            vm.Title = "Restaurants";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.RefreshCommand.Execute(null);
        }

        public async void ItemTappedAsync(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var restaurant = e.ItemData as Restaurant;
            if (restaurant == null)
            {
                return;
            }

           await Navigation.PushAsync(new RestaurantDetailPage(restaurant));
  
        }

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (restListView.DataSource != null)
            {
                this.restListView.DataSource.Filter = FilterContacts;
                this.restListView.DataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var restaurant = obj as Restaurant;
            if (restaurant.Name.ToLower().Contains(searchBar.Text.ToLower())
                 || restaurant.Name.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else if (restaurant.Category.ToLower().Contains(searchBar.Text.ToLower())
                 || restaurant.Category.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else if (restaurant.Diet.ToLower().Contains(searchBar.Text.ToLower())
                 || restaurant.Diet.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else
                return false;
        }

    }
}