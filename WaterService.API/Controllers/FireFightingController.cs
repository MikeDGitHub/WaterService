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
    /// 消防
    /// </summary>
    [Route("api/[controller]")]
    public class FireFightingController : BaseController
    {
        private readonly FireFightingService _bll = new FireFightingService();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel Add([FromBody]FireFightingAdd add)
        {
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            var id = _bll.Add(add.User, add.FireFighting, add.List);
            add.FireFighting.FireFightingId = id;
            return GenerateResult(add.FireFighting, "",id!=0);

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody]FireFightingAdd add)
        {
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.FireFighting != null)
            {
                add.FireFighting.Modify = User.Identity.GetCurrentUser().UserName;
                add.FireFighting.ModifyDate = DateTime.Now;
            }
            return GenerateResult(_bll.Update(add.User, add.FireFighting, add.List), "");
        }
        /// <summary>
        ///查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel QueryList([FromBody]SearchModel query)
        {
            return GenerateResult(_bll.GetList(query), "");
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryInfo")]
        public ResultModel QueryInfo([FromBody] QueryInfo query)
        {
            return GenerateResult(MainService.QueryModel<FireFightingInfo>(query.Id, "FireFightingId"), "");
        }
    }
}
