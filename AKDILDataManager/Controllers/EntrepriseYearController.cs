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
    public class EntrepriseYearController : ApiController
    {
        public List<EntrepriseYearModel> Get([FromUri] string entreprise_Id)
        {
            EntrepriseYearData data = new EntrepriseYearData();

            return data.GetEntrepriseYears(Int16.Parse(entreprise_Id));
        }
    }
}
