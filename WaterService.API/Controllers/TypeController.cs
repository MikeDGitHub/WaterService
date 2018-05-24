using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel GetList([FromBody]SearchModel query)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Json = new BLL.TypeService().GetList(query);
            m.Status = true;
            return m;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel AddInfo([FromBody]TypeInfo type)
        {
            type.Create = User.Identity.GetCurrentUser().UserName;
            type.CreateDate = DateTime.Now;
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Status = new BLL.TypeService().AddInfo(type);
            return m;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody]TypeInfo type)
        {
            type.Modify = User.Identity.GetCurrentUser().UserName;
            type.ModifyDate = DateTime.Now;
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Status = new BLL.TypeService().Update(type);
            return m;
        }
        /// <summary>
        /// 查询通过ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("queryTypeInfo")]
        public ResultModel QueryTypeInfo([FromQuery] int id)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Json = new BLL.TypeService().QueryTypeInfo(id);
            m.Status = true;
            return m;
        }
    }
}
