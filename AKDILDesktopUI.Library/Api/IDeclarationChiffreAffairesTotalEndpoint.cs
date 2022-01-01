using AKDILDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IDeclarationChiffreAffairesTotalEndpoint
    {
        Task<List<DeclarationChiffreAffairesTotalModel>> GetAllById(int monthId);
    }
}