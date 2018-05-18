using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    [Route("api/[controller]")]
    public class SludgeController : BaseController
    {
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]SludgeAdd add)
        {
            var obj = new JObject();
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            obj.Add("status", new BLL.SludgeService().Add(add.User, add.Sludge, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]SludgeAdd add)
        {
            var obj = new JObject();
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.Sludge != null)
            {
                add.Sludge.Modify = User.Identity.GetCurrentUser().UserName;
                add.Sludge.ModifyDate = DateTime.Now;
            }
            obj.Add("status", new BLL.SludgeService().Update(add.User, add.Sludge, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("queryList")]
        public IActionResult QueryList([FromBody]QueryModel query)
        {
            return Ok(new BLL.SludgeService().GetList(query));
        }
    }
}
