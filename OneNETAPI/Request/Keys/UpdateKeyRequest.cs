using System;
using System.Collections.Generic;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// api key更新请求
    /// </summary>
    public class UpdateKeyRequest : IOneNETRequest<CommonResponse>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/keys/<key_string>";
        private const String KEY_STRING = "key_string";

        /// <summary>
        /// 目的api key值
        /// </summary>
        public string KeyString;

        /// <summary>
        /// api key的更新内容
        /// </summary>
        public ApiKeyInfo KeyInfo;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// api key更新请求
        /// </summary>
        public UpdateKeyRequest()
        {
            KeyInfo = new ApiKeyInfo();
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
            return KeyInfo;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(KeyString))
            {
                throw new OneNETException("请输入要更新的Key值");
            }
        }

        public bool IsRequestForByte() { return false; }
    }
}