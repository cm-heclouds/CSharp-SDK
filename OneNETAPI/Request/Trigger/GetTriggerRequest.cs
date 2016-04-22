using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 查看单个触发器
    /// </summary>
    public class GetTriggerRequest : IOneNETRequest<GetTriggerRsp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/triggers/<trigger_id>";
        
        /// <summary>
        /// 触发器ID参数
        /// </summary>
        public string TriggerID;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 查看单个触发器
        /// </summary>
        public GetTriggerRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
            context.setContext("trigger_id", TriggerID);
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
            if (string.IsNullOrEmpty(TriggerID))
            {
                throw new OneNETException("请输入要查询的触发器ID");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}