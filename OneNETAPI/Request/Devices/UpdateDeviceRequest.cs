using System;
using System.Collections.Generic;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 更新设备信息
    /// 更新时，更新哪个字段就只需要在DeviceInfo中包括哪个字段，不需要包含所有内容。
    /// </summary>
    public class UpdateDeviceRequest : IOneNETRequest<CommonResponse>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/devices/<device_id>";
        private const String DEVICE_ID = "device_id";
        /// <summary>
        /// 查询具体设备的ID参数
        /// </summary>
        public int DeviceID;

        /// <summary>
        /// 欲更新的设备信息
        /// </summary>
        public DeviceBasicInfo DeviceInfo;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 更新设备信息
        /// 更新时，更新哪个字段就只需要在DeviceInfo中包括哪个字段，不需要包含所有内容。
        /// </summary>
        public UpdateDeviceRequest()
        {
            DeviceInfo = new DeviceBasicInfo();
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
            return DeviceInfo;
        }

        public void Validate()
        {
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}
