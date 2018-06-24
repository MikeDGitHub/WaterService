using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class ModelController : BaseController
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel QueryList()
        {
            return GenerateResult(new ModelService().QueryList(), "");
        }
    }
}
