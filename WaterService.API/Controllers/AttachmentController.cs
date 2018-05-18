using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.WaterService;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    [Route("api/[controller]")]
    public class AttachmentController : BaseController
    {
        [HttpPost, Route("add")]
        public IActionResult AddInfo([FromBody] AttachmentInfo attachment)
        {
            attachment.Create = User.Identity.GetCurrentUser().UserName;
            attachment.CreateDate = DateTime.Now;
            var obj = new JObject();
            obj.Add("status", new BLL.AttachmentService().Add(attachment));
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody] AttachmentInfo attachment)
        {
            attachment.Modify = User.Identity.GetCurrentUser().UserName;
            attachment.ModifyDate = DateTime.Now;
            var obj = new JObject();
            obj.Add("status", new BLL.AttachmentService().Update(attachment));
            return Ok(obj);
        }
    }
}
