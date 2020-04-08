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
    public class RecipeDetailViewModel : BaseViewModel
	{
		bool isNew;
		public bool IsNew
		{
			get => isNew;
			set => SetProperty(ref isNew, value);
		}


		public Recipe Recipe { get; set; }
		public ICommand SaveCommand { get; }

		public event EventHandler SaveComplete;

		public RecipeDetailViewModel(Recipe todo, bool isNew)
		{
			IsNew = isNew;
			Recipe = todo;

			SaveCommand = new Command(async () => await ExecuteSaveCommand());

			Title = IsNew ? "New Recipe" : Recipe.Name;
		}

		async Task ExecuteSaveCommand()
		{
			if (IsNew)
				await DocumentDBService.InsertRecipeItem(Recipe);
			else
				await DocumentDBService.UpdateRecipeItem(Recipe);

			SaveComplete?.Invoke(this, new EventArgs());
		}
	}
}
