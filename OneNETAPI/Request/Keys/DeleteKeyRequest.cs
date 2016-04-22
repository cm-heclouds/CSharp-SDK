using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 删除api key
    /// </summary>
    public class DeleteKeyRequest : IOneNETRequest<CommonResponse>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/keys/<key_string>";
        private const String KEY_STRING = "key_string";

        /// <summary>
        /// 目标key值
        /// </summary>
        public string KeyString;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 删除api key
        /// </summary>
        public DeleteKeyRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
            context.setContext(KEY_STRING, KeyString);
            var url = URIUtils.fmtURI(URI, context);
            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Delete;
        }

        public IDictionary<string, object> GetParameters()
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
            if (string.IsNullOrEmpty(KeyString))
            {
                throw new OneNETException("请输入要删除的Key值");
            }
        }

        public bool IsRequestForByte() { return false; }
    }
}