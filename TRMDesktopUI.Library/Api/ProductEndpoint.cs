using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class ProductEndpoint : IProductEndpoint
    {
        public IAPIHelper _apiHelper { get; set; }
        public ProductEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Product");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<ProductModel>>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
