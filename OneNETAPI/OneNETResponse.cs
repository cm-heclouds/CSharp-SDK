using System;
using System.IO;
using System.Xml.Serialization;

namespace OneNET.Api
{
    [Serializable]
    public abstract class OneNETResponse
    {
        /// <summary>
        /// 错误编号
        /// </summary>
        public int Errno;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error;

        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrCode;

        /// <summary>
        /// 子错误码
        /// </summary>
        [XmlElement("sub_code")]
        public string SubErrCode { get; set; }

        /// <summary>
        /// 子错误信息
        /// </summary>
        [XmlElement("sub_msg")]
        public string SubErrMsg { get; set; }
		
		/// <summary>
        /// 禁止访问字段
        /// </summary>
        [XmlElement("OneNET_forbidden_fields")]
        public string OneNETForbiddenFields { get; set; }

        /// <summary>
        /// 响应原始内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 二进制数据响应内容
        /// </summary>
        public byte[] BinDataBody { get; set; }

        /// <summary>
        /// HTTP GET请求的URL
        /// </summary>
        public string ReqUrl { get; set; }

        /// <summary>
        /// 响应结果错误
        /// </summary>
        public bool IsError
        {
            get
            {
                return Errno != 0;
            }
        }
    }
}
