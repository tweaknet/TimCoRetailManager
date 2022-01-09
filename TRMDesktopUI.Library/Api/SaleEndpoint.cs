using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class SaleEndpoint : ISaleEndpoint
    {
        public IAPIHelper _apiHelper { get; set; }
        public SaleEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task PostSale(SaleModel sale)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Sale", sale))
            {
                if (response.IsSuccessStatusCode)
                {
                    // todo?
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        //public async Task<List<ProductModel>> GetAll()
        //{
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return await response.Content.ReadAsAsync<List<ProductModel>>();
        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //    }
        //}
    }
}
