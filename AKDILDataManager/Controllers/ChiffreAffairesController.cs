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
    public class ChiffreAffairesController : ApiController
    {
        public List<ChiffreAffairesModel> Get([FromUri] string month_Id)
        {
            ChiffreAffairesData data = new ChiffreAffairesData();

            return data.GetChiffreAffaires(Int16.Parse(month_Id));
        }
    }
}
