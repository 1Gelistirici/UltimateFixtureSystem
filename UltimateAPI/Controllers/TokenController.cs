﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.CallManager;
using UltimateAPI.Entities;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost("GenerateToken")]
        public IActionResult GenerateToken(User user)
        {
            TokenCallManager tokenCall = new TokenCallManager();
            var result = tokenCall.GenerateToken(user);
            return Content(ResultData.Get(result.IsSuccess, result.Message, result.Data));
        }


    }
}
