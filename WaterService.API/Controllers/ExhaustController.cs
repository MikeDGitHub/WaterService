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
    /// 排气信息
    /// </summary>
    [Route("api/[controller]")]
    public class ExhaustController : BaseController
    {
        private readonly ExhaustService _bll = new ExhaustService();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel Add([FromBody]ExhaustAdd add)
        {
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            var id = _bll.Add(add.User, add.Exhaust, add.List);
            add.Exhaust.ExhaustId = id;
            return GenerateResult(add.Exhaust, "", id != 0);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody]ExhaustAdd add)
        {
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.Exhaust != null)
            {
                add.Exhaust.Modify = User.Identity.GetCurrentUser().UserName;
                add.Exhaust.ModifyDate = DateTime.Now;
            }
            return GenerateResult(_bll.Update(add.User, add.Exhaust, add.List), "");
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel QueryList([FromBody] Model.ViewModel.SearchModel query)
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
            return GenerateResult(MainService.QueryModel<ExhaustInfo>(query.Id, "ExhaustId"), "");
        }
    }
}
