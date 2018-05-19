using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Model.WaterService;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 阀门信息
    /// </summary>
    [Route("api/[controller]")]
    public class ValveController : BaseController
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel Add([FromBody]ValveAdd add)
        {
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Status = new BLL.ValveService().Add(add.User, add.Valve, add.List);
            return m;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody]ValveAdd add)
        {
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.Valve != null)
            {
                add.Valve.Modify = User.Identity.GetCurrentUser().UserName;
                add.Valve.ModifyDate = DateTime.Now;
            }
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Status = new BLL.ValveService().Update(add.User, add.Valve, add.List);
            return m;
        }
        /// <summary>
        ///查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel QueryList([FromBody]SearchModel query)
        {
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Json = new BLL.ValveService().GetList(query);
            return m;
        }
    }
}
