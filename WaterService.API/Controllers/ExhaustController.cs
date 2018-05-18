using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class ExhaustController : BaseController
    {
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]ExhaustAdd add)
        {
            var obj = new JObject();
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            obj.Add("status", new BLL.ExhaustService().Add(add.User, add.Exhaust, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]ExhaustAdd add)
        {
            var obj = new JObject();
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.Exhaust != null)
            {
                add.Exhaust.Modify = User.Identity.GetCurrentUser().UserName;
                add.Exhaust.ModifyDate = DateTime.Now;
            }
            obj.Add("status", new BLL.ExhaustService().Update(add.User, add.Exhaust, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("queryList")]
        public IActionResult QueryList([FromBody]QueryModel query)
        {
            return Ok(new BLL.ExhaustService().GetList(query));
        }
    }
}
