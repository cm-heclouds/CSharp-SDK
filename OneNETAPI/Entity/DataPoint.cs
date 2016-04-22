using System;

namespace OneNET.Api.Entity
{
    /// <summary>
    /// 描述一个数据点，在增加或者查看数据点时用
    /// @author Philo
    /// </summary>
    public class DataPoint
    {
        /// <summary>
        /// 本数据所属的设备ID
        /// </summary>
        public String Dev_Id;
        /// <summary>
        /// 本数据所属的数据流的id
        /// </summary>
        public String Ds_Id;

        /// <summary>
        /// 本数据所产生的时间
        /// </summary>
        public String At;
        /// <summary>
        /// 本数据的值 （具体类型视情况而定，如果是复杂对象，就还需要对该字段做一次json解析）
        /// </summary>
        public Newtonsoft.Json.Linq.JRaw Value;

        public string GetValue()
        {
            return Value.ToString();
        }
        
        /// <summary>
        /// 描述一个数据点，在增加或者查看数据点时用
        /// </summary>
        public DataPoint()
        {
            At = null;
            //Value = "null";
        }

        /// <summary>
        /// 描述一个数据点，在增加或者查看数据点时用
        /// </summary>
        /// <param name="dev_id"></param>
        /// <param name="ds_id"></param>
        /// <param name="at"></param>
        public DataPoint(String dev_id, String ds_id, String at)
        {
            this.Dev_Id = dev_id;
            this.Ds_Id = ds_id;
            this.At = at;
        }
    }

    /// <summary>
    /// 数据点基础信息
    /// </summary>
    public class DataPointSimple
    {
        /// <summary>
        /// 本数据所产生的时间
        /// 上传数据时，At是可空字段，如果为空，则设备云会取当前时间。如果存在其格式必须为"2013-04-22T00:35:43"的形式。
        /// </summary>
        public String At;
        /// <summary>
        /// 本数据的值 （具体类型视情况而定，如果是复杂对象，就还需要对该字段做一次json解析）
        /// </summary>
        public Object Value;

        /// <summary>
        /// 数据点基础信息
        /// </summary>
        public DataPointSimple()
        {
        }
    }
}