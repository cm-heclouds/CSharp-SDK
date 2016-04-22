using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 查看命令发送状态
    /// </summary>
    public class GetCmdStatusRequest : IOneNETRequest<GetCmdStatusResp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/cmds/<cmd_uuid>";
        private const String CMD_UUID = "cmd_uuid";

        /// <summary>
        /// 命令唯一识别号
        /// </summary>
        public string CmdUuid;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 查看命令发送状态
        /// </summary>
        public GetCmdStatusRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Get;
        }

        public String GetURL(OneNetContext context)
        {
            context.setContext(CMD_UUID, CmdUuid);
            var url = URIUtils.fmtURI(URI, context);
            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public IDictionary<string, Object> GetParameters()
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