using possibilityZC.Helpers;
using possibilityZC.Services;
using possibilityZC.Views;
using possibilityZC.Views.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace possibilityZC
{
    public partial class App : Xamarin.Forms.Application
    {
        
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjIwODQwQDMxMzcyZTM0MmUzMFNGSmROMHZxTU1zTkx3akh0cVlaMmpHKzhFTTZFS3VJYndVU2M4dEpQRlE9");
            InitializeComponent();
            GoogleMapsApiService.Initialize(APIKeys.GoogleMapsApiKey);

            MainPage = new MasterPage();
            /* MainPage = new MasterDetailPage()
            {
                Master = new MasterPage() { Title = "Main Page" },
                Detail = new Xamarin.Forms.NavigationPage(new NavigationListCardPage())
            };
            var toDoNavPage = new Xamarin.Forms.NavigationPage(new RestaurantsPage())
            {
                Title = "Restaurants Near You",
                BarBackgroundColor = Color.FromHex("#2082fa"),
                BarTextColor = Color.White
            };
            toDoNavPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);
            var restNavPage = new Xamarin.Forms.NavigationPage(new NavigationListCardPage())
            {
                Title = "Restaurants Near You 2",
                BarBackgroundColor = Color.FromHex("#2082fa"),
                BarTextColor = Color.White
            };
            restNavPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);
            var recipeNavPage = new Xamarin.Forms.NavigationPage(new RecipeListPage())
            {
                Title = "Recipes",
                BarBackgroundColor = Color.FromHex("#2082fa"),
                BarTextColor = Color.White
            };
            restNavPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

            var mainTabbedPage = new Xamarin.Forms.TabbedPage
            {
                Children = {
                    toDoNavPage, restNavPage, recipeNavPage
                }
            };

            MainPage = mainTabbedPage;*/
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
