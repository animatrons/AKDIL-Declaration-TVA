﻿using AKDILDataManager.Library.DataAccess;
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
    public class DeclarationChiffreAffairesTotalController : ApiController
    {
            public List<DeclarationChiffreAffairesTotalModel> Get([FromUri] string month_Id)
            {
                DeclarationChiffreAffairesTotalData data = new DeclarationChiffreAffairesTotalData();

                return data.GetDeclarationChiffreAffairesTotal(Int16.Parse(month_Id));
            }
    }
}
