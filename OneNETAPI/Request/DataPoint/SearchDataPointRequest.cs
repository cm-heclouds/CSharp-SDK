using System;
using System.Collections.Generic;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 获取某个设备的数据点
    /// api: [API_Host]/devices/[device_id]/datapoints?parameters
    /// @author Philo
    /// </summary>
    public class SearchDataPointRequest : SearchDataPointReq, IOneNETRequest<SearchDataPointRsp>
        //:IOneNETRequest<SearchDataPointReq, SearchDataPointRsp>
    {
        public const String URI = "<scheme>://<API_ADDRESS>/devices/<device_id>/datapoints";
        public const String DEVICE_ID = "device_id";
        
        /// <summary>
        /// 目的设备ID
        /// </summary>
        public String DeviceID;

        public Scheme Protocol;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 获取某个设备的数据点
        /// </summary>
        public SearchDataPointRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public String GetURL(OneNetContext context)
        {
            context.setContext(DEVICE_ID, DeviceID);
            otherParameters.Add(DatastreamID, DataStreamId);
            otherParameters.Add(START, StartTimeTxt);
            otherParameters.Add(END, EndTimeTxt);
            otherParameters.Add(LIMIT, Limit);
            otherParameters.Add(CURSOR, Cursor);
            otherParameters.Add(INTERVAL, Interval);
            otherParameters.Add(METHOD, Method);
            otherParameters.Add(FIRST, First);

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
        }

        public bool IsRequestForByte()
        {
            return false;
        }

        public void AddOtherParameter(string key, string value)
        {
            if (otherParameters == null)
            {
                otherParameters = new Dictionary<string, string>();
            }
            otherParameters.Add(key, value);
        }
    }
}