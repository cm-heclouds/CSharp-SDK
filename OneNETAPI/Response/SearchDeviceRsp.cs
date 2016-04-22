using System.Collections.Generic;
using OneNET.Api.Entity;

namespace OneNET.Api.Response
{
    /// <summary>
    /// 模糊查询设备信息
    /// </summary>
    public class SearchDeviceRsp : OneNETResponse
    {
        /// <summary>
        /// 模糊查询设备信息
        /// </summary>
        public SearchDeviceRsp()
        {
            Data = new DeviceRsp();
        }

        public DeviceRsp Data;
    }

    /// <summary>
    /// 模糊查询设备的相应
    /// </summary>
    public class DeviceRsp
    {
        /// <summary>
        /// 模糊查询设备的相应
        /// </summary>
        public DeviceRsp()
        {
            Devices = new List<DeviceBasicInfo>();
        }

        /// <summary>
        /// 设备查询结果数目
        /// </summary>
        public int Total_Count;

        /// <summary>
        /// 每页设备数
        /// </summary>
        public int Per_Page;

        /// <summary>
        /// 页数
        /// </summary>
        public int Page;

        /// <summary>
        /// 设备列表
        /// </summary>
        public List<DeviceBasicInfo> Devices;
    }
}