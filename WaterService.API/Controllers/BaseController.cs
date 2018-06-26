using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 基类
    /// </summary>
    [Authorize]

    public class BaseController : Controller
    {
        [HttpGet]
        public ResultModel GenerateResult(object json, string msg, bool Status = true)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Status = Status;
            m.Json = json;
            m.Msg = msg;
            return m;
        }
    }
}
