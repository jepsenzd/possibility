using possibilityZC.Models;
using possibilityZC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace possibilityZC.ViewModels
{
    public class SavedRecipesViewModel : BaseViewModel
	{
		List<Recipe> savedRecipes;
		public List<Recipe> SavedRecipes { get => savedRecipes; set => SetProperty(ref savedRecipes, value); }

		public ICommand RefreshCommand { get; }

		public SavedRecipesViewModel()
		{
			RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
			Title = "Saved";
		}

		async Task ExecuteRefreshCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				SavedRecipes = await DocumentDBService.GetSavedRecipeItems();
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}