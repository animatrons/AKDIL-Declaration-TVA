﻿using AKDILDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public class EntrepriseYearEndpoint : IEntrepriseYearEndpoint
    {
        private IAPIHelper _apiHelper;

        public EntrepriseYearEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<EntrepriseYearModel>> GetAllById(int entrpriseId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/EntrepriseYear?entreprise_Id={entrpriseId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<EntrepriseYearModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
