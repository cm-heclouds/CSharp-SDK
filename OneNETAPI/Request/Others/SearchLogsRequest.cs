using OneNET.Api.Response;
using System;
using System.Collections.Generic;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 获取某个设备的日志信息(单个设备)
    /// 输出最近该设备restful操作日志20条，按时间倒排
    /// @author Philo
    /// </summary>
    public class SearchLogsRequest : IOneNETRequest<LogsResponse>
    {
        private const String URI = "<scheme>://<API_ADDRESS>/logs/<device_id>";
        private const String DEVICE_ID = "device_id";
        /// <summary>
        /// 设备的ID参数
        /// </summary>
        public string DeviceID;

        /// <summary>
        /// 要查询的最早日志时间
        /// </summary>
        public DateTime Start;

        public Scheme Protocol;

        private IDictionary<string, string> otherParameters;

        /// <summary>
        /// 获取某个设备的日志信息(单个设备)
        /// 输出最近该设备restful操作日志20条，按时间倒排
        /// </summary>
        public SearchLogsRequest()
        {

            otherParameters = new Dictionary<string, string>();
        }

        #region IOneNETRequest Members

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Get;
        }

        public String GetURL(OneNetContext context)
        {
            context.setContext(DEVICE_ID, DeviceID);
            otherParameters.Add("t_start", Start.ToString("s"));
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
            if (string.IsNullOrEmpty(DeviceID))
            {
                throw new OneNETException("请填写设备ID");
            }
            if (Start <= DateTime.MinValue)
            {
                throw new OneNETException("请填写日志开始时间");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }

        #endregion

        public void AddOtherParameter(string key, string value)
        {
            this.otherParameters.Add(key, value);
        }
    }
}