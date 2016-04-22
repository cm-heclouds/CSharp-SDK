using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 查看某设备单个数据流信息
    /// api: [API_Host]/devices/[device_id]/datastreams/[datastream_id]
    /// @author Philo
    /// </summary>
    public class GetDataStreamRequest : IOneNETRequest<GetDataStreamRsp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/devices/<device_id>/datastreams/<datastream_id>";
        private const String DEVICE_ID = "device_id";
        private const String DATASTREAM_ID = "datastream_id";
        
        /// <summary>
        /// 目的设备ID
        /// </summary>
        public String DeviceID;
        /// <summary>
        /// 目的数据流ID
        /// </summary>
        public String DataStreamId;

        public Scheme Protocol;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 查看某设备单个数据流信息
        /// api: [API_Host]/devices/[device_id]/datastreams/[datastream_id]
        /// </summary>
        public GetDataStreamRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public String GetURL(OneNetContext context)
        {
            context.setContext(DEVICE_ID, DeviceID);
            context.setContext(DATASTREAM_ID, DataStreamId);
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
            otherParameters.Add(key, value);
        }
    }
}