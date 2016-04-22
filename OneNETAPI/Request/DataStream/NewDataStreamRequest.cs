using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 新增数据流
    /// 说明：
    /// 对于普通的非modbus设备，不要添加cmd、interval、formula等字段，否则可能会导致增加数据流失败。
    /// 新增数据流的id字段不能为空，否则可能会添加失败
    /// 新增数据流的id字段支持中文，但最好为英文，这样可以规避字符编码带来的问题
    /// </summary>
    public class NewDataStreamRequest : IOneNETRequest<NewDataStreamRsp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/devices/<device_id>/datastreams";
        private const String DEVICE_ID = "device_id";

        /// <summary>
        /// 目的设备ID
        /// </summary>
        public int DeviceID;

        /// <summary>
        /// 新设备的基础数据实体
        /// </summary>
        public DataStreamCommon DataStream;

        /// <summary>
        /// 新增数据流
        /// 说明：
        /// 对于普通的非modbus设备，不要添加cmd、interval、formula等字段，否则可能会导致增加数据流失败。
        /// 新增数据流的id字段不能为空，否则可能会添加失败
        /// 新增数据流的id字段支持中文，但最好为英文，这样可以规避字符编码带来的问题
        /// </summary>
        public NewDataStreamRequest()
        {
            DataStream = new DataStreamCommon();
            otherParameters = new Dictionary<string, string>();
        }

        private IDictionary<string, string> otherParameters;

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

        public IDictionary<string, object> GetParameters()
        {
            var parameters = new OneNETDictionary();
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public object GetPostContent()
        {
            return DataStream;
        }

        public void Validate()
        {
            if (DeviceID <= 0)
            {
                throw new OneNETException("请输入要添加数据流的目的设备ID");
            }
            if (string.IsNullOrEmpty(DataStream.ID))
            {
                throw new OneNETException("请输入数据流ID");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}