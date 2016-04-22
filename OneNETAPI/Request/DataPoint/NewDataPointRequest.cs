using System;
using System.Collections.Generic;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 新增数据点
    /// 说明：如果添加的数据涉及多个数据流，则需要api key有权限访问所有数据流
    /// </summary>
    public class NewDataPointRequest : IOneNETRequest<CommonResponse>
    {
        public const String URI = "<scheme>://<API_ADDRESS>/devices/<device_id>/datapoints";
        public const String DEVICE_ID = "device_id";

        /// <summary>
        /// 目的设备ID
        /// </summary>
        public int DeviceID;

        /// <summary>
        /// 数据点
        /// </summary>
        public NewDataPointData Data; 

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 新增数据点
        /// 说明：如果添加的数据涉及多个数据流，则需要api key有权限访问所有数据流
        /// </summary>
        public NewDataPointRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
            context.setContext(DEVICE_ID, DeviceID);
            var url = URIUtils.fmtURI(URI, context);
            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Post;
        }

        public IDictionary<string, Object> GetParameters()
        {
            var parameters = new OneNETDictionary();
            parameters.AddAll(otherParameters);
            return parameters;
        }

        public object GetPostContent()
        {
            return Data;
        }

        public void Validate()
        {
            if (DeviceID <= 0)
            {
                throw new OneNETException("请输入要添加数据流的目的设备ID");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}