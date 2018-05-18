using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Oauth;
using Newtonsoft.Json.Linq;

namespace OauthService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        [HttpPost, Route("add")]
        public IActionResult AddDepartment([FromBody]DepartmentInfo department)
        {
            var obj = new JObject();
            obj.Add("status", 200);
            if (new BLL.DepartmentService().CheckDepName(department.DepName))
            {
                obj.Add("error", "部门名称已存在。");
            }
            else
            {
                obj.Add("error", new BLL.DepartmentService().Add(department));
            }
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]DepartmentInfo department)
        {
            var obj = new JObject();
            obj.Add("status", "ok");
            if (new BLL.DepartmentService().CheckDepName(department.DepName))
            {
                obj.Add("error", "部门名称已存在。");
            }
            else
            {
                obj.Add("error", new BLL.DepartmentService().Update(department));
            }
            return Ok(obj);
        }
    }
}
