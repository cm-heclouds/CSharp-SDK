using System.Collections.Generic;
using OneNET.Api.Entity;

namespace OneNET.Api.Response
{
    /// <summary>
    /// 历史数据查询
    /// 说明：根据条件查询该用户下的数据点记录。
    /// </summary>
    public class SearchHistoryDataRsp : OneNETResponse
    {
        /// <summary>
        /// 响应数据
        /// </summary>
        public SearchHistoryData Data;

        /// <summary>
        /// 历史数据查询
        /// 说明：根据条件查询该用户下的数据点记录。
        /// </summary>
        public SearchHistoryDataRsp()
        {
            Data = new SearchHistoryData();
        }
    }

    public class SearchHistoryData
    {
        /// <summary>
        /// 数据点
        /// </summary>
        public List<DataPoint> DataPoints;

        public string Cursor;

        /// <summary>
        /// 历史数据响应体数据
        /// </summary>
        public SearchHistoryData()
        {
            DataPoints = new List<DataPoint>();
        }
    }
}