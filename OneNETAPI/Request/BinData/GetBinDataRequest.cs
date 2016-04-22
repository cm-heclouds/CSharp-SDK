using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 读取二进制数据
    /// 说明：目前将响应结果统一处理为byte[]返回，可按实际类型转存为图片、文本等其他格式
    /// </summary>
    public class GetBinDataRequest : IOneNETRequest<CommonResponse>
    {
        private static String URI = "<scheme>://<API_ADDRESS>/bindata/<index>";
        private static String INDEX = "index";

        /// <summary>
        /// 二进制数据在设备云的索引
        /// </summary>
        public string Index;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 读取二进制数据
        /// 说明：目前将响应结果统一处理为byte[]返回，可按实际类型转存为图片、文本等其他格式
        /// </summary>
        public GetBinDataRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
            context.setContext(INDEX, Index);

            var url = URIUtils.fmtURI(URI, context);
            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Get;
        }

        public IDictionary<string, Object> GetParameters()
        {
            var parameters = new OneNETDictionary();
            parameters.AddAll(otherParameters);
            return parameters;
        }

        public object GetPostContent()
        {
            return null;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Index))
            {
                throw new OneNETException("请输入要查询数据的索引");
            }
        }

        public bool IsRequestForByte()
        {
            return true;
        }
    }
}