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
    /// 维保信息
    /// </summary>
    [Route("api/[controller]")]
    public class MaintenanceController : BaseController
    {
        private readonly MaintenanceService bll = new MaintenanceService();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel Add([FromBody]MaintenanceInfo add)
        {
            add.Create = User.Identity.GetCurrentUser().UserName;
            add.CreateDate = DateTime.Now;
            return GenerateResult(bll.Add(add), "");
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel QueryList([FromBody]SearchModel query)
        {
            return null;
            //return GenerateResult(bll.GetList(query), "");
        }
    }
}
