using BLL;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly UserService _bll = new UserService();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryInfo")]
        public ResultModel QueryUserInfoListByMeterId([FromBody] QueryInfo query)
        {
           return GenerateResult( _bll.QueryUserInfoListByMeterId(query.Id.ToString()),"");
        }
    }
}
