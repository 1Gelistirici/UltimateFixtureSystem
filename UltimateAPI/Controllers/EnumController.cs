using Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;
using UltimateDemerbas.Models;

namespace UltimateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        public ActionResult GetIsActiveTypes()
        {
            List<TextValue> typeList = new List<TextValue>();
            List<IsActive> datas = Enum.GetValues(typeof(IsActive)).Cast<IsActive>().ToList();
            foreach (IsActive logType in datas)
            {
                typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<IsActive>(logType.ToString()), Value = (int)logType });
            }

            return Content(ResultData.Get(true, "", typeList));
        }

    }
}
