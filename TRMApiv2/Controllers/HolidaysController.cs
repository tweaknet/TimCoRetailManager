using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMApiv2.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidaysData _holidaysData;

        public HolidaysController(IHolidaysData holidaysData)
        {
            _holidaysData = holidaysData;
        }
        [Authorize(Roles = "Manager,Admin")]
        [HttpGet]
        public List<HolidaysModel> Get()
        {
            return _holidaysData.GetHolidays();
        }
    }
}
