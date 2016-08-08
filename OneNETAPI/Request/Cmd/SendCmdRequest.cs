using System;
using System.Collections.Generic;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 发送数据到登录设备云的设备
    /// 发送数据：用户自定义Json或二进制数据（小于64K）
    /// </summary>
    public class SendCmdRequest : IOneNETRequest<CmdSendResp>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/cmds?device_id=<device_id>";
        private const String DEVICE_ID = "device_id";
        /// <summary>
        /// 查询具体设备的ID参数
        /// </summary>
        public int DeviceID;

        public Scheme Protocol;

        /// <summary>
        /// 命令内容(json或二进制流)
        /// </summary>
        public Object CmdContent;

        public bool IsByte;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 发送数据到登录设备云的设备
        /// 发送数据：用户自定义Json或二进制数据（小于64K）
        /// </summary>
        public SendCmdRequest()
        {
            otherParameters = new Dictionary<string, string>();
        }

        public string GetURL(OneNetContext context)
        {
            context.setContext(DEVICE_ID, DeviceID);
            var url = URIUtils.fmtURI(URI, context);
            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Post;
        }

        public IDictionary<string, Object> GetParameters()
        {
            var parameters = new OneNETDictionary();
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public object GetPostContent()
        {
            return CmdContent;
        }

        public void Validate()
        {
            if (DeviceID <= 0)
            {
                throw new OneNETException("请输入目标设备ID");
            }
        }

        public bool IsRequestForByte()
        {
            return IsByte;
        }
    }
}