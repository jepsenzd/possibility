using System.Threading.Tasks;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;

namespace possibilityZC.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResult> Authenticate();

        //Task<BrowserResultType> LogoutAsync();
    }
}
