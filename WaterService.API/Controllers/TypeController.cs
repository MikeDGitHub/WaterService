using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL;
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
        private readonly TypeService bll = new TypeService();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel GetList([FromBody]SearchModel query)
        {
            return GenerateResult(bll.GetList(query), "");
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
            return GenerateResult("", "", bll.AddInfo(type));
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
            return GenerateResult("", "", bll.Update(type));
        }
        /// <summary>
        /// 查询通过ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("queryTypeInfo")]
        public ResultModel QueryTypeInfo([FromQuery] int id)
        {
            return GenerateResult(bll.QueryTypeInfo(id), "");
        }
    }
}
