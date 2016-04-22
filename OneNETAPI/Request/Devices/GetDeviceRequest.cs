using OneNET.Api.Response;
using System;
using System.Collections.Generic;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 获取设备信息(单个设备)
    /// api: [API_Host]/devices/[device_id]
    /// @author Philo
    /// </summary>
    public class GetDeviceRequest : IOneNETRequest<GetDeviceRsp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/devices/<device_id>";
        private const String DEVICE_ID = "device_id";
        /// <summary>
        /// 查询具体设备的ID参数
        /// </summary>
        public string DeviceID;

        public Scheme Protocol;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 获取设备信息(单个设备)
        /// </summary>
        public GetDeviceRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        #region IOneNETRequest Members

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Get;
        }

        public String GetURL(OneNetContext context)
        {
            context.setContext(DEVICE_ID, DeviceID);
            var url = URIUtils.fmtURI(URI, context);
            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public IDictionary<string, Object> GetParameters()
        {
            var parameters = new OneNETDictionary();
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public object GetPostContent()
        {
            return null;
        }

        public void Validate()
        {
            //RequestValidator.ValidateRequired(DEVICE_ID, this.DeviceID);//todo
        }

        public bool IsRequestForByte()
        {
            return false;
        }

        #endregion

        public void AddOtherParameter(string key, string value)
        {
            this.otherParameters.Add(key, value);
        }
    }
}