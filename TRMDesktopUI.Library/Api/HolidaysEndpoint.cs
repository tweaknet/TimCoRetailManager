using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class HolidaysEndpoint : IHolidaysEndpoint
    {
        public IAPIHelper _apiHelper { get; set; }
        public HolidaysEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<HolidayModel>> GetAll()
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Holidays");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<HolidayModel>>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public async Task<List<HolidayModel>> GetHolidayById(int Id)
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Holidays/Details/{Id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<HolidayModel>>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
