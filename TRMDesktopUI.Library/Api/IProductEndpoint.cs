using System.Collections.Generic;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        IAPIHelper _apiHelper { get; set; }

        Task<List<ProductModel>> GetAll();
    }
}