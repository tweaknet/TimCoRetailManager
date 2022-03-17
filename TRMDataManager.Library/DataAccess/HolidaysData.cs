using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class HolidaysData : IHolidaysData
    {
        private readonly ISqlDataAccess _sql;

        public HolidaysData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<HolidaysModel> GetHolidays()
        {
            var output = _sql.LoadData<HolidaysModel, dynamic>("dbo.spHolidays_GetAll", new { }, "EFData");
            return output;
        }
        public void SaveHolidaysRecord(HolidaysModel item)
        {
            _sql.SaveData("spHolidays_Insert", item, "EFData");
        }
        public List<HolidaysModel> GetHolidayById(int Id)
        {
            var output = _sql.LoadData<HolidaysModel, dynamic>("dbo.spHolidaysLookup", new { Id }, "EFData");
            return output;
        }
    }
}
