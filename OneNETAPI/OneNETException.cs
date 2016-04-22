using System;
using System.Runtime.Serialization;

namespace OneNET.Api
{
    /// <summary>
    /// OneNET客户端异常。
    /// </summary>
    public class OneNETException : Exception
    {
        private readonly string _errorCode;
        private readonly string _errorMsg;

        public OneNETException() { }

        public OneNETException(string message) : base(message) { }

        protected OneNETException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public OneNETException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public OneNETException(string errorCode, string errorMsg)
            : base(errorCode + ":" + errorMsg)
        {
            this._errorCode = errorCode;
            this._errorMsg = errorMsg;
        }

        public string ErrorCode
        {
            get { return this._errorCode; }
        }

        public string ErrorMsg
        {
            get { return this._errorMsg; }
        }
    }
}