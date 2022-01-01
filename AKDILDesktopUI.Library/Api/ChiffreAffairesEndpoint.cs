using AKDILDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public class ChiffreAffairesEndpoint : IChiffreAffairesEndpoint
    {
        private IAPIHelper _apiHelper;

        public ChiffreAffairesEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ChiffreAffairesModel>> GetAllById(int monthId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/ChiffreAffaires?month_Id={monthId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ChiffreAffairesModel>>();
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
