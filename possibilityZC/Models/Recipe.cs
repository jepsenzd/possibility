using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace possibilityZC.Models
{
    public class Recipe : INotifyPropertyChanged
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

		string _directions;
		[JsonProperty("directions")]
		public string Directions
		{
			get => _directions;
			set
			{
				if (_directions == value)
					return;

				_directions = value;

				HandlePropertyChanged();
			}
		}

		string _preptime;
		[JsonProperty("preptime")]
		public string Preptime
		{
			get => _preptime;
			set
			{
				if (_preptime == value)
					return;

				_preptime = value;

				HandlePropertyChanged();
			}
		}

		string _cooktime;
		[JsonProperty("cooktime")]
		public string Cooktime
		{
			get => _cooktime;
			set
			{
				if (_cooktime == value)
					return;

				_cooktime = value;

				HandlePropertyChanged();
			}
		}

		string _ingredient1;
		[JsonProperty("ingredient1")]
		public string Ingredient1
		{
			get => _ingredient1;
			set
			{
				if (_ingredient1 == value)
					return;

				_ingredient1 = value;

				HandlePropertyChanged();
			}
		}

		string _ingredient2;
		[JsonProperty("ingredient2")]
		public string Ingredient2
		{
			get => _ingredient2;
			set
			{
				if (_ingredient2 == value)
					return;

				_ingredient2 = value;

				HandlePropertyChanged();
			}
		}
		
		string _ingredient3;
		[JsonProperty("ingredient3")]
		public string Ingredient3
		{
			get => _ingredient3;
			set
			{
				if (_ingredient3 == value)
					return;

				_ingredient3 = value;

				HandlePropertyChanged();
			}
		}
			
		string _ingredient4;
		[JsonProperty("ingredient4")]
		public string Ingredient4
		{
			get => _ingredient4;
			set
			{
				if (_ingredient4 == value)
					return;

				_ingredient4 = value;

				HandlePropertyChanged();
			}

		}
		
		string _ingredient5;
		[JsonProperty("ingredient5")]
		public string Ingredient5
		{
			get => _ingredient5;
			set
			{
				if (_ingredient5 == value)
					return;

				_ingredient5 = value;

				HandlePropertyChanged();
			}

		}
		
		string _ingredient6;
		[JsonProperty("ingredient6")]
		public string Ingredient6
		{
			get => _ingredient6;
			set
			{
				if (_ingredient6 == value)
					return;

				_ingredient6 = value;

				HandlePropertyChanged();
			}

		}
		
		string _ingredient7;
		[JsonProperty("ingredient7")]
		public string Ingredient7
		{
			get => _ingredient7;
			set
			{
				if (_ingredient7 == value)
					return;

				_ingredient7 = value;

				HandlePropertyChanged();
			}

		}

		string _ingredient8;
		[JsonProperty("ingredient8")]
		public string Ingredient8
		{
			get => _ingredient8;
			set
			{
				if (_ingredient8 == value)
					return;

				_ingredient8 = value;

				HandlePropertyChanged();
			}

		}

		string _ingredient9;
		[JsonProperty("ingredient9")]
		public string Ingredient9
		{
			get => _ingredient9;
			set
			{
				if (_ingredient9 == value)
					return;

				_ingredient9 = value;

				HandlePropertyChanged();
			}

		}

		string _ingredient10;
		[JsonProperty("ingredient10")]
		public string Ingredient10
		{
			get => _ingredient10;
			set
			{
				if (_ingredient10 == value)
					return;

				_ingredient10 = value;

				HandlePropertyChanged();
			}

		}

		string _ingredient11;
		[JsonProperty("ingredient11")]
		public string Ingredient11
		{
			get => _ingredient11;
			set
			{
				if (_ingredient11 == value)
					return;

				_ingredient11 = value;

				HandlePropertyChanged();
			}

		}

		string _ingredient12;
		[JsonProperty("ingredient12")]
		public string Ingredient12
		{
			get => _ingredient12;
			set
			{
				if (_ingredient12 == value)
					return;

				_ingredient12 = value;

				HandlePropertyChanged();
			}

		}

		bool _saved;
		[JsonProperty("isSaved")]
		public bool Saved
		{
			get => _saved;
			set
			{
				if (_saved == value)
					return;

				_saved = value;

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
