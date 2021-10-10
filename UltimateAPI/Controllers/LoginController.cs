using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;
using UltimateAPI.Token;
using UltimateAPI.Token.Helpers;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost("Authenticate")]
        public IActionResult Authenticate(User user)
        {
            GenerateToken generateToken = new GenerateToken();
                    var result= generateToken.Authenticate(user);

           LoginCallManager login= new LoginCallManager();
            var exresult = login.Authenticate(user);
            exresult.Data[0].Token = result.Token;

            return Content(ResultData.Get(exresult.IsSuccess, exresult.Message, exresult.Data));
        }













    }
}
