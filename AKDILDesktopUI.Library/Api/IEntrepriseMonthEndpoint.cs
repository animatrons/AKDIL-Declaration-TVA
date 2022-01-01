using AKDILDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IEntrepriseMonthEndpoint
    {
        Task<List<EntrepriseMonthModel>> GetAllById(int yearId);
    }
}