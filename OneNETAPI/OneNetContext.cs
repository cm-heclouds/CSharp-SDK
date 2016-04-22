using System;
using System.Collections.Generic;

namespace OneNET.Api
{
    /// <summary>
    /// 上下文封装
    /// @author Philo
    /// </summary>
    public class OneNetContext
    {
        /// <summary>
        /// 协议key，如http、https等等
        /// </summary>
        public static String SCHEME = "scheme";
        /// <summary>
        /// api地址，默认为api.heclouds.com
        /// </summary>
        public static String API_ADDRESS = "API_ADDRESS";

        // OneNet上下文环境，请求URL中问号的前半部分需要的参数保存在context中，这部分参数一般比较固定
        private IDictionary<String, Object> context = new Dictionary<String, Object>();
        // OneNet请求的参数，对应URL中问号后面的部分中包括的参数，这部分参数一般每次请求都不同
        private IDictionary<String, Object> parameter = new Dictionary<String, Object>();

        public OneNetContext()
        {
            context.Add(SCHEME, Scheme.HTTP.GetSchemeString());
        }

        public OneNetContext(OneNetContext context)
        {
            this.context.Add(SCHEME, Scheme.HTTP.GetSchemeString());
            this.context = this.context.Merge(context.context);
            parameter = parameter.Merge(context.parameter);
        }

        public IDictionary<String, Object> getContext()
        {
            return context;
        }

        public IDictionary<String, Object> getParameter()
        {
            return parameter;
        }

        /**
         * 设置某个键值对
         * 
         * @param name
         * @param value
         */
        public void setContext(String name, Object value)
        {
            context.Add(name, value);
        }

        /**
         * 提取某个上下文的值
         * 
         * @param name
         * @return
         */
        public Object getContext(String name)
        {
            Object val;
            return context.TryGetValue(name, out val);
        }

        /**
         * 移除某个键值对
         * 
         * @param name
         * @return
         */
        public Object removeContext(String name)
        {
            return context.Remove(name);
        }

        public void removeAllContext()
        {
            context.Clear();
        }

        public void setParameter(String name, Object value)
        {
            parameter.Add(name, value);
        }

        public Object getParameter(String name)
        {
            Object val;
            return parameter.TryGetValue(name, out val);
        }

        public Object removeParameter(String name)
        {
            return parameter.Remove(name);
        }

        public void removeAllParameter()
        {
            parameter.Clear();
        }
    }
}