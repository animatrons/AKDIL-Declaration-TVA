using AKDILDataManager.Library.DataAccess;
using AKDILDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AKDILDataManager.Controllers
{
    [Authorize]
    public class EntrepriseMonthController : ApiController
    {
        public List<EntrepriseMonthModel> Get([FromUri] string year_Id)
        {
            EntrepriseMonthData data = new EntrepriseMonthData();

            return data.GetEntrepriseMonths(Int16.Parse(year_Id));
        }
    }
}
