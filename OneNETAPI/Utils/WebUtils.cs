using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using OneNET.Api.Utils;
using WebSocketSharp.Net;

namespace OneNET.Api.Util
{
    /// <summary>
    /// 网络工具类。
    /// @author Philo 
    /// </summary>
    public sealed class WebUtils
    {
        private int _timeout = 30000;

        /// <summary>
        /// 请求与响应的超时时间
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        private int _rwtimeout = 60000;

        /// <summary>
        /// 请求与响应二进制流的超时时间
        /// </summary>
        public int ReadWriteTimeout
        {
            get { return _rwtimeout; }
            set { _rwtimeout = value; }
        }

        /// <summary>
        /// 执行HTTP GET请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="headers">请求地址头</param>
        /// <returns>HTTP响应</returns>
        public string DoGet(string url, IDictionary<string, string> parameters, string headers)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }

            var req = GetWebRequest(url, "GET", headers);
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            var rsp = (HttpWebResponse)req.GetResponse();
            var cSet = rsp.CharacterSet;
            if (string.IsNullOrEmpty(cSet))
            {
                cSet = "utf-8";
            }
            var encoding = Encoding.GetEncoding(cSet);
            return GetResponseAsString(rsp, encoding);
        }

        public byte[] DoGetBytes(string url, IDictionary<string, string> parameters, string headers)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }

            var req = GetWebRequest(url, "GET", headers);
            req.ReadWriteTimeout = ReadWriteTimeout;
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            var rsp = (HttpWebResponse)req.GetResponse();
            var cSet = rsp.CharacterSet;
            if (string.IsNullOrEmpty(cSet))
            {
                cSet = "utf-8";
            }
            var encoding = Encoding.GetEncoding(cSet);
            return GetResponseAsBytes(rsp, encoding);
        }

        /// <summary>
        /// 执行HTTP POST请求, post数据为json对象。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postBody">请求post的内容</param>
        /// <param name="header">请求地址头</param>
        /// <returns>HTTP响应</returns>
        public string DoPost(string url, Object postBody, string header)
        {
            var req = GetWebRequest(url, "POST", header);
            byte[] postData;
            var body = postBody as byte[];
            if (body != null)
            {
                req.ContentType = "application/octet-stream;charset=utf-8";
                postData = body;
            }
            else
            {
                req.ContentType = "application/json;charset=utf-8";
                var data = LowercaseJsonSerializer.SerializeObject(postBody);
                postData = Encoding.UTF8.GetBytes(data);
            }
            
            var reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            var rsp = (HttpWebResponse)req.GetResponse();
            var cSet = rsp.CharacterSet;
            if (string.IsNullOrEmpty(cSet))
            {
                cSet = "utf-8";
            }
            var encoding = Encoding.GetEncoding(cSet);
            return GetResponseAsString(rsp, encoding);
        }

        /// <summary>
        /// 执行HTTP PUT请求, put数据为json对象。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="putContent">请求put的内容</param>
        /// <param name="header">请求地址头</param>
        /// <returns>HTTP响应</returns>
        public string DoPut(string url, Object putContent, string header)
        {
            var req = GetWebRequest(url, "PUT", header);
            req.ContentType = "application/json;charset=utf-8";
            var data = LowercaseJsonSerializer.SerializeObject(putContent);
            var postData = Encoding.UTF8.GetBytes(data);
            var reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            var rsp = (HttpWebResponse)req.GetResponse();
            var cSet = rsp.CharacterSet;
            if (string.IsNullOrEmpty(cSet))
            {
                cSet = "utf-8";
            }
            var encoding = Encoding.GetEncoding(cSet);
            return GetResponseAsString(rsp, encoding);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public string DoDelete(string url, string header)
        {
            var req = GetWebRequest(url, "DELETE", header);
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            var rsp = (HttpWebResponse)req.GetResponse();
            var cSet = rsp.CharacterSet;
            if (string.IsNullOrEmpty(cSet))
            {
                cSet = "utf-8";
            }
            var encoding = Encoding.GetEncoding(cSet);
            return GetResponseAsString(rsp, encoding);
        }

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        { //直接确认，否则打不开
            return true;
        }

        public HttpWebRequest GetWebRequest(string url, string method, string headers)
        {
            HttpWebRequest req;
            if (url.Contains("https"))
            {
                ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
                req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                req = (HttpWebRequest)WebRequest.Create(url);
            }

            req.ServicePoint.Expect100Continue = false;
            req.Method = method;
            req.KeepAlive = true;
            req.UserAgent = "Top4Net";//todo
            req.Timeout = _timeout;
            req.Headers.Add(headers);
            return req;
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                if (stream != null) reader = new StreamReader(stream, encoding);
                return reader != null ? reader.ReadToEnd() : "";
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }

        /// <summary>
        /// 把响应流转换为二进制数据。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>二进制数据格式的响应内容</returns>
        public byte[] GetResponseAsBytes(HttpWebResponse rsp, Encoding encoding)
        {
            // 以字符流的方式读取HTTP响应
            var stream = rsp.GetResponseStream();
            if (stream == null) return null;
            var bytes = new List<byte>();
            var temp = stream.ReadByte();
            while (temp != -1)
            {
                bytes.Add((byte)temp);
                temp = stream.ReadByte();
            }
            return bytes.ToArray();
        }

        /// <summary>
        /// 组装GET请求URL。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>带参数的GET请求URL</returns>
        public string BuildGetUrl(string url, IDictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count <= 0) return url;
            if (url.Contains("?"))
            {
                url = url + "&" + BuildQuery(parameters);
            }
            else
            {
                url = url + "?" + BuildQuery(parameters);
            }
            return url;
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string BuildQuery(IDictionary<string, string> parameters)
        {
            var postData = new StringBuilder();
            var hasParam = false;

            var dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                var name = dem.Current.Key;
                var value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value)) continue;
                if (hasParam)
                {
                    postData.Append("&");
                }

                postData.Append(name);
                postData.Append("=");
                postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                hasParam = true;
            }

            return postData.ToString();
        }
    }
}