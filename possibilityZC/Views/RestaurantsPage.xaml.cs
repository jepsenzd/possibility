using possibilityZC.Models;
using possibilityZC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace possibilityZC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantsPage : ContentPage
    {
        RestaurantsViewModel vm;

        public RestaurantsPage()
        {
            InitializeComponent();

            vm = new RestaurantsViewModel();
            BindingContext = vm;

            todoItemsList.ItemSelected += listItemSelected;
            todoItemsList.ItemTapped += (sender, args) => todoItemsList.SelectedItem = null;

            vm.Title = "Restaurants";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.RefreshCommand.Execute(null);
        }

        protected async void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var restaurant = e.SelectedItem as Restaurant;

            if (restaurant == null)
                return;

            await Navigation.PushAsync(new RestaurantDetailPage(restaurant));
        }

        

        protected async void AddNewClicked(object sender, EventArgs e)
        {
            var restaurant = new Restaurant();
            var restaurantPage = new RestaurantDetailPage(restaurant);

            await Navigation.PushModalAsync(new NavigationPage(restaurantPage));
        }
    }
}
