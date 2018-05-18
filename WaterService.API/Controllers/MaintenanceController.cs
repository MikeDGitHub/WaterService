using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]MaintenanceInfo add)
        {
            var obj = new JObject();
            add.Create = User.Identity.GetCurrentUser().UserName;
            add.CreateDate = DateTime.Now;
            obj.Add("status", new BLL.MaintenanceService().Add(add));
            return Ok(obj);
        }
        [HttpPost, Route("queryList")]
        public IActionResult QueryList([FromBody]QueryModel query)
        {
            return Ok(new BLL.MaintenanceService().GetList(query));
        }
    }
}
