using AKDILTVADesktopUI.Models;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authentificate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}