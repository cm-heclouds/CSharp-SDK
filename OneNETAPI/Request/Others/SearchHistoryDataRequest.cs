using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 查询历史数据请求
    /// </summary>
    public class SearchHistoryDataRequest : IOneNETRequest<SearchHistoryDataRsp>
    {
        public const String URI = "<scheme>://<API_ADDRESS>/datapoints";

        /// <summary>
        /// 目标设备ID
        /// </summary>
        public string DeviceID;

        /// <summary>
        /// 目标数据流ID
        /// </summary>
        public string DataStreamId;

        /// <summary>
        /// 指定开始时间,必选
        /// </summary>
        public DateTime Start;

        /// <summary>
        /// 指定结束时间,可选，间隔最大6小时
        /// </summary>
        public DateTime? End;

        /// <summary>
        /// datapoint个数，默认10，最大6000
        /// </summary>
        public int Limit;

        /// <summary>
        /// 查询条件返回结果超过limit条数时遍历的游标
        /// </summary>
        public string Cursor;

        /// <summary>
        /// 时间间隔，可选，默认600，单位秒，最大6小时
        /// </summary>
        public int? Duration;

        /// <summary>
        /// 指定页码, 可选
        /// </summary>
        public int Page;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 查询历史数据请求
        /// </summary>
        public SearchHistoryDataRequest()
        {
            Page = 1;//默认值
            Limit = 10;//默认值
            otherParameters = new Dictionary<string, string>();
        }

        public String GetURL(OneNetContext context)
        {
            otherParameters.Add("start", Start.ToString("s"));
            otherParameters.Add("device_id", DeviceID);
            otherParameters.Add("datastream_id", DataStreamId);
            if (End.HasValue)
            {
                otherParameters.Add("end", End.Value.ToString("s"));
            }
            otherParameters.Add("limit", Limit.ToString());
            otherParameters.Add("cursor", Cursor);
            if (Duration.HasValue)
            {
                otherParameters.Add("duration", Duration.ToString());    
            }
            otherParameters.Add("page", Page.ToString());

            var url = URIUtils.fmtURI(URI, context);
            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Get;
        }

        public IDictionary<string, Object> GetParameters()
        {
            var parameters = new OneNETDictionary();
            parameters.AddAll(otherParameters);
            return parameters;
        }

        public object GetPostContent()
        {
            return null;
        }

        public void Validate()
        {
            if (Start <= DateTime.MinValue)
            {
                throw new OneNETException("请输入开始时间");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}