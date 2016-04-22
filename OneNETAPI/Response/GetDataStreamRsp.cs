using System;

namespace OneNET.Api.Response
{
    /// <summary>
    /// 用数据流ID查询数据流详情的响应包的数据内容
    /// @author Philo
    /// </summary>
    public class GetDataStreamRsp : OneNETResponse
    {
        /// <summary>
        /// 响应数据
        /// </summary>
        public DataStreamRspData Data { get; set; }

        /// <summary>
        /// 用数据流ID查询数据流详情的响应包的数据内容
        /// </summary>
        public GetDataStreamRsp()
        {
            Data = new DataStreamRspData();
        }
    }

    public class DataStreamBasic
    {
        /// <summary>
        /// 数据流的ID. 不能为空, 支持中文，但最好为英文
        /// 不能被更新
        /// </summary>
        public String ID;

        /// <summary>
        /// 数据流的单位
        /// </summary>
        public String Unit;

        /// <summary>
        /// 数据流的单位符号
        /// </summary>
        public String Unit_Symbol;

        /// <summary>
        /// 数据流的唯一标识
        /// </summary>
        public String[] Tags;
    }

    /// <summary>
    /// 
    /// </summary>
    public class DataStreamCommon : DataStreamBasic
    {
        /// <summary>
        /// 只有MODBUS设备填写，MODBUS命令，16进制字节字符串
        /// </summary>
        public string Cmd;

        /// <summary>
        /// 只有MODBUS设备填写，采集间隔，单位：秒
        /// </summary>
        public int? Interval;

        /// <summary>
        /// 只有MODBUS设备填写，最终结果处理方法，寄存器地址从A0开始,多个公式用分号间隔
        /// </summary>
        public string Formula;

        /// <summary>
        /// 数据流常用数据实体
        /// </summary>
        public DataStreamCommon()
        {
        }
    }

    public class DataStreamRspData : DataStreamBasic
    {
        /// <summary>
        /// 数据流的uuid
        /// </summary>
        public String Uuid;
        
        /// <summary>
        /// 数据流的创建时间
        /// </summary>
        public String Create_Time;
        /// <summary>
        /// 数据流的当前值
        /// </summary>
        public Object Current_Value;
        /// <summary>
        /// 数据流最后一次数据点更新的时间
        /// </summary>
        public String Update_At;
    }

    public class NewDataStreamRspData
    {
        /// <summary>
        /// 数据流唯一标识
        /// </summary>
        public string Ds_Uuid;
    }

    /// <summary>
    /// 新增数据流的响应
    /// </summary>
    public class NewDataStreamRsp : OneNETResponse
    {
        /// <summary>
        /// 响应数据
        /// </summary>
        public NewDataStreamRspData Data { get; set; }

        /// <summary>
        /// 新增数据流的响应
        /// </summary>
        public NewDataStreamRsp()
        {
            Data = new NewDataStreamRspData();
        }
    }
}