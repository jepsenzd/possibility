using possibilityZC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using possibilityZC.Services;

namespace possibilityZC.ViewModels
{
	public class RestaurantsViewModel : BaseViewModel
	{
		List<Restaurant> restaurants;
		public List<Restaurant> Restaurants { get => restaurants; set => SetProperty(ref restaurants, value); }


		public ICommand RefreshCommand { get; }

		public RestaurantsViewModel()
		{
			Restaurants = new List<Restaurant>();
			RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
		}

		async Task ExecuteRefreshCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Restaurants = await CosmosDBService.GetRestaurants();
			}
			finally
			{
				IsBusy = false;
			}
		}

	}
}
