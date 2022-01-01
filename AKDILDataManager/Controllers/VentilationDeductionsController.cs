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
    public class VentilationDeductionsController : ApiController
    {
        public List<VentilationDeductionsModel> Get([FromUri] string month_Id)
        {
            VentilationDeductionsData data = new VentilationDeductionsData();

            return data.GetVentilationDeductions(Int16.Parse(month_Id));
        }
    }
}
