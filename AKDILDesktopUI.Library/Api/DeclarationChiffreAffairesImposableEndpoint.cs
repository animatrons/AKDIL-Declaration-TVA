using AKDILDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public class DeclarationChiffreAffairesImposableEndpoint : IDeclarationChiffreAffairesImposableEndpoint
    {
        private IAPIHelper _apiHelper;

        public DeclarationChiffreAffairesImposableEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<DeclarationChiffreAffairesImposableModel>> GetAllById(int monthId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/DeclarationChiffreAffairesImposable?month_Id={monthId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<DeclarationChiffreAffairesImposableModel>>();
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
