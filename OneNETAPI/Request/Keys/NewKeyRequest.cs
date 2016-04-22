using System;
using System.Collections.Generic;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// api key新增请求
    /// </summary>
    public class NewKeyRequest : IOneNETRequest<NewKeyResp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/keys";

        /// <summary>
        /// 新增key的内容
        /// </summary>
        public ApiKeyInfo KeyInfo;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// api key新增请求
        /// </summary>
        public NewKeyRequest()
        {
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
            return KeyInfo;
        }

        public void Validate()
        {
            
        }

        public bool IsRequestForByte() { return false; }
    }
}
