using System;

namespace OneNET.Api.Entity
{
    /// <summary>
    /// 设备位置描述信息
    /// @author Philo
    /// </summary>
   public class LocationInfo
    {
        /// <summary>
        /// 高度
        /// </summary>
        public double ele;
        /// <summary>
        /// 经度
        /// </summary>
        public double lat;
        /// <summary>
        /// 纬度
        /// </summary>
        public double lon;

        /// <summary>
        /// 设备位置描述信息
        /// </summary>
        public LocationInfo()
        {
            ele = 0F;
            lat = 0F;
            lon = 0F;
        }

        /// <summary>
        /// 设备位置描述信息
        /// </summary>
        /// <param name="ele">高度</param>
        /// <param name="lat">经度</param>
        /// <param name="lon">纬度</param>
        public LocationInfo(double ele, double lat, double lon)
        {
            this.ele = ele;
            this.lat = lat;
            this.lon = lon;
        }

        public String ToOneNETString()
        {
            return "Location [ele=" + ele + ", lat=" + lat + ", lon=" + lon + "]";
        }
    }
}