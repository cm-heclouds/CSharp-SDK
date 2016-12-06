using System;

namespace OneNET.Api.Entity
{
    /// <summary>
    /// 设备基本信息描述
    /// @author Philo
    /// </summary>
    public class DeviceBasicInfo
    {
        /// <summary>
        /// 设备基本信息描述
        /// </summary>
        public DeviceBasicInfo() 
        {
            Location = new LocationInfo();
        }

        /// <summary>
        /// 设备的id号
        /// </summary>
        public String Id;
        /// <summary>
        /// 设备是否在线，只对EDP设备有效
        /// </summary>
        public Boolean OnLine;
        /// <summary>
        /// 设备的名称
        /// </summary>
        public String Title;
        /// <summary>
        /// 设备的描述
        /// </summary>
        public String Desc;
        /// <summary>
        /// 设备的标签
        /// </summary>
        public String[] Tags;
        /// <summary>
        /// 设备的位置
        /// </summary>
        public LocationInfo Location;
        /// <summary>
        /// 设备是否公开，公开的设备可以在设备云门户上看到对应的设备
        /// </summary>
        public bool Private;

        /// <summary>
        /// 设备使用的协议，只可以为:"EDP","HTTP","JTEXT"
        /// </summary>
        public string Protocol;

        /// <summary>
        /// 设备创建的时间，格式为"2015-11-04 14:27:31"
        /// </summary>
        public String Create_Time;
        /// <summary>
        /// <para>对于MODBUS设备，应填写：{“登录报文的phone字段”:”登录报文的SVRPWD字段”}。对其他设备，此字段可选</para>
        /// <para>请注意：若要设置普通字符串格式的auth_info, 也请使用JRaw处理一次</para>
        /// <para>示例：new JRaw("testauthinfo123yyy"), new JRaw("{\"sim\":123456445}")</para>
        /// </summary>
        public Object Auth_Info;
        /// <summary>
        /// 对于MODBUS设备，表示设备云主动查询设备的时间间隔，单位秒，其他设备类型无效
        /// </summary>
        public int Interval;

        /// <summary>
        /// 其他信息
        /// <para>示例：new JRaw("{\"sim\":123456445}")</para>
        /// </summary>
        public Object Other;
    }
}