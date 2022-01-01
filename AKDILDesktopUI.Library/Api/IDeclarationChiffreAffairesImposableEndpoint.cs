using AKDILDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IDeclarationChiffreAffairesImposableEndpoint
    {
        Task<List<DeclarationChiffreAffairesImposableModel>> GetAllById(int monthId);
    }
}