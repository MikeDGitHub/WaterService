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
    /// 类型(闸门，水表，管线，排水，消防，排泥，排气)
    /// </summary>
    [Route("api/[controller]")]
    public class GenreController : BaseController
    {
        private readonly GenreService bll = new GenreService();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("queryList")]
        public ResultModel GetList([FromBody]SearchModel query)
        {
            return GenerateResult(bll.GetList(query), "");
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpPost, Route("add")]
        public ResultModel AddInfo([FromBody]GenreInfo genre)
        {
            genre.Create = User.Identity.GetCurrentUser().UserName;
            genre.CreateDate = DateTime.Now;
            return GenerateResult("", "", bll.AddInfo(genre));
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public ResultModel Update([FromBody]GenreInfo genre)
        {
            genre.Modify = User.Identity.GetCurrentUser().UserName;
            genre.ModifyDate = DateTime.Now;
            return GenerateResult("", "", bll.Update(genre));
        }
        /// <summary>
        /// 查询根据ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("queryGenreInfo")]
        public ResultModel QueryGenreInfo([FromQuery] int id)
        {
            return GenerateResult(bll.QueryGenreInfo(id), "");
        }
    }
}
