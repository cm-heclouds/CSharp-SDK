using System;
using System.Collections.Generic;
using OneNET.Api.Entity;

namespace OneNET.Api.Response
{
    /// <summary>
    /// 查询数据点响应消息内容
    /// @author Philo
    /// </summary>
    public class SearchDataPointRsp : OneNETResponse
    {
        public DataPointsRspData Data { get; set; }
    }

    public class DataPointsRspData
    {
        /// <summary>
        /// 返回的数据点的数目
        /// </summary>
        public int Count;
        /// <summary>
        /// 响应数据的光标位置，如果数据一次可以提取完毕，就不存在此字段
        /// </summary>
        public String Cursor;
        /// <summary>
        /// 响应的数据流
        /// </summary>
        public List<DataStream> Datastreams;
    }
}