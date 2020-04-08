using possibilityZC.Models;
using possibilityZC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace possibilityZC.Views.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeListCardPage : ContentPage
    {
        SearchBar searchBar = null;
        RecipeItemsViewModel vm;
        public RecipeListCardPage()
        {
            InitializeComponent();
            vm = new RecipeItemsViewModel();
            BindingContext = vm;
            recipeListView.ItemTapped += ItemTappedAsync;
            recipeListView.SelectionChanged += (sender, args) => recipeListView.SelectedItem = null;

            vm.Title = "Recipes";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.RefreshCommand.Execute(null);
        }

        public async void ItemTappedAsync(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var recipe = e.ItemData as Recipe;
            if (recipe == null)
            {
                return;
            }

            await Navigation.PushAsync(new RecipeDetailPage(recipe, false));


        }


        protected async void AddNewClicked(object sender, EventArgs e)
        {
            var recipe = new Recipe();
            var todoPage = new RecipeDetailPage(recipe, true);

            await Navigation.PushModalAsync(new NavigationPage(todoPage));
        }

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (recipeListView.DataSource != null)
            {
                this.recipeListView.DataSource.Filter = FilterContacts;
                this.recipeListView.DataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var recipe = obj as Recipe;
            if (recipe.Name.ToLower().Contains(searchBar.Text.ToLower())
                 || recipe.Name.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else if (recipe.Category.ToLower().Contains(searchBar.Text.ToLower())
                 || recipe.Category.ToLower().Contains(searchBar.Text.ToLower()))
                return true;
            else
                return false;
        }
    }
}