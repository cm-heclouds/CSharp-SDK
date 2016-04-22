using System;

namespace OneNET.Api.Entity
{
    /// <summary>
    /// 数据流的概要信息，在查看设备的详情时，会返回本设备的所有数据流的概要信息 在查看具体数据流时，也会返回概要信息
    /// 请勿重构带下划线的命名，防止json转换失效
    /// @author Philo
    /// </summary>
    public class DataStreamInfo
    {
        /// <summary>
        /// 本数据流的单位
        /// </summary>
        public String Unit;
        /// <summary>
        /// 本数据流的创建时间
        /// </summary>
        public String Create_Time;
        /// <summary>
        /// 本数据流的单位符号
        /// </summary>
        public String Unit_Symbol;
        /// <summary>
        /// 本数据流的id
        /// </summary>
        public String ID;
        /// <summary>
        /// 本数据流的uuid，唯一标示
        /// </summary>
        public String Uuid;

        public String toString()
        {
            return "DataStreamInfo [unit=" + Unit + ", create_time=" + Create_Time + ", unit_symbol="
                    + Unit_Symbol + ", id=" + ID + ", uuid=" + Uuid + "]";
        }
    }
}