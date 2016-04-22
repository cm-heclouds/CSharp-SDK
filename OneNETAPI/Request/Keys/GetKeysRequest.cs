using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 查看API Key相关信息
    /// </summary>
    public class GetKeysRequest : IOneNETRequest<GetKeysResp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/keys";

        /// <summary>
        /// 可选，只查看该key相关信息
        /// </summary>
        public string Key;

        /// <summary>
        /// 可选,只查看与该设备相关的非master-key
        /// </summary>
        public string DeviceId;

        /// <summary>
        /// 指定页码, 可选
        /// </summary>
        public int Page;

        /// <summary>
        /// 指定每页输出个数,可选,默认10，最多100
        /// </summary>
        public int PerPage;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 查看API Key相关信息
        /// </summary>
        public GetKeysRequest()
        {
            Page = 1;
            PerPage = 10;
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
            var url = URIUtils.fmtURI(URI, context);
            otherParameters.Add("page", Page.ToString());
            otherParameters.Add("per_page", PerPage.ToString());
            otherParameters.Add("dev_id", DeviceId);
            otherParameters.Add("key", Key);

            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Get;
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
        }

        public bool IsRequestForByte() { return false; }
    }
}