using AKDILDataManager.Library.DataAccess;
using AKDILDataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AKDILDataManager.Controllers
{
    [Authorize]
    public class EntrepriseController : ApiController
    {
        public List<EntrepriseModel> Get()
        {
            string userTd = RequestContext.Principal.Identity.GetUserId();

            EntrepriseData data = new EntrepriseData();

            return data.GetEntreprises(userTd);
        }
    }
}
