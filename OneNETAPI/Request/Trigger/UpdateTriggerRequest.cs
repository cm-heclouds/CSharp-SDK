using System;
using System.Collections.Generic;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 更新触发器
    /// 根据更新参数，全量设置对应项目
    /// </summary>
    public class UpdateTriggerRequest : IOneNETRequest<CommonResponse>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/triggers/<trigger_id>";
        
        /// <summary>
        /// 触发器ID参数
        /// </summary>
        public string TriggerID;

        /// <summary>
        /// 要更新的触发器内容
        /// </summary>
        public Trigger Trigger;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 更新触发器
        /// 根据更新参数，全量设置对应项目
        /// </summary>
        public UpdateTriggerRequest()
        {
            Trigger = new Trigger();
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
            return Trigger;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(TriggerID))
            {
                throw new OneNETException("请输入要更新的触发器ID");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}
