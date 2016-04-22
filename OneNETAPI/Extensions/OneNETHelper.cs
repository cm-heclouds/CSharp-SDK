using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OneNET.Api
{
    /// <summary>
    /// 各种扩展方法
    /// @author Philo
    /// </summary>
    public static class OneNETHelper
    {
        public static string GetTriggerTypeString(this TriggerType type)
        {
            switch (type)
            {
                case TriggerType.Larger: return ">";
                case TriggerType.LargerOrEqual: return ">=";
                case TriggerType.Smaller: return "<";
                case TriggerType.SmallerOrEqual: return "<=";
                case TriggerType.Equal: return "==";
                case TriggerType.InOut: return "inout";
                case TriggerType.In: return "in";
                case TriggerType.Out: return "out";
                case TriggerType.Change: return "change";
                case TriggerType.Exp: return "exp";
                case TriggerType.Frozen: return "frozen";
                case TriggerType.Live: return "live";
                default: return type.ToString();
            }
        }

        public static string GetMethodString(this HttpRequestMethod method)
        {
            switch (method)
            {
                 case HttpRequestMethod.Get: return "get";
                 case HttpRequestMethod.Post: return "post";
                 case HttpRequestMethod.Put: return "put";
                 case HttpRequestMethod.Delete: return "delete";
                 default: return method.ToString();
            }
        }

        public static string GetSchemeString(this Scheme scheme)
        {
            switch (scheme)
            {
                case Scheme.HTTP: return "http";
                case Scheme.HTTPS: return "https";
                case Scheme.TCP: return "TCP";
                case Scheme.UDP: return "UDP";
                default: return scheme.ToString();
            }
        }

        ///<summary> 
        /// 序列化 
        /// </summary> 
        /// <param name="data">要序列化的对象</param> 
        /// <returns>返回存放序列化后的数据缓冲区</returns> 
        public static byte[] ToByteArray(this object data)
        {
            var formatter = new BinaryFormatter();
            var rems = new MemoryStream();
            formatter.Serialize(rems, data);
            return rems.GetBuffer();
        } 
    }
}