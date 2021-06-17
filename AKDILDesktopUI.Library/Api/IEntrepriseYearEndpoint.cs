using AKDILDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IEntrepriseYearEndpoint
    {
        Task<List<EntrepriseYearModel>> GetAllById(int entrpriseId);
    }
}