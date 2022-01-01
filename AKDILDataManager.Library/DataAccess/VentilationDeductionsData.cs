using AKDILDataManager.Library.Internal.DataAcces;
using AKDILDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.DataAccess
{
    public class VentilationDeductionsData
    {
        public List<VentilationDeductionsModel> GetVentilationDeductions(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { month_Id = id };

            var output = sql.LoadData<VentilationDeductionsModel, dynamic>("[dbo].[spMonthDeductions]", p, "AKADILData");

            return output;
        }
    }
}
