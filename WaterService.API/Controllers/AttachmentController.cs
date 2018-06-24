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
    /// 附件信息
    /// </summary>
    [Route("api/[controller]")]
    public class AttachmentController : BaseController
    {
        private readonly AttachmentService bll = new AttachmentService();
        /// <summary>
        ///新增
        /// </summary>
        /// <param name="attachment"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel AddInfo([FromBody] AttachmentInfo attachment)
        {
            attachment.Create = User.Identity.GetCurrentUser().UserName;
            attachment.CreateDate = DateTime.Now;
            return GenerateResult("", "", bll.Add(attachment));
        }
        /// <summary>
        ///修改
        /// </summary>
        /// <param name="attachment"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody] AttachmentInfo attachment)
        {
            attachment.Modify = User.Identity.GetCurrentUser().UserName;
            attachment.ModifyDate = DateTime.Now;
            return GenerateResult("", "", bll.Update(attachment));
        }
        [HttpPost, Route("addOrUpdate")]

        public ResultModel AddOrUpdate([FromBody] List<AttachmentInfo> list)
        {
            list.ForEach(item =>
            {
                item.Create = User.Identity.GetCurrentUser().UserName;
                item.CreateDate = DateTime.Now;
            });
            return GenerateResult("", "", bll.AddOrUpdate(list));
        }
    }
}
