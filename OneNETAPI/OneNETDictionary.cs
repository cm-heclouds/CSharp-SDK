using System;
using System.Collections.Generic;

namespace OneNET.Api
{
    /// <summary>
    /// 符合OneNET习惯的纯字符串字典结构。
    /// </summary>
    public class OneNETDictionary : Dictionary<string, Object>
    {
        private const string DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public OneNETDictionary() { }

        public OneNETDictionary(IDictionary<string, Object> dictionary) : base(dictionary) { }

        /// <summary>
        /// 添加一个新的键值对。空键或者空值的键值对将会被忽略。
        /// </summary>
        /// <param name="key">键名称</param>
        /// <param name="value">键对应的值，目前支持：string, int, long, double, bool, DateTime类型</param>
        public void Add(string key, object value)
        {
            string strValue;

            if (value == null)
            {
                strValue = null;
            }
            else
            {
                var s = value as string;
                if (s != null)
                {
                    strValue = s;
                }
                else if (value is DateTime?)
                {
                    var dateTime = value as DateTime?;
                    strValue = dateTime.Value.ToString(DATE_TIME_FORMAT);
                }
                else if (value is int?)
                {
                    strValue = (value as int?).Value.ToString();
                }
                else if (value is long?)
                {
                    strValue = (value as long?).Value.ToString();
                }
                else if (value is double?)
                {
                    strValue = (value as double?).Value.ToString();
                }
                else if (value is bool?)
                {
                    strValue = (value as bool?).Value.ToString().ToLower();
                }
                else
                {
                    strValue = value.ToString();
                }
            }

            this.Add(key, strValue);
        }

        public new void Add(string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                base.Add(key, value);
            }
        }

        public void AddAll(IDictionary<string, string> dict)
        {
            if (dict == null || dict.Count <= 0) return;
            var kvps = dict.GetEnumerator();
            while (kvps.MoveNext())
            {
                var kvp = kvps.Current;
                Add(kvp.Key, kvp.Value);
            }
        }
    }
}
