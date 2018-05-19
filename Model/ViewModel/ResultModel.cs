using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Model.ViewModel
{
    /// <summary>
    /// 返回值
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// 状态值
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// json字符串
        /// </summary>
        public object Json { get; set; }
        /// <summary>
        /// true/false
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Msg { get; set; }
    }
}
