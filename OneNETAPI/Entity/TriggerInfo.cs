namespace OneNET.Api.Entity
{
    /// <summary>
    /// 触发器的基础数据
    /// </summary>
    public class Trigger
    {
        /// <summary>
        /// 触发器ID
        /// </summary>
        public string Id;

        /// <summary>
        /// 触发器名称
        /// </summary>
        public string Title;

        /// <summary>
        /// 触发器发送目的url
        /// </summary>
        public string Url;

        /// <summary>
        /// 数据流唯一识别号数组
        /// </summary>
        public string[] Ds_UUIds;

        /// <summary>
        /// 注：
        /// 1)type为大小等于等比较类型时，threshold必须为数值
        /// 2)type为inout时，threshold设置为{“lolmt”:40, “uplmt”:52}，表示数据流的值首次进入或离开闭区间[40,52]时触发；
        /// 3)type为exp时,threshold设置为字符串类型的条件表达式，$val[0]表示第一个数据流的当前值，$val[1]为第二个…。
        /// 4)type为change时，threshold 参数不用传递；当上传的值有改变时触发告警。
        /// 5)type为frozen时，threshold 为数值，指定多少秒内未上报数据触发告警，同时被监控对象进入frozen状态。
        /// 6)type为live时，threshold不用传递；被监控对象在frozen状态下收到上报的数据点时，触发告警。
        /// </summary>
        public object Threshold;

        /// <summary>
        /// 赋值时，请从枚举TriggerType GetTriggerTypeString
        /// </summary>
        public string Type;

        /// <summary>
        /// 触发器是否已失效,新增时请忽略此字段
        /// </summary>
        public bool? Invalid;

        /// <summary>
        /// 触发器的基础数据
        /// </summary>
        public Trigger()
        {
        }
    }

    /// <summary>
    /// 新增触发器实体
    /// </summary>
    public class NewTriggerInfo : Trigger
    {
        /// <summary>
        /// 数据流ID, 可选
        /// </summary>
        public string Ds_Id;

        /// <summary>
        /// 设备ID，可选
        /// </summary>
        public string[] Dev_Ids;

        /// <summary>
        /// 新增触发器实体
        /// </summary>
        public NewTriggerInfo()
        {
        }
    }
}