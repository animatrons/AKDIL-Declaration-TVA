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
    public class DeclarationDeductionsController : ApiController
    {
        public List<DeclarationDeductionsModel> Get([FromUri] string month_Id)
        {
            DeclarationDeductionsData data = new DeclarationDeductionsData();

            return data.GetDeclarationDeductions(Int16.Parse(month_Id));
        }
    }
}
