using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 获取命令从OneNET发往设备的响应结果
    /// </summary>
    public class GetCmdRespRequest : IOneNETRequest<CommonResponse>
    {
        private static String URI = "<scheme>://<API_ADDRESS>/cmds/<cmd_uuid>/resp";

        private static String CMD_UUID = "cmd_uuid";

        /// <summary>
        /// 命令唯一识别号
        /// </summary>
        public string CmdUuid;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 获取命令从OneNET发往设备的响应结果
        /// </summary>
        public GetCmdRespRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
            context.setContext(CMD_UUID, CmdUuid);
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

        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}