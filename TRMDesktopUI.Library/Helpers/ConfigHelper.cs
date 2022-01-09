﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];
            bool isValidTaxRate = Decimal.TryParse(rateText, out decimal output);
            if (isValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("tax is empty");
            }
            return output;
        }
    }
}
