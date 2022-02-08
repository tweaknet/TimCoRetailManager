using System.Collections.Generic;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public interface IHolidaysEndpoint
    {
        IAPIHelper _apiHelper { get; set; }
        Task<List<HolidayModel>> GetAll();
    }
}