using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterAttrRequest: IOneNETRequest<CommonResponse>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/register_attr";

        /// <summary>
        /// 
        /// </summary>
        public DeviceRegisterAttr DeviceRegisterAttr;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 
        /// </summary>
        public RegisterAttrRequest()
        {
            DeviceRegisterAttr = new Entity.DeviceRegisterAttr();
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
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
            return DeviceRegisterAttr;
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
