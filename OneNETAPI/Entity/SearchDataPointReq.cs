using System;

namespace OneNET.Api.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchDataPointReq//:ParamMap
    {
        public const long SerialVersionUid = 1L;
        /// <summary>
        /// 涉及的数据流,多个数据流之间用逗号分隔
        /// </summary>
        public string DataStreamId { get; set; }
        protected const String DatastreamID = "datastream_id";

        /// <summary>
        /// 表示提取数据点的开始时间，格式为2015-01-10T08:00:35
        /// </summary>
        public string StartTimeTxt { get; set; }
        protected const String START = "start";

        /// <summary>
        /// 表示提取数据点的结束时间，格式为2015-01-10T08:00:35
        /// </summary>
        public string EndTimeTxt { get; set; }
        protected const String END = "end";
        /// <summary>
        /// 限定本次请求最多返回的数据点的数量，取值大于0，小于等于6000
        /// </summary>
        public string Limit { get; set; }
        protected const String LIMIT = "limit";
        /// <summary>
        /// 指定本次请求继续从cursor位置开始提取数据
        /// </summary>
        public string Cursor { get; set; }
        protected const String CURSOR = "cursor";
        /// <summary>
        /// 指定通过采样方式返回数据点，interval值指定采样的时间间隔
        /// </summary>
        public string Interval { get; set; }
        protected const String INTERVAL = "interval";

        /// <summary>
        /// 指定在返回数据点时，同时返回统计结果，可能的值为sum/avg/min/max
        /// </summary>
        public string Method { get; set; }
        protected const String METHOD = "method";

        /// <summary>
        /// 返回结果中最值的时间点。1表示最早的时间，0表示最近的时间，默认为1
        /// </summary>
        public string First { get; set; }
        protected const String FIRST = "first";
    }
}