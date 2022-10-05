using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoTangBn.Common
{
    public class General 
    {
        public static Guid GetIDInToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var temp = tokenHandler.ReadToken(token);

            var jwtToken = (JwtSecurityToken)temp;

            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);


            return userId;

        }
    }
}
