using System;

namespace OneNET.Api
{
    /// <summary>
    /// 日志打点接口。
    /// </summary>
    public interface IOneNETLogger
    {
        void Error(string message);
        void Warn(string message);
        void Info(string message);
    }
}
