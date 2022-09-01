using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Mayhem.Util
{
    public class JwtSecurityTokenHelper
    {
        public static int GetUserId(HttpRequest request)
        {
            if (request == null)
            {
                return 0;
            }

            if (!string.IsNullOrEmpty(request.Headers[HeaderNames.Authorization]))
            {
                string token = Regex.Replace(request.Headers[HeaderNames.Authorization].ToString(), "Bearer ", "", RegexOptions.IgnoreCase);

                if (new JwtSecurityTokenHandler().ReadToken(token) is JwtSecurityToken jwtToken)
                {
                    return GetPayload(jwtToken, ClaimTypes.NameIdentifier);
                }
            }

            return 0;
        }

        public static int GetUserId(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                token = Regex.Replace(token, "Bearer ", "", RegexOptions.IgnoreCase);
                if (new JwtSecurityTokenHandler().ReadToken(token) is JwtSecurityToken jwtToken)
                {
                    return GetPayload(jwtToken, ClaimTypes.NameIdentifier);
                }
            }

            return 0;
        }

        public static int GetPayload(JwtSecurityToken jwtToken, string key)
        {
            KeyValuePair<string, object> payload = jwtToken.Payload.Where(x => x.Key.Equals(key)).SingleOrDefault();
            return Convert.ToInt32(payload.Value);
        }
    }
}
