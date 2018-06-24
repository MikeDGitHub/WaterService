using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model.Oauth;
using Model.ViewModel;
using Model.WaterService;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 部门信息
    /// </summary>
    [Route("api/[controller]")]
    public class DepartmentController : BaseController
    {
        private readonly DepartmentService bll = new DepartmentService();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel AddInfo([FromBody] DepartmentInfo department)
        {
            department.Create = User.Identity.GetCurrentUser().UserName;
            department.CreateDate = DateTime.Now;

            return GenerateResult("", "", bll.Add(department));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody] DepartmentInfo department)
        {
            department.Modify = User.Identity.GetCurrentUser().UserName;
            department.ModifyDate = DateTime.Now;
            return GenerateResult("", "", bll.Update(department));
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet, Route("queryList")]
        public ResultModel GetList([FromQuery] int parentId = 0)
        {
            return GenerateResult(bll.GetList(parentId), "");
        }
    }
}
