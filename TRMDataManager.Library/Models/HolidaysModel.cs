using System;

namespace TRMDataManager.Library.Models
{
    public class HolidaysModel
    {
        public int Id { get; set; }
        public int IdHolidayType { get; set; }
        public DateTime Data { get; set; }
        public int IdUser { get; set; }
        public int HolidayTypeId { get; set; }
    }
}