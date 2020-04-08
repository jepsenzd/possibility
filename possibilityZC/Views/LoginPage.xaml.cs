using possibilityZC.Services;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //LoginButton.Clicked += LoginButton_Clicked;
        }

		protected override void OnAppearing()
		{
			AuthenticateCheck();
		}

		private async void AuthenticateCheck()
		{
			var authenticationService = DependencyService.Get<IAuthenticationService>();
			var loginResult = await authenticationService.Authenticate();

			var sb = new StringBuilder();

			if (loginResult.IsError)
			{
				ResultLabel.Text = "An error occurred during login...";

				sb.AppendLine("An error occurred during login:");
				sb.AppendLine(loginResult.Error);
			}
			else
			{
				ResultLabel.Text = $"Welcome {loginResult.User.Identity.Name}";

				sb.AppendLine($"ID Token: {loginResult.IdentityToken}");
				sb.AppendLine($"Access Token: {loginResult.AccessToken}");
				sb.AppendLine($"Refresh Token: {loginResult.RefreshToken}");
				sb.AppendLine();
				sb.AppendLine("-- Claims --");
				foreach (var claim in loginResult.User.Claims)
				{
					sb.AppendLine($"{claim.Type} = {claim.Value}");
				}
			}

			System.Diagnostics.Debug.WriteLine(sb.ToString());
		}

		/*private async void LoginButton_Clicked(object sender, EventArgs e)
		{
			var authenticationService = DependencyService.Get<IAuthenticationService>();
			var loginResult = await authenticationService.Authenticate();

			var sb = new StringBuilder();

			if (loginResult.IsError)
			{
				ResultLabel.Text = "An error occurred during login...";

				sb.AppendLine("An error occurred during login:");
				sb.AppendLine(loginResult.Error);
			}
			else
			{
				ResultLabel.Text = $"Welcome {loginResult.User.Identity.Name}";

				sb.AppendLine($"ID Token: {loginResult.IdentityToken}");
				sb.AppendLine($"Access Token: {loginResult.AccessToken}");
				sb.AppendLine($"Refresh Token: {loginResult.RefreshToken}");
				sb.AppendLine();
				sb.AppendLine("-- Claims --");
				foreach (var claim in loginResult.User.Claims)
				{
					sb.AppendLine($"{claim.Type} = {claim.Value}");
				}
			}

			System.Diagnostics.Debug.WriteLine(sb.ToString());
			LoginButton.IsVisible = false;
			LogoutButton.IsVisible = true;
		}

		private async void LogoutButton_Clicked(object sender, EventArgs e)
		{
			var authenticationService = DependencyService.Get<IAuthenticationService>();
			var logoutResult = await authenticationService.LogoutAsync();

			
			LoginButton.IsVisible = true;
			LogoutButton.IsVisible = false;
		}*/
	}
}