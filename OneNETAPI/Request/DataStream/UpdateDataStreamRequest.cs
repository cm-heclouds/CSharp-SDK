using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 更新数据流主要更新数据流的单位、标签等信息
    /// 说明：请求消息中的的任何字段都可以为空。对于非MODBUS设备不要更新其cmd、interval、formula等字段，否则可能失败。
    /// </summary>
    public class UpdateDataStreamRequest : IOneNETRequest<CommonResponse>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/devices/<device_id>/datastreams/<datastream_id>";
        private const String DEVICE_ID = "device_id";
        private const String DATASTREAM_ID = "datastream_id";

        /// <summary>
        /// 目的设备ID
        /// </summary>
        public int DeviceID;
        /// <summary>
        /// 目的数据流ID
        /// </summary>
        public String DataStreamId;

        /// <summary>
        /// 数据流更新内容
        /// </summary>
        public DataStreamCommon DataStream;

        /// <summary>
        /// 更新数据流主要更新数据流的单位、标签等信息
        /// 说明：请求消息中的的任何字段都可以为空。对于非MODBUS设备不要更新其cmd、interval、formula等字段，否则可能失败。
        /// </summary>
        public UpdateDataStreamRequest()
        {
            DataStream = new DataStreamCommon();
            otherParameters = new Dictionary<string, string>();
        }
        private IDictionary<string, string> otherParameters;

        public string GetURL(OneNetContext context)
        {
            context.setContext(DEVICE_ID, DeviceID);
            context.setContext(DATASTREAM_ID, DataStreamId);

            var url = URIUtils.fmtURI(URI, context);
            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Put;
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
                throw new OneNETException("请输入目标数据流所属设备ID");
            }
            if (string.IsNullOrEmpty(DataStreamId))
            {
                throw new OneNETException("请输入目标数据流ID");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}