using AKDILDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public interface IDeclarationDeductionsEndpoint
    {
        Task<List<DeclarationDeductionsModel>> GetAllById(int monthId);
    }
}