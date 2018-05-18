using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    [Route("api/[controller]")]
    public class PipeLineController : BaseController
    {
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody]PipeLineAdd add)
        {
            var obj = new JObject();
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            obj.Add("status", new BLL.PipeLineService().Add(add.User, add.PipeLine, add.Track, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]PipeLineAdd add)
        {
            var obj = new JObject();
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
            obj.Add("status", new BLL.PipeLineService().Update(add.User, add.PipeLine, add.Track, add.List));
            return Ok(obj);
        }
        [HttpPost, Route("queryList")]
        public IActionResult QueryList([FromBody]QueryModel query)
        {
            return Ok(new BLL.PipeLineService().GetList(query));
        }
    }
}
