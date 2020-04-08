using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace possibilityZC.Models.Navigation
{
    public class NavigationModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _id;
        [JsonProperty("id")]
        public string Id
        {
            get => _id;
            set
            {
                if (_id == value)
                    return;

                _id = value;

                HandlePropertyChanged();
            }
        }

        string _name;
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                    return;

                _name = value;

                HandlePropertyChanged();
            }
        }

        string _description;
        [JsonProperty("description")]
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value)
                    return;

                _description = value;

                HandlePropertyChanged();
            }
        }

        string _category;
        [JsonProperty("category")]
        public string Category
        {
            get => _category;
            set
            {
                if (_category == value)
                    return;

                _category = value;

                HandlePropertyChanged();
            }
        }

        string _address;
        [JsonProperty("address")]
        public string Address
        {
            get => _address;
            set
            {
                if (_address == value)
                    return;

                _address = value;

                HandlePropertyChanged();
            }
        }

        string _city;
        [JsonProperty("city")]
        public string City
        {
            get => _city;
            set
            {
                if (_city == value)
                    return;

                _city = value;

                HandlePropertyChanged();
            }
        }

        string _state;
        [JsonProperty("state")]
        public string State
        {
            get => _state;
            set
            {
                if (_state == value)
                    return;

                _state = value;

                HandlePropertyChanged();
            }
        }

        int _zipCode;
        [JsonProperty("zipCode")]
        public int ZipCode
        {
            get => _zipCode;
            set
            {
                if (_zipCode == value)
                    return;

                _zipCode = value;

                HandlePropertyChanged();
            }
        }

        double _lat;
        [JsonProperty("lat")]
        public double Lat
        {
            get => _lat;
            set
            {
                if (_lat == value)
                    return;

                _lat = value;

                HandlePropertyChanged();
            }
        }

        double _long;
        [JsonProperty("long")]
        public double Long
        {
            get => _long;
            set
            {
                if (_long == value)
                    return;

                _long = value;

                HandlePropertyChanged();
            }
        }

        void HandlePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var eventArgs = new PropertyChangedEventArgs(propertyName);

            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}