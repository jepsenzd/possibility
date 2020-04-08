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
    public partial class SavedRecipesPage : ContentPage
	{
		SavedRecipesViewModel ViewModel;
		public SavedRecipesPage()
		{
			InitializeComponent();

			ViewModel = new SavedRecipesViewModel();
			BindingContext = ViewModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			ViewModel.RefreshCommand.Execute(null);
		}
	}
}