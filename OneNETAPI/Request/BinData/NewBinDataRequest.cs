using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 添加二进制数据的请求
    /// </summary>
    public class NewBinDataRequest : IOneNETRequest<NewBinDataResp>
    {
        private static String URI = "<scheme>://<API_ADDRESS>/bindata";

        /// <summary>
        /// 该数据所属设备。
        /// </summary>
        public int DeviceID;
        /// <summary>
        /// 该数据所属数据流
        /// </summary>
        public String DatastreamId;

        /// <summary>
        /// 二进制数据
        /// </summary>
        public byte[] BinData;

        private static String DEVICE_ID = "device_id";
        private static String DATASTREAM_ID = "datastream_id";

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 添加二进制数据的请求
        /// </summary>
        public NewBinDataRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
            otherParameters.Add(DEVICE_ID, DeviceID.ToString());
            otherParameters.Add(DATASTREAM_ID, DatastreamId);

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
            return BinData;
        }

        public void Validate()
        {
            if (DeviceID <= 0)
            {
                throw new OneNETException("请输入要添加数据的目的设备ID");
            }
            if (string.IsNullOrEmpty(DatastreamId))
            {
                throw new OneNETException("请输入要添加数据的目的数据流ID");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}