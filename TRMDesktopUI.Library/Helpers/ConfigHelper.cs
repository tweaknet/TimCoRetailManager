using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Helpers
{
    public class ConfigHelper
    {
        public double GetTaxRate()
        {
            double output = 0;
            string rateText = ConfigurationManager.AppSettings["taxRate"];
            bool isValidTaxRate = Double.TryParse(rateText, out output);
            if (isValidTaxRate == false)
            {
                throw new ConfigurationErrorException("tax is empty");
            }
            return output;
        }
    }
}
