using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;
using UltimateAPI.Token.Helpers;
using UltimateAPI.Token.Model;

namespace UltimateAPI.Token
{
    public interface IGenerateToken
    {
        AuthenticateResponse Authenticate(User model);
    }
    
    public class GenerateToken : IGenerateToken
    {

        public AuthenticateResponse Authenticate(User model)
        {
            LoginCallManager login = new LoginCallManager();
            TokenCallManager tokenCallManager = new TokenCallManager();
            User userGen = new User();
            
            var user = login.Authenticate(model);

            // return null if user not found
            if (user.Data[0] == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user.Data[0]);

            userGen.Id = user.Data[0].Id;
            userGen.Token = token;
            tokenCallManager.GenerateToken(userGen);

            return new AuthenticateResponse(user.Data[0], token);
        }

        private string generateJwtToken(User user)
        {
            AppSettings _appSettings = new AppSettings();

            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }















    }
}
