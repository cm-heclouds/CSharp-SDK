using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OneNET.Api
{
    /// <summary>
    /// URL工具类，主要用于拼接和组装URL用
    /// @author Philo
    /// </summary>
    public static class URIUtils
    {
        private const string PATTERN = "<(.*?)>";
        private const String DEFAULT_CHARSET = "UTF-8";

        /// <summary>
        /// 组装API URL
        /// </summary>
        /// <param name="uri">形如"<scheme>://<API_ADDRESS>/keys"的字符串，其中会依据context中的内容替换<>中的内容</param>
        /// <param name="context">数值，用于组装URL</param>
        /// <returns></returns>
        public static String fmtURI(String uri, OneNetContext context)
        {
            var re = new Regex(PATTERN);
            var matches = re.Matches(uri);
            foreach (var match in matches)
            {
                object val;
                var m = match.ToString();
                var key = m.TrimStart('<').TrimEnd('>');
                context.getContext().TryGetValue(key, out val);
                if (val != null) uri = uri.Replace(m, val.ToString());
            }

            return uri;
        }

        public static IDictionary<T1, T2> Merge<T1, T2>(this IDictionary<T1, T2> first, IDictionary<T1, T2> second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            var merged = new Dictionary<T1, T2>();
            first.ToList().ForEach(kv => merged[kv.Key] = kv.Value);
            second.ToList().ForEach(kv => merged[kv.Key] = kv.Value);
            return merged;
        }
    }

    /// <summary>
    /// Schema表示访问设备云的模式，有http、https、tcp、udp等方式，这里默认为http
    /// @author Philo
    /// </summary>
    public enum Scheme
    {
        //HTTP("http"), HTTPS("https"), TCP("TCP"), UDP("UDP");
        HTTP = 0,
        HTTPS = 1,
        TCP = 2,
        UDP = 3
    }

    public enum HttpRequestMethod
    {
        Get = 0,
        Post = 1,
        Put =2,
        Delete = 3
    }

    public enum CmdStatus
    {
        OffLine = 0,
        CmdCreated = 1,
        CmdSent = 2,
        SendFailed = 3,
        Recieved = 4,
        TimeOut = 5,
        LargeCmdResp = 6
    }

    public enum TriggerType
    {
        Larger = 1,
        LargerOrEqual = 2,
        Smaller = 3,
        SmallerOrEqual = 4,
        Equal = 5,
        InOut = 6,
        In = 7, 
        Out = 8,
        Exp = 9,
        Change = 10,
        Frozen = 11,
        Live = 12
    }
}