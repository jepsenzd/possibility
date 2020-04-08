using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace possibilityZC.Models
{
    public class Restaurant : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public List<Menu> menus { get; set; }

		public class Menu
		{
			public string item1 { get; set; }
			public string item2 { get; set; }
			public string item3 { get; set; }
			public string item4 { get; set; }
			public string item5 { get; set; }
			public string item6 { get; set; }
			public string item7 { get; set; }
			public string item8 { get; set; }
			public string item9 { get; set; }
			public string item10 { get; set; }
			public string item11 { get; set; }
		}


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

		string _diet;
		[JsonProperty("diet")]
		public string Diet
		{
			get => _diet;
			set
			{
				if (_diet == value)
					return;

				_diet = value;

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
