using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    public class DeviceRegisterRequest : IOneNETRequest<DeviceRegisterRsp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/register_de";
        private const String Register_Code = "register_code";

        public Scheme Protocol;

        public DeviceRegisterInfo NewDevice;

        public String RegisterCode;

        private readonly IDictionary<string, string> otherParameters;

        /// <summary>
        /// 新增设备，增加成功后，会返回该设备的设备ID。
        /// </summary>
        public DeviceRegisterRequest()
        {
            NewDevice = new DeviceRegisterInfo();
            otherParameters = new Dictionary<string, string>();
        }

        public String GetURL(OneNetContext context)
        {
            otherParameters.Add(Register_Code, RegisterCode);
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
            return NewDevice;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(NewDevice.SN) && string.IsNullOrEmpty(NewDevice.Mac))
            {
                throw new OneNETException("SN和Mac不可同时为空。");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}
