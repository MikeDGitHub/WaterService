using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Model.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterService.API.Controllers
{
    /// <summary>
    /// 文件上传
    /// </summary>
    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        private readonly IHostingEnvironment _hostingEnv;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public FileUploadController(IHostingEnvironment env)
        {
            _hostingEnv = env;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("postFile")]

        public ResultModel PostFile()
        {
            var files = Request.Form.Files;
            List<string> filePathResultList = new List<string>();
            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
                string filePath = _hostingEnv.WebRootPath + $@"/img";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                fileName = Guid.NewGuid() + "." + fileName.Split('.')[1];
                string fileFullName = filePath + "//" + fileName;
                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                filePathResultList.Add($"/img/{fileName}");
            }
            var m = new ResultModel();
            m.StatusCode = HttpStatusCode.OK;
            m.Json = filePathResultList;
            m.Status = filePathResultList.Any();
            return m;
        }
    }
}
