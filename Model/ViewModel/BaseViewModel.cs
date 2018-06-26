using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace Model.ViewModel
{
    /// <summary>
    /// 基类
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <returns></returns>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        /// <returns></returns>
        public string UserName { get; set; }
        public string UserCode { get; set; }
        /// <summary>
        /// 用户地址
        /// </summary>
        /// <returns></returns>
        public string UserAddress { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        /// <returns></returns>
        public string UserPhone { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        public string Create { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        /// <returns></returns>
        public string Modify { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        public DateTime ModifyDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GenreId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GenreName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int TypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string TypeName { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <returns></returns>
        public List<AttachmentInfo> AttachmentList { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ViewModel : BaseViewModel
    {
        /// <summary>
        /// 口径
        /// </summary>
        public double Caliber { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lon { get; set; }

    }
    /// <summary>
    /// 基类
    /// </summary>
    public class BaseAdd
    {
        /// <summary>
        ///用户信息
        /// </summary>
        public Model.WaterService.UserInfo User { get; set; }
        /// <summary>
        ///附件
        /// </summary>
        public List<Model.WaterService.AttachmentInfo> List { get; set; }
    }

}
