using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Api
{
    public class UserEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public UserEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
    }
}
