﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using Newtonsoft.Json.Linq;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 排泥信息
    /// </summary>
    [Route("api/[controller]")]
    public class SludgeController : BaseController
    {
        private readonly SludgeService bll = new SludgeService();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel Add([FromBody]SludgeAdd add)
        {
            add.User.Create = User.Identity.GetCurrentUser().UserName;
            add.User.CreateDate = DateTime.Now;
            return GenerateResult("", "", bll.Add(add.User, add.Sludge, add.List));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody]SludgeAdd add)
        {
            if (add.User != null)
            {
                add.User.Modify = User.Identity.GetCurrentUser().UserName;
                add.User.ModifyDate = DateTime.Now;
            }
            if (add.Sludge != null)
            {
                add.Sludge.Modify = User.Identity.GetCurrentUser().UserName;
                add.Sludge.ModifyDate = DateTime.Now;
            }
            return GenerateResult("", "", bll.Update(add.User, add.Sludge, add.List));
        }
        /// <summary>
        ///查询
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
