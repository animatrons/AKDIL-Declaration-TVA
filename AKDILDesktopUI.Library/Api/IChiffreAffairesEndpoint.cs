using AKDILDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IChiffreAffairesEndpoint
    {
        Task<List<ChiffreAffairesModel>> GetAllById(int monthId);
    }
}