using AKDILDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IEntrepriseEndpoint
    {
        Task<List<EntrepriseModel>> GetAll();
    }
}