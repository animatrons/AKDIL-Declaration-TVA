using AKDILDataManager.Library.Internal.DataAcces;
using AKDILDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.DataAccess
{
    public class EntrepriseYearData
    {
        public List<EntrepriseYearModel> GetEntrepriseYears(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { entreprise_Id = Id };

            var output = sql.LoadData<EntrepriseYearModel, dynamic>("[dbo].[spEnrepriseYear_GetAll_ById]", p, "AKADILData");

            return output;
        }
    }
}
