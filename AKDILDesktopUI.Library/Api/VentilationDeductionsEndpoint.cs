using AKDILDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AKDILDesktopUI.Library.Api
{
    public class VentilationDeductionsEndpoint : IVentilationDeductionsEndpoint
    {
        private IAPIHelper _apiHelper;

        public VentilationDeductionsEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<VentilationDeductionsModel>> GetAllById(int monthId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"api/VentilationDeductions?month_Id={monthId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<VentilationDeductionsModel>>();
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
