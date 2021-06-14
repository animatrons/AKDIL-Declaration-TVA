using AKDILTVADesktopUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get;  }
        Task<AuthenticatedUser> Authentificate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}