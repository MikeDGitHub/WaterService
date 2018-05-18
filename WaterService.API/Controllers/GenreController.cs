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
    /// 类型
    /// </summary>
    [Route("api/[controller]")]
    public class GenreController : BaseController
    {
        [HttpPost, Route("queryList")]
        public IActionResult GetList([FromBody]QueryModel query)
        {
            return Ok(new BLL.GenreService().GetList(query));
        }
        [HttpPost, Route("add")]
        public IActionResult AddInfo([FromBody]GenreInfo genre)
        {
            genre.Create = User.Identity.GetCurrentUser().UserName;
            genre.CreateDate = DateTime.Now;
            var obj = new JObject();
            obj.Add("status", new BLL.GenreService().AddInfo(genre));
            return Ok(obj);
        }
        [HttpPost, Route("update")]
        public IActionResult Update([FromBody]GenreInfo genre)
        {
            genre.Modify = User.Identity.GetCurrentUser().UserName;
            genre.ModifyDate = DateTime.Now;
            var obj = new JObject();
            obj.Add("status", new BLL.GenreService().Update(genre));
            return Ok(obj);
        }

        [HttpGet, Route("queryGenreInfo")]
        public IActionResult QueryGenreInfo([FromQuery] int id)
        {
            return Ok(new BLL.GenreService().QueryGenreInfo(id));
        }
    }
}
