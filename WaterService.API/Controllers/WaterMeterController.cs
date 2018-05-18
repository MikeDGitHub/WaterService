using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Model.WaterService;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    [Route("api/[controller]")]
    public class WaterMeterController : BaseController
    {
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]WaterMeterAdd add)
        {
            var obj = new JObject();
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            obj.Add("status", new BLL.WaterMeterService().Add(add.User, add.WaterMeter, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]WaterMeterAdd add)
        {
            var obj = new JObject();
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.WaterMeter != null)
            {
                add.WaterMeter.Modify = User.Identity.GetCurrentUser().UserName;
                add.WaterMeter.ModifyDate = DateTime.Now;
            }
            obj.Add("status", new BLL.WaterMeterService().Update(add.User, add.WaterMeter, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("queryList")]
        public IActionResult QueryList([FromBody]QueryModel query)
        {
            return Ok(new BLL.WaterMeterService().GetList(query));
        }
    }
}
