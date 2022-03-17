using System.Collections.Generic;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public interface IHolidaysData
    {
        List<HolidaysModel> GetHolidayById(int Id);
        List<HolidaysModel> GetHolidays();
        void SaveHolidaysRecord(HolidaysModel item);
    }
}