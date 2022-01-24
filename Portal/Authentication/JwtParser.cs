using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Portal.Authentication
{
    public class JwtParser
    {
        public static void ExtractRolesFromJWT(List<Claim> claims, Dictionary<string,object> keyValuePairs)
        {
            keyValuePairs.TryGetValue(ClaimTypes.Role, out object role);
        }
        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch(base64.Length % 4)
            {
                case 2: 
                    base64 += "=="; 
                    break;
                case 3:
                    base64 += "=";
                    break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
