using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 管线信息
    /// </summary>
    [Route("api/[controller]")]
    public class PipeLineController : BaseController
    {
        private readonly PipeLineService bll = new PipeLineService();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel Add([FromBody]PipeLineAdd add)
        {
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            return GenerateResult("", "", bll.Add(add.User, add.PipeLine, add.Track, add.List));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody]PipeLineAdd add)
        {
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.PipeLine != null)
            {
                add.PipeLine.Modify = User.Identity.GetCurrentUser().UserName;
                add.PipeLine.ModifyDate = DateTime.Now;
            }
            return GenerateResult("", "", bll.Update(add.User, add.PipeLine, add.Track, add.List));
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel QueryList([FromBody]SearchModel query)
        {
            return GenerateResult(bll.GetList(query), "");
        }
    }
}
