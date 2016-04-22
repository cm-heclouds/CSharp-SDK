using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using OneNET.Api.Parser;
using OneNET.Api.Request;
using OneNET.Api.Util;

namespace OneNET.Api
{
    /// <summary>
    /// 基于REST的OneNET客户端。
    /// </summary>
    public class DefaultOneNETClient : IOneNETClient
    {
        public const string API_KEY = "api-key";
        public const string FORMAT = "format";
        public const string METHOD = "method";
        public const string TIMESTAMP = "timestamp";
        public const string VERSION = "v";
        //public const string SIGN = "sign";
        public const string SESSION = "session";
        public const string FORMAT_XML = "xml";
        public const string FORMAT_Json = "json";
        //public const string SDK_VERSION = "OneNET-sdk-net-20160218"; 

        private string appKey;
        private string format = FORMAT_Json;

        /// <summary>
        /// api请求的上下文，内部封装了一个Map，存储了请求相关的所有信息
        /// </summary>
        private OneNetContext context;

        ///// <summary>
        ///// 默认连接超时时间为15秒
        ///// </summary>
        //private int connectTimeout = 15000;
        ///// <summary>
        ///// 默认响应超时时间为30秒
        ///// </summary>
        //private int readTimeout = 30000;

        //private bool needCheckRequest = true;

        private WebUtils webUtils;
        private IOneNETLogger OneNETLogger;
        private bool disableParser; // 禁用响应结果解释
        private bool disableTrace; // 禁用日志调试功能
        private IDictionary<string, string> systemParameters; // 设置所有请求共享的系统级参数

        #region DefaultOneNETClient Constructors

        /// <summary>
        /// 基于REST的OneNET客户端。
        /// </summary>
        public DefaultOneNETClient(string serverUrl, string appKey)
        {
            this.appKey = appKey;
            this.context = new OneNetContext();
            this.context.setContext(OneNetContext.API_ADDRESS, serverUrl);

            this.webUtils = new WebUtils();
            this.OneNETLogger = new DefaultOneNETLogger();
        }

        /// <summary>
        /// 基于REST的OneNET客户端。
        /// </summary>
        public DefaultOneNETClient(string serverUrl, string appKey, string format)
            : this(serverUrl, appKey)
        {
            this.format = format;
        }

        #endregion

        public void SetOneNETLogger(IOneNETLogger OneNETLogger)
        {
            this.OneNETLogger = OneNETLogger;
        }

        /// <summary>
        /// 设置请求与响应的超时时间，默认值为30s
        /// </summary>
        /// <param name="timeout"></param>
        public void SetTimeout(int timeout)
        {
            this.webUtils.Timeout = timeout;
        }

        /// <summary>
        /// 设置请求与响应二进制流的超时时间，默认值为60s
        /// </summary>
        /// <param name="timeout"></param>
        public void SetReadWriteTimeout(int timeout)
        {
            this.webUtils.ReadWriteTimeout = timeout;
        }


        public void SetDisableParser(bool disableParser)
        {
            this.disableParser = disableParser;
        }

        public void SetDisableTrace(bool disableTrace)
        {
            this.disableTrace = disableTrace;
        }

        public void SetSystemParameters(IDictionary<string, string> systemParameters)
        {
            this.systemParameters = systemParameters;
        }

        #region IOneNETClient Members

        /// <summary>
        /// 执行请求
        /// </summary>
        /// <typeparam name="T">请求类型</typeparam>
        /// <param name="request">请求</param>
        /// <returns>请求的响应</returns>
        public T Execute<T>(IOneNETRequest<T> request) where T : OneNETResponse
        {
            return Execute(request, null);
        }

        public T Execute<T>(IOneNETRequest<T> request, string session) where T : OneNETResponse
        {
            return Execute(request, session, DateTime.Now);
        }

        public T Execute<T>(IOneNETRequest<T> request, string session, DateTime timestamp) where T : OneNETResponse
        {
            return DoExecute(request, session, timestamp);
        }

        #endregion

        private T DoExecute<T>(IOneNETRequest<T> request, string session, DateTime timestamp) where T : OneNETResponse
        {
            // 提前检查业务参数
            try
            {
                request.Validate();
            }
            catch (OneNETException e)
            {
                return CreateErrorResponse<T>(e.ErrorCode, e.ErrorMsg);
            }

            // 添加协议级请求参数
            var txtParams = new OneNETDictionary(request.GetParameters());
            txtParams.Add(VERSION, "2.0");
            txtParams.Add(FORMAT, format);
            txtParams.Add(TIMESTAMP, timestamp);
            txtParams.Add(SESSION, session);
            txtParams.AddAll(this.systemParameters);

            // 添加签名参数 (目前不需要)
            //txtParams.Add(SIGN, OneNETUtils.SignOneNETRequest(txtParams, appSecret));

            var paramStr = txtParams.Where(x => x.Value is string)
                .ToDictionary(k=>k.Key,v=>v.Value.ToString());
            
            var requestUrl = request.GetURL(context);
            var reqUrl = webUtils.BuildGetUrl(requestUrl, paramStr);
            try
            {
                var httpHeader = API_KEY + ":" + appKey;
                string body;
                byte[] bytesBody = null;
                switch (request.RequestMethod())
                {
                    case HttpRequestMethod.Get:
                    {
                        if (request.IsRequestForByte())
                        {
                            body = "";
                            bytesBody = webUtils.DoGetBytes(reqUrl, paramStr, httpHeader);
                        }
                        else
                        {
                            body = webUtils.DoGet(reqUrl, paramStr, httpHeader);
                        }
                        break;
                    }

                    case HttpRequestMethod.Post:
                        body = webUtils.DoPost(reqUrl, request.GetPostContent(), httpHeader); break;
                    case HttpRequestMethod.Put:
                        body = webUtils.DoPut(reqUrl, request.GetPostContent(), httpHeader); break;
                    case HttpRequestMethod.Delete:
                        body = webUtils.DoDelete(reqUrl, httpHeader); break;
                    default: body = webUtils.DoGet(reqUrl, paramStr, httpHeader); break;
                }
                
                // 解释响应结果
                
                T rsp;
                if (disableParser)
                {
                    rsp = Activator.CreateInstance<T>();
                    rsp.Body = body;
                }
                else
                {
                    if (FORMAT_XML.Equals(format))
                    {
                        var tp = new OneNETXmlParser();
                        rsp = tp.Parse<T>(body);
                    }
                    else
                    {
                        rsp = request.IsRequestForByte()
                            ? Activator.CreateInstance<T>()
                            : JsonConvert.DeserializeObject<T>(body);
                        if (bytesBody != null)
                        {
                            rsp.BinDataBody = bytesBody;
                        }
                        rsp.Body = body;
                    }
                }

                // 追踪错误的请求
                if (disableTrace || !rsp.IsError) return rsp;
                var sb = new StringBuilder(reqUrl).Append(" response error!\r\n").Append(rsp.Body);
                OneNETLogger.Warn(sb.ToString());
                return rsp;
            }
            catch (Exception e)
            {
                if (disableTrace) throw;
                var sb = new StringBuilder(reqUrl).Append(" request error!\r\n").Append(e.StackTrace);
                OneNETLogger.Error(sb.ToString());
                throw;
            }
        }

        private T CreateErrorResponse<T>(string errCode, string errMsg) where T : OneNETResponse
        {
            var rsp = Activator.CreateInstance<T>();
            rsp.ErrCode = errCode;
            rsp.Error = errMsg;

            if (FORMAT_XML.Equals(format))
            {
                var root = new XmlDocument();
                var bodyE = root.CreateElement("error_response");
                var codeE = root.CreateElement("code");
                codeE.InnerText = errCode;
                bodyE.AppendChild(codeE);
                var msgE = root.CreateElement("msg");
                msgE.InnerText = errMsg;
                bodyE.AppendChild(msgE);
                root.AppendChild(bodyE);
                rsp.Body = root.OuterXml;
            }
            else
            {
                IDictionary<string, object> errObj = new Dictionary<string, object>();
                errObj.Add("code", errCode);
                errObj.Add("msg", errMsg);
                IDictionary<string, object> root = new Dictionary<string, object>();
                root.Add("error_response", errObj);

                var body = JsonConvert.SerializeObject(root);
                rsp.Body = body;
            }
            return rsp;
        }
    }
}
