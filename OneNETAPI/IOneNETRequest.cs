using System;
using System.Collections.Generic;

namespace OneNET.Api.Request
{
    /// <summary>
    /// OneNET请求接口。
    /// </summary>
    public interface IOneNETRequest<T> where T : OneNETResponse
    {
        /// <summary>
        /// 获取OneNET API的URL
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        String GetURL(OneNetContext context);

        HttpRequestMethod RequestMethod();

        /// <summary>
        /// 获取所有的Key-Value形式的文本请求参数字典。其中：
        /// Key: 请求参数名
        /// Value: 请求参数文本值
        /// </summary>
        /// <returns>文本请求参数字典</returns>
        IDictionary<string, Object> GetParameters();

        Object GetPostContent();

        /// <summary>
        /// 提前验证参数。
        /// </summary>
        void Validate();

        bool IsRequestForByte();
    }
}
