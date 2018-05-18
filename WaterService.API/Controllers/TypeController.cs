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
    /// 类型
    /// </summary>
    [Route("api/[controller]")]
    public class TypeController : BaseController
    {
        [HttpPost, Route("queryList")]
        public IActionResult GetList([FromBody]QueryModel query)
        {
            return Ok(new BLL.TypeService().GetList(query));
        }
        [HttpPost, Route("add")]
        public IActionResult AddInfo([FromBody]TypeInfo type)
        {
            type.Create = User.Identity.GetCurrentUser().UserName;
            type.CreateDate = DateTime.Now;
            var obj = new JObject();
            obj.Add("status", new BLL.TypeService().AddInfo(type));
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]TypeInfo type)
        {
            type.Modify = User.Identity.GetCurrentUser().UserName;
            type.ModifyDate = DateTime.Now;
            var obj = new JObject();
            obj.Add("status", new BLL.TypeService().Update(type));
            return Ok(obj);
        }
        [HttpGet, Route("queryTypeInfo")]
        public IActionResult QueryTypeInfo([FromQuery] int id)
        {
            return Ok(new BLL.TypeService().QueryTypeInfo(id));
        }
    }
}
