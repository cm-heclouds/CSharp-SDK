using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 触发器模糊查询请求
    /// </summary>
    public class SearchTriggerRequest : IOneNETRequest<SearchTriggerRsp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/triggers";
        
        /// <summary>
        /// 触发器名称
        /// </summary>
        public string Title;

        /// <summary>
        /// 页码
        /// </summary>
        public int Page;

        /// <summary>
        /// 每页数目
        /// </summary>
        public int Per_Page;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 触发器模糊查询请求
        /// </summary>
        public SearchTriggerRequest()
        {
            Page = 1;
            Per_Page = 10;
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
            otherParameters.Add("title", Title);
            otherParameters.Add("page", Page.ToString());
            otherParameters.Add("per_page", Per_Page.ToString());
            var url = URIUtils.fmtURI(URI, context);
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

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}