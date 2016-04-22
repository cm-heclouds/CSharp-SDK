using System;
using System.Collections.Generic;

namespace OneNET.Api.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class LogsResponse : OneNETResponse
    {
        public List<LogsResponseData> Data;

        public LogsResponse()
        {
            Data = new List<LogsResponseData>();
        }
    }

    public class LogsResponseData
    {
        public DateTime Log_Time;
        public string Url;
        public string Method;
        public DateTime Request_Time;
        public List<string> Request_Header;
        public string Request_Body;
        public int Return_Code;
        public DateTime Response_Time;

        //response_header current not available in the api
        //public List<string> Response_Header;
        public string Response_Body;
    }
}
