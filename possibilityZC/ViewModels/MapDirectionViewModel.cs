using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Geolocator;
using possibilityZC.Helpers;
using possibilityZC.Models;
using possibilityZC.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace possibilityZC.ViewModels
{
    public class MapDirectionViewModel : INotifyPropertyChanged
    {
        public ICommand CalculateRouteCommand { get; set; }
        //public ICommand UpdatePositionCommand { get; set; }

        public ICommand LoadRouteCommand { get; set; }
        public ICommand StopRouteCommand { get; set; }
        IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();

        public bool HasRouteRunning { get; set; }
        string _originLatitud;
        string _originLongitud;
        string _destinationLatitud;
        string _destinationLongitud;


        public ICommand FocusOriginCommand { get; set; }
        public ICommand GetPlaceDetailCommand { get; set; }


        public bool ShowRecentPlaces { get; set; }
        bool _isPickupFocused = true;

        public bool IsRouteNotRunning
        {
            get
            {
                return !HasRouteRunning;
            }
        }

        public MapDirectionViewModel()
        {
            LoadRouteCommand = new Command(async () => await LoadRoute());
            StopRouteCommand = new Command(StopRoute);
            //GetPlaceDetailCommand = new Command<Restaurant>(async (param) => await GetPlacesDetail(param));
        }

        public async Task LoadRoute()
        {
            //var positionIndex = 1;
            var googleDirection = await googleMapsApi.GetDirections(_originLatitud, _originLongitud, _destinationLatitud, _destinationLongitud);
            if (googleDirection.Routes != null && googleDirection.Routes.Count > 0)
            {
                var positions = (Enumerable.ToList(PolylineHelper.Decode(googleDirection.Routes.First().OverviewPolyline.Points)));
                CalculateRouteCommand.Execute(positions);

                HasRouteRunning = true;

               /* //Location tracking simulation
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    if (positions.Count > positionIndex && HasRouteRunning)
                    {
                        UpdatePositionCommand.Execute(positions[positionIndex]);
                        positionIndex++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });*/
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(":(", "No route found", "Ok");
            }

        }
        public void StopRoute()
        {
            HasRouteRunning = false;
        }

        public async Task GetPlacesDetail(Restaurant restaurant)
        {
            //var place = await googleMapsApi.GetPlaceDetails(placeA.PlaceId);
            if (restaurant != null)
            {
                if (_isPickupFocused)
                {
                    //PickupText = place.Name;
                    _originLatitud = $"{restaurant.Lat}";
                    _originLongitud = $"{restaurant.Long}";
                    _isPickupFocused = false;
                    FocusOriginCommand.Execute(null);
                }
                else
                {
                    _destinationLatitud = $"{restaurant.Lat}";
                    _destinationLongitud = $"{restaurant.Long}";

                    //RecentPlaces.Add(placeA);

                    if (_originLatitud == _destinationLatitud && _originLongitud == _destinationLongitud)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Origin route should be different than destination route", "Ok");
                    }
                    else
                    {
                        LoadRouteCommand.Execute(null);
                        //await App.Current.MainPage.Navigation.PopAsync(false);
                        //CleanFields();
                    }

                }
            }
        }

        

        /*void CleanFields()
        {
            //PickupText = OriginText = string.Empty;
            ShowRecentPlaces = true;
            //PlaceSelected = null;
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
