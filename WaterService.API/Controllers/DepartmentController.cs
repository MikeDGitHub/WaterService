using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Oauth;
using Model.WaterService;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 部门
    /// </summary>
    [Route("api/[controller]")]
    public class DepartmentController : BaseController
    {
        [HttpPost, Route("add")]
        public IActionResult AddInfo([FromBody] DepartmentInfo department)
        {
            department.Create = User.Identity.GetCurrentUser().UserName;
            department.CreateDate = DateTime.Now;
            var obj = new JObject();
            obj.Add("status", new BLL.DepartmentService().Add(department));
            return Ok(obj);
        }

        [HttpPost, Route("update")]
        public IActionResult Update([FromBody] DepartmentInfo department)
        {
            department.Modify = User.Identity.GetCurrentUser().UserName;
            department.ModifyDate = DateTime.Now;
            var obj = new JObject();
            obj.Add("status", new BLL.DepartmentService().Update(department));
            return Ok(obj);
        }

        [HttpGet, Route("queryList")]
        public IActionResult GetList([FromQuery] int parentId = 0)
        {
            return Ok(new BLL.DepartmentService().GetList(parentId));
        }
    }
}
