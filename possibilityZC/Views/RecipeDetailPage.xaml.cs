using possibilityZC.Models;
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
    public partial class RecipeDetailPage : ContentPage
    {
        Recipe Recipe;
        bool IsNew;
        RecipeDetailViewModel ViewModel;

        public RecipeDetailPage(Recipe recipe, bool isNew)
        {
            InitializeComponent();

            Recipe = recipe;
            IsNew = isNew;
			ViewModel = new RecipeDetailViewModel(Recipe, IsNew);
            ViewModel.SaveComplete += Handle_SaveComplete;

            BindingContext = ViewModel;
        }
		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			ViewModel.SaveComplete -= Handle_SaveComplete;
		}

		async void Handle_SaveComplete(object sender, EventArgs e)
		{
			await DismissPage();
		}

		protected async void Handle_CancelClicked(object sender, EventArgs e)
		{
			await DismissPage();
		}

		async Task DismissPage()
		{
			if (IsNew)
				await Navigation.PopModalAsync();
			else
				await Navigation.PopAsync();
		}
	}
	
}
