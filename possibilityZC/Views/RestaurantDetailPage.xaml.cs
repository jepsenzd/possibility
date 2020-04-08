using possibilityZC.Models;
using possibilityZC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace possibilityZC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestaurantDetailPage : ContentPage
	{
		Restaurant restaurant1;
		
		RestaurantDetailViewModel vm;

		public RestaurantDetailPage(Restaurant restaurant)
		{
			InitializeComponent();

			
			restaurant1 = restaurant;
			vm = new RestaurantDetailViewModel(restaurant);
			BindingContext = vm;
			lblFullAddress.Text = lblAddress.Text + ", " + lblCity.Text + ", " + lblState.Text;

		}
		async void getDirections(object sender, EventArgs e)
		{
			String restName = lblName.Text;
			String restAddress = lblAddress.Text +  lblCity.Text +  lblState.Text;
			String restLat = lblLat.Text;
			String restLong = lblLong.Text;
			String fullAddress = restName + restAddress;


			//if (restaurant1 == null)
			//return;
			//await DisplayAlert("yeet", "clicked", "ok");
			await Launcher.OpenAsync("geo:0,0?q=" + fullAddress);
		}
		async Task DismissPage()
		{
			await Navigation.PopAsync();
		}
	}
}