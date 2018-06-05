using System;
using System.Collections.Generic;
using System.Text;

namespace YuanXin.Framework
{
    public static class DistanceHelper
    {
        private const double EARTH_RADIUS = 6378137;//赤道半径(单位m)

        /// <summary>
        /// 转化为弧度(rad)
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double GetRad(double d)
        {
            return d * Math.PI / 180.0;
        }
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 根据一个给定经纬度的点和距离，进行附近地点查询
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="distance">距离（单位：公里或千米）</param>
        /// <returns>返回一个范围的4个点，最小纬度和纬度，最大经度和纬度</returns>
        public static PositionModel FindNeighPosition(double longitude, double latitude, double distance)
        {
            //先计算查询点的经纬度范围
            double r = EARTH_RADIUS / 1000;//地球半径千米
            double dis = distance;//0.5千米距离
            double dlng = 2 * Math.Asin(Math.Sin(dis / (2 * r)) / Math.Cos(latitude * Math.PI / 180));
            dlng = dlng * 180 / Math.PI;//角度转为弧度
            double dlat = dis / r;
            dlat = dlat * 180 / Math.PI;
            double minlat = latitude - dlat;
            double maxlat = latitude + dlat;
            double minlng = longitude - dlng;
            double maxlng = longitude + dlng;

            ////先计算查询点的经纬度范围  
            //double r = EARTH_RADIUS;//地球半径千米  
            //double dis = distance;//千米距离    
            //double dlng = 2 * Math.Asin(Math.Sin(dis / (2 * r)) / Math.Cos(latitude * Math.PI / 180));
            //dlng = dlng * 180 / Math.PI;//角度转为弧度  
            //double dlat = dis / r;
            //dlat = dlat * 180 / Math.PI;
            //double minlat = latitude - dlat;
            //double maxlat = latitude + dlat;
            //double minlng = longitude - dlng;
            //double maxlng = longitude + dlng;

            return new PositionModel
            {
                MinLat = minlat,
                MaxLat = maxlat,
                MinLng = minlng,
                MaxLng = maxlng
            };
        }

        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns></returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = GetRad(lat1);
            double radLng1 = GetRad(lng1);
            double radLat2 = GetRad(lat2);
            double radLng2 = GetRad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            result = Math.Round(result * 10000) / 10000;
            return result;
        }

        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位：公里或千米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns>返回两点的距离，单位：公里或千米</returns>
        public static double GetDistanceKM(double lat1, double lng1, double lat2, double lng2)
        {

            double radLat1 = GetRad(lat1);
            double radLng1 = GetRad(lng1);
            double radLat2 = GetRad(lat2);
            double radLng2 = GetRad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS / 1000;
            result = Math.Round(result * 10000) / 10000;
            return result;
        }

        /// <summary>
        /// 高德or百度 (未完成)
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns></returns>
        public static double GetDistanceGorB(double lat1, double lng1, double lat2, double lng2)
        {
            try
            {
                var b = Math.PI / 180;
                var c = Math.Sin((lat2 - lat1) * b / 2);
                var d = Math.Sin((lng2 - lng1) * b / 2);
                var a = c * c + d * d * Math.Cos(lat1 * b) * Math.Cos(lat2 * b);
                return 12756274 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //网上爬下来的js
        //public static double GetDistanceJS(double lat1, double lng1, double lat2, double lng2)
        //{
        //    if ((Math.Abs(lat1) > 90) || (Math.Abs(lat2) > 90))
        //    {
        //        //  document.getElementById("warning").innerHTML = ("兄台，这哪里是纬度啊？分明是想忽悠我嘛");
        //        //  return "耍我？拒绝计算！";
        //    }
        //    else
        //    {
        //        // hide("warning");
        //    }
        //    if ((Math.Abs(lng1) > 180) || (Math.Abs(lng2) > 180))
        //    {

        //        //  show("warning");
        //        //  document.getElementById("warning").innerHTML = ("兄台，这哪里是经度啊？分明是想忽悠我嘛");
        //        //  return "耍我？拒绝计算！";
        //    }
        //    else
        //    {
        //        // hide("warning");
        //    }
        //    var radLat1 = rad(lat1);
        //    var radLat2 = rad(lat2);
        //    var a = radLat1 - radLat2;
        //    var b = rad(lng1) - rad(lng2);
        //    var s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
        //    Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
        //    s = s * 6378.137;// EARTH_RADIUS;
        //    s = Math.Round(s * 10000) / 10000;
        //    return s;
        //}

        /// <summary>
        /// 根据经纬度计算距离 自己翻写的
        /// </summary>
        /// <param name="in_lat1">定位的维度</param>
        /// <param name="in_long1">定位的经度</param>
        /// <param name="in_lat2">商品的维度</param>
        /// <param name="in_long2">商品的经度</param>
        /// <returns></returns>
        //public static double GetJLDJ(double in_lat1, double in_long1, double in_lat2, double in_long2)
        //{
        //    double Distance;
        //    double RadLatBegin;
        //    double RadLatEnd;
        //    double RadLatDiff;
        //    double RadLngDiff;
        //    double pi = 3.1415926;
        //    double EARTH_RADIUS = 6378.137;

        //    RadLatBegin = in_lat1 * pi / 180.0;
        //    RadLatEnd = in_lat2 * pi / 180.0;
        //    RadLatDiff = RadLatBegin - RadLatEnd;
        //    RadLngDiff = in_long1 * pi / 180.0 - in_long2 * pi / 180.0;
        //    Distance = 2 * Math.Asin(
        //              Math.Sqrt(
        //                  Math.Pow(Math.Sin(RadLatDiff / 2), 2) + Math.Cos(RadLatBegin) * Math.Cos(RadLatEnd)
        //                  * Math.Pow(Math.Sin(RadLngDiff / 2), 2)
        //              )
        //          );

        //    Distance = Distance * EARTH_RADIUS;
        //    Distance = Math.Round(Distance, 2);
        //    return Distance;
        //}
    }

    public class PositionModel
    {

        /// <summary>
        /// 最小纬度
        /// </summary>
        public double MinLat { get; set; }

        /// <summary>
        /// 最大纬度
        /// </summary>
        public double MaxLat { get; set; }

        /// <summary>
        /// 最小经度
        /// </summary>
        public double MinLng { get; set; }

        /// <summary>
        /// 最大经度
        /// </summary>
        public double MaxLng { get; set; }
    }
}
