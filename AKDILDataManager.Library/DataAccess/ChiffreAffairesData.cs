using AKDILDataManager.Library.Internal.DataAcces;
using AKDILDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.DataAccess
{
    public class ChiffreAffairesData
    {
        public List<ChiffreAffairesModel> GetChiffreAffaires(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { month_Id = id };

            var output = sql.LoadData<ChiffreAffairesModel, dynamic>("[dbo].[spMonthCA]", p, "AKADILData");

            return output;
        }
    }
}
