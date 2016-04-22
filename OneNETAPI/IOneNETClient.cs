using System;
using OneNET.Api.Request;

namespace OneNET.Api
{
    /// <summary>
    /// OneNET客户端。
    /// </summary>
    public interface IOneNETClient
    {
        /// <summary>
        /// 执行OneNET公开API请求。
        /// </summary>
        /// <typeparam name="T">领域对象</typeparam>
        /// <param name="request">具体的OneNET API请求</param>
        /// <returns>领域对象</returns>
        T Execute<T>(IOneNETRequest<T> request) where T : OneNETResponse;

        /// <summary>
        /// 执行OneNET隐私API请求。
        /// </summary>
        /// <typeparam name="T">领域对象</typeparam>
        /// <param name="request">具体的OneNET API请求</param>
        /// <param name="session">用户会话码</param>
        /// <returns>领域对象</returns>
        T Execute<T>(IOneNETRequest<T> request, string session) where T : OneNETResponse;

        /// <summary>
        /// 执行OneNET隐私API请求。
        /// </summary>
        /// <typeparam name="T">领域对象</typeparam>
        /// <param name="request">具体的OneNET API请求</param>
        /// <param name="session">用户会话码</param>
        /// <param name="timestamp">请求时间戳</param>
        /// <returns>领域对象</returns>
        T Execute<T>(IOneNETRequest<T> request, string session, DateTime timestamp) where T : OneNETResponse;
    }
}
