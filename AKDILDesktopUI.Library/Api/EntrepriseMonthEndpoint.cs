using AKDILDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public class EntrepriseMonthEndpoint : IEntrepriseMonthEndpoint
    {
        private IAPIHelper _apiHelper;

        public EntrepriseMonthEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<EntrepriseMonthModel>> GetAllById(int yearId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/EntrepriseMonth?year_Id={yearId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<EntrepriseMonthModel>>();
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
