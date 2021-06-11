using AKDILDataManager.Library.Internal.DataAcces;
using AKDILDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

            var output = sql.LoadData<UserModel, dynamic>("[dbo].[spUserLookup]", p, "AKADILData");

            return output;
        }
    }
}
