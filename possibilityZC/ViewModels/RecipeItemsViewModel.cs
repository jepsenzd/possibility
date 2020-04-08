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
    public class RecipeItemsViewModel : BaseViewModel
	{
		List<Recipe> recipes;
		public List<Recipe> Recipes { get => recipes; set => SetProperty(ref recipes, value); }

		public ICommand RefreshCommand { get; }
		public ICommand CompleteCommand { get; }

		public RecipeItemsViewModel()
		{
			Recipes = new List<Recipe>();
			RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
			CompleteCommand = new Command<Recipe>(async (item) => await ExecuteCompleteCommand(item));
		}

		async Task ExecuteRefreshCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Recipes = await DocumentDBService.GetRecipeItems();
			}
			finally
			{
				IsBusy = false;
			}
		}

		async Task ExecuteCompleteCommand(Recipe item)
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				await DocumentDBService.SaveRecipeItem(item);
				Recipes = await DocumentDBService.GetRecipeItems();
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
