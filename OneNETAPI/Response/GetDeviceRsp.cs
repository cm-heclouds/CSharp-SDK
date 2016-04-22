using OneNET.Api.Entity;
using System;
using System.Collections.Generic;

namespace OneNET.Api.Response
{
    /// <summary>
    /// 查询设备信息的响应消息对应的描述, 用制定的设备ID去查看设备时响应消息
    /// @author Philo
    /// </summary>
    public class GetDeviceRsp : OneNETResponse
    {
        public KeyInfo KeyInfo { get; set; }
        public DeviceRspData Data { get; set; }

        /// <summary>
        /// 查询设备信息的响应消息对应的描述, 用制定的设备ID去查看设备时响应消息
        /// </summary>
        public GetDeviceRsp()
        {
            KeyInfo = new KeyInfo();
            Data = new DeviceRspData();
        }
    }

    public class KeyInfo
    {
        /**
         * 表示key的名称
         */
        public String Title;
        /**
         * 表示key的标识
         */
        public String Key;

        public String toString()
        {
            return "KeyInfo [title=" + Title + ", key=" + Key + "]";
        }
    }

    public class DeviceRspData : DeviceBasicInfo
    {
        /// <summary>
        /// 与设备关联的二进制数据的信息
        /// </summary>
        public List<BinaryInfo> Binary;
        /// <summary>
        /// 与设备关联的apikey的信息
        /// </summary>
        public List<KeyInfo> Keys;
        /// <summary>
        /// 本设备的数据流
        /// </summary>
        public List<DataStreamInfo> Datastreams;
    }
}