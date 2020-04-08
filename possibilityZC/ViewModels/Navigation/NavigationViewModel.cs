using possibilityZC.Models;
using possibilityZC.Services;
using possibilityZC.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using NavigationModel = possibilityZC.Models.Navigation.NavigationModel;

namespace possibilityZC.ViewModels.Navigation
{
    public class NavigationViewModel : BaseViewModel
    {

        List<Restaurant> restaurants;
        public List<Restaurant> Restaurants { get => restaurants; set => SetProperty(ref restaurants, value); }

        public ICommand RefreshCommand { get; }


        public NavigationViewModel()
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