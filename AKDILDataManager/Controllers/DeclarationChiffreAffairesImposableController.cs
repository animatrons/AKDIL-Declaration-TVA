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
    public class DeclarationChiffreAffairesImposableController : ApiController
    {
        public List<DeclarationChiffreAffairesImposableModel> Get([FromUri] string month_Id)
        {
            DeclarationChiffreAffairesImposableData data = new DeclarationChiffreAffairesImposableData();

            return data.GetDeclarationChiffreAffairesImposable(Int16.Parse(month_Id));
        }
    }
}
