using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TRMDataManager.Controllers
{
        [Authorize]
    public class ProductController : ApiController
    {
        [HttpGet]
        public List<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
