using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public interface ISaleEndpoint
    {
        IAPIHelper _apiHelper { get; set; }

        Task PostSale(SaleModel sale);
    }
}