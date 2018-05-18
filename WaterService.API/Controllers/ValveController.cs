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
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class ValveController : BaseController
    {
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]ValveAdd add)
        {
            //new BLL.ValveService().Add1(add.User, add.Valve, add.List);
            var obj = new JObject();
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            obj.Add("status", new BLL.ValveService().Add(add.User, add.Valve, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]ValveAdd add)
        {
            var obj = new JObject();
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.Valve != null)
            {
                add.Valve.Modify = User.Identity.GetCurrentUser().UserName;
                add.Valve.ModifyDate = DateTime.Now;
            }
            obj.Add("status", new BLL.ValveService().Update(add.User, add.Valve, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("queryList")]
        public IActionResult QueryList([FromBody]QueryModel query)
        {
            return Ok(new BLL.ValveService().GetList(query));
        }
    }
}
