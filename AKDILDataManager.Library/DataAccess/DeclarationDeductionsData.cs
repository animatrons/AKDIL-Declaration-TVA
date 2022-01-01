using AKDILDataManager.Library.Internal.DataAcces;
using AKDILDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.DataAccess
{
    public class DeclarationDeductionsData
    {
        public List<DeclarationDeductionsModel> GetDeclarationDeductions(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { month_Id = id };

            var output = sql.LoadData<DeclarationDeductionsModel, dynamic>("[dbo].[spDeclarationDeductions]", p, "AKADILData");

            return output;
        }
    }
}
