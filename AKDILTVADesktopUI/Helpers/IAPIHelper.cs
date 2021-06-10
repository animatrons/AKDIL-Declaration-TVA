using AKDILTVADesktopUI.Models;
using System.Threading.Tasks;

namespace AKDILTVADesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}