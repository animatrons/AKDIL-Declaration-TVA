using AKDILDataManager.Library.Internal.DataAcces;
using AKDILDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.DataAccess
{
    public class EntrepriseData
    {
        public List<EntrepriseModel> GetEntreprises(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { admin_Id = Id };

            var output = sql.LoadData<EntrepriseModel, dynamic>("[dbo].[spEntreprise_GetAll]", p, "AKADILData");

            return output;
        }
    }
}
