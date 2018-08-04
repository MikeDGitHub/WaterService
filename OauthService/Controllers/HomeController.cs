using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OauthService.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet, Route("index")]
        public string Index()
        {
            return $"{DateTime.Now}";
        }
    }
}
