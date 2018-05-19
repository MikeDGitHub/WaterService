using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 基类
    /// </summary>
    [Authorize]

    public class BaseController : Controller
    {

    }
}
