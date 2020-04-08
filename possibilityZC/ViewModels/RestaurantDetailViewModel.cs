using possibilityZC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace possibilityZC.ViewModels
{
	public class RestaurantDetailViewModel : BaseViewModel
	{
		
		public Restaurant Restaurant { get; set; }

		public RestaurantDetailViewModel(Restaurant restaurant)
		{
			Restaurant = restaurant;
			Title = Restaurant.Name;
		}

	}
}
