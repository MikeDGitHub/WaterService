using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Oauth;
using Model.ViewModel;
using Newtonsoft.Json.Linq;

namespace OauthService.Controllers
{
    /// <summary>
    /// 部门
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel AddDepartment([FromBody]DepartmentInfo department)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            if (new BLL.DepartmentService().CheckDepName(department.DepName))
            {
                m.Msg = "部门名称已存在。";
            }
            else
            {
                m.Status = new BLL.DepartmentService().Add(department);
            }
            return m;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody]DepartmentInfo department)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            if (new BLL.DepartmentService().CheckDepName(department.DepName))
            {
                m.Msg = "部门名称已存在。";
            }
            else
            {
                m.Status = new BLL.DepartmentService().Update(department);
            }
            return m;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel QueryList()
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Json = new BLL.DepartmentService().GetList();
            m.Status = true;
            return m;
        }
    }
}
