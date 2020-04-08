using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Auth0.OidcClient;
using possibilityZC.Android;
using IdentityModel.OidcClient;
using Xamarin.Forms;
using possibilityZC.Helpers;
using possibilityZC.Services;
using IdentityModel.OidcClient.Browser;

[assembly: Dependency(typeof(AuthenticationService))]


namespace possibilityZC.Android
{
    public class AuthenticationService : IAuthenticationService
    {
        private Auth0Client _auth0Client;

        public AuthenticationService()
        {
            _auth0Client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = Constants.Domain,
                ClientId = Constants.ClientId
            });
        }

        public Task<LoginResult> Authenticate()
        {
            return _auth0Client.LoginAsync();
        }

        /*public Task<BrowserResultType> LogoutAsync()
        {

            return _auth0Client.LogoutAsync;
        }*/
    }
}