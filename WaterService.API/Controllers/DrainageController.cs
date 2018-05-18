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
    /// 排水
    /// </summary>
    [Route("api/[controller]")]
    public class DrainageController : BaseController
    {
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody] DrainageAdd add)
        {
            var obj = new JObject();
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            obj.Add("status", new BLL.DrainageService().Add(add.User, add.Drainage, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]DrainageAdd add)
        {
            var obj = new JObject();
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.Drainage != null)
            {
                add.Drainage.Modify = User.Identity.GetCurrentUser().UserName;
                add.Drainage.ModifyDate = DateTime.Now;
            }
            obj.Add("status", new BLL.DrainageService().Update(add.User, add.Drainage, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("queryList")]
        public IActionResult QueryList([FromBody]QueryModel query)
        {
            return Ok(new BLL.DrainageService().GetList(query));
        }
    }
}
