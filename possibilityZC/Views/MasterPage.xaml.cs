using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using possibilityZC.Models;
using possibilityZC.Views;
using possibilityZC.Views.ContactUs;
using possibilityZC.Views.Navigation;
using possibilityZC.Views.Profile;
using possibilityZC.Views.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace possibilityZC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList
        {
            get;
            set;
        }
        public MasterPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();
            // Adding menu items to menuList and you can define title ,page and icon  

            menuList.Add(new MasterPageItem()
            {
                Title = "Login",
                Icon = "profile.png",
                TargetType = typeof(LoginPage)
            });

            menuList.Add(new MasterPageItem()
            {
                Title = "Find Restaurants",
                Icon = "dashboard.png",
                TargetType = typeof(NavigationListCardPage)
            });

            menuList.Add(new MasterPageItem()
            {
                Title = "Recipes",
                Icon = "restaurant.png",
                TargetType = typeof(RecipeListCardPage)
            });

            menuList.Add(new MasterPageItem()
            {
                Title = "Settings",
                Icon = "settings.png",
                TargetType = typeof(SettingPage)
            });

            menuList.Add(new MasterPageItem()
            {
                Title = "Help",
                TargetType = typeof(ContactUsPage)
            });



            /* menuList.Add(new MasterPageItem()
             {
                 Title = "My Profile",
                 Icon = "profile.png",
                 TargetType = typeof(ProfilePage)
             });

             menuList.Add(new MasterPageItem()
             {
                 Title = "Settings",
                 Icon = "settings.png",
                 TargetType = typeof(SettingPage)
             });*/



            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(NavigationListCardPage)));
        }
        // Event for Menu Item selection, here we are going to handle navigation based  
        // on user selection in menu ListView  
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}