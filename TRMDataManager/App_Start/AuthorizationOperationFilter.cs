using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace TRMDataManager.App_Start
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }
            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "access token",
                required = false,
                type = "string",
                @default = "bearer zEUlz90sHddmSELD0Gm1A9r02yAYyirpewTOXUvRxrSiLZbasKsqlS-0hlvGN4j_fy0T4JUO9GgWqNri5Wa4apVcDPt0AG2l1ODNFrJHWO_jRTwgIwr71ztIUh81qvfaqjVD0IUbrCIHfxDMHRL2GOWIgm5idK-oRR6BWv9bESLfGfnqXoSpJQ2VjnC39GlDBAPwu4tTXtVyv_-0UTmEAcPBQKkolI2LDYc0-u_HX58ZW5h-v1u-bldHKcl3oZfidh2nMEdWm0JxFVNOt9qmO3b_URTMkXTP4ps4iHysPNUN7h0Zc95uux04hpqAiZq-r9P-FuGzNmafJZBFI2iV_a5bpCTbWWfBmStrbDth2nY6CwQXoiS6k1tsxkuEsd1TNBp0e38aKlLQPSZexpcw5ZoWGqYLmv3s1-xr-JqyjebdRk1e4AWuMTGEkRtgmT_TCs1OsrMeQVll3SduC3WPK6DD4y2E4yVcP3jmCSp7Ebg"
//                @default = "bearer VaFY3KTq1bo234SVb2lz44s4QLKEdazPRTXHMOgjRr8t6jtt6Mgl5qptkE9WCeogE9Quj0Tezsp9f339Fz5ujRMZtB8F-yMqpBjHlKx3WTRyqpCZSGPOZM6RjNjpFQPZMlzxE7j-bs-37g5_dH4hyyJRm7zIiVNxq6cL17nx7YUcE11Ca-cTq4Aj5qpNbSYJcfxiZLj_bUPn9LOtoJhxca4dr0buVGf1Z0JqmRziN9cUHgU4Ek9oLVPp0S7JkyTSjMIcRteASBXUdqHJiM1rB81kqk3eVYWaqE99QHhNInYWJbsHfuGecij7aYsDItscmE6Xr-nhv3UZXF4ObHgO9IkDmcJnO0T92ohf7yE8u1oysAosbXo0nHaJaBRfwtfevlpPGPnHaE3g06uX7BCo4sXSmQ-YuxjUm1QIj-0uYsmPWx0y1zzwASOhtknxpM6TYy5q931er9J-h4tjwLUdQ5-vTiq-p6aHkabsCikWBdo"
            });
        }
    }
}