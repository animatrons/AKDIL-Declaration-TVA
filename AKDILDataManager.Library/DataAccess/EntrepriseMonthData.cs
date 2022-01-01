using AKDILDataManager.Library.Internal.DataAcces;
using AKDILDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.DataAccess
{
    public class EntrepriseMonthData
    {
        public List<EntrepriseMonthModel> GetEntrepriseMonths(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { year_Id = Id };

            var output = sql.LoadData<EntrepriseMonthModel, dynamic>("[dbo].[spEntrepriseMonth_GetAll_ByYearId]", p, "AKADILData");

            return output;
        }
    }
}
