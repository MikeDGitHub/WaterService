using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using YuanXin.Framework;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    [Route("api/[controller]")]
    public class MainController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel QueryList([FromBody] MainQuery query)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Json = MainService.QueryList(query);
            m.Status = true;
            return m;
        }
    }
}
