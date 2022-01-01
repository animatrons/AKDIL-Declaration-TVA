using AKDILDataManager.Library.Internal.DataAcces;
using AKDILDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.DataAccess
{
    public class DeclarationChiffreAffairesTotalData
    {
        public List<DeclarationChiffreAffairesTotalModel> GetDeclarationChiffreAffairesTotal(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { month_Id = id };

            var output = sql.LoadData<DeclarationChiffreAffairesTotalModel, dynamic>("[dbo].[spDeclarationChiffreAffairesTotal]", p, "AKADILData");

            return output;
        }
    }
}
