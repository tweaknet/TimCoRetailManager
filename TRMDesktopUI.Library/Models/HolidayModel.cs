using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Models
{
    public class HolidayModel
    {
        public int Id { get; set; }
        public int IdHolidayType { get; set; }
        public DateTime Data { get; set; }
        public int IdUser { get; set; }
        public int HolidayTypeId { get; set; }
    }
}
