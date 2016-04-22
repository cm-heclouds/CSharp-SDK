using System;
using System.Collections.Generic;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 新增触发器
    /// 说明：
    ///1、触发器的含义是：当指定范围内的数据点满足触发条件的要求时，会向url参数指定的地址发送post请求
    ///2、触发器有三种工作触发模式
    ///1)	在请求参数中单独指定了ds_id，不包括其他参数，那么当前项目下所有设备的数据流中数据流名称符合ds_id的数据都会进入触发判断逻辑；
    ///2)	在请求参数中单独指定了ds_uuids数组，那么只有这些指定的数据流会进入触发判断逻辑；
    ///3)	在请求参数中指定了ds_id和dev_ids，那么只有这些指定的设备的数据流会进入触发判断逻辑
    /// </summary>
    public class NewTriggerRequest : IOneNETRequest<NewTriggerRsp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/triggers";
        
        /// <summary>
        /// 要增加的触发器实体
        /// </summary>
        public NewTriggerInfo Trigger;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 新增触发器
        /// 说明：
        ///1、触发器的含义是：当指定范围内的数据点满足触发条件的要求时，会向url参数指定的地址发送post请求
        ///2、触发器有三种工作触发模式
        ///1)	在请求参数中单独指定了ds_id，不包括其他参数，那么当前项目下所有设备的数据流中数据流名称符合ds_id的数据都会进入触发判断逻辑；
        ///2)	在请求参数中单独指定了ds_uuids数组，那么只有这些指定的数据流会进入触发判断逻辑；
        ///3)	在请求参数中指定了ds_id和dev_ids，那么只有这些指定的设备的数据流会进入触发判断逻辑
        /// </summary>
        public NewTriggerRequest()
        {
            Trigger = new NewTriggerInfo();
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
            return Trigger;
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