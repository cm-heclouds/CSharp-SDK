using System;
using System.Collections;

namespace OneNET.Api.Parser
{
    public delegate object DOneNETConvert(IOneNETReader reader, Type type);

    /// <summary>
    /// OneNET API响应读取器接口。响应格式可以是XML, JSON等等。
    /// </summary>
    public interface IOneNETReader
    {
        /// <summary>
        /// 判断响应中是否包含指定的属性。
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <returns>true/false</returns>
        bool HasReturnField(object name);

        /// <summary>
        /// 获取值类型属性的值。
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <returns>值对象</returns>
        object GetPrimitiveObject(object name);

        /// <summary>
        /// 获取引用类型的值。
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="type">引用类型</param>
        /// <param name="convert">转换器</param>
        /// <returns>引用对象</returns>
        object GetReferenceObject(object name, Type type, DOneNETConvert convert);

        /// <summary>
        /// 获取列表类型的值。
        /// </summary>
        /// <param name="listName">列表属性名称</param>
        /// <param name="itemName">列表项名称</param>
        /// <param name="type">引用类型</param>
        /// <param name="convert">转换器</param>
        /// <returns>列表对象</returns>
        IList GetListObjects(string listName, string itemName, Type type, DOneNETConvert convert);
    }
}
