using AKDILDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IVentilationDeductionsEndpoint
    {
        Task<List<VentilationDeductionsModel>> GetAllById(int monthId);
    }
}