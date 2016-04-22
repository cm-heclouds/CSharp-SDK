using System;
using System.Collections.Generic;

namespace OneNET.Api.Entity
{
    /// <summary>
    /// 描述一个数据流，内部包含一个数据流的id，还包含多个数据点。 在增加或者查看数据点时用
    /// @author Philo
    /// </summary>
    public class DataStream
    {
        /// <summary>
        /// 数据流的id
        /// </summary>
        public String ID;
        /// <summary>
        /// 多个数据点组成的链表
        /// </summary>
        public List<DataPoint> Datapoints;

        /// <summary>
        /// 统计数据点，可以为空，在向设备云查询数据点时，如果指定avg/max/min/sum等参数，通过此字段返回结果 在插入数据点时，此字段忽略
        /// </summary>
        public DataPoint Statistic;

        /// <summary>
        /// 描述一个数据流，内部包含一个数据流的id，还包含多个数据点。 在增加或者查看数据点时用
        /// </summary>
        public DataStream()
        {
            Datapoints = new List<DataPoint>();
        }
    }

    /// <summary>
    /// 新建数据点的数据实体封装
    /// </summary>
    public class NewDataPointData
    {
        /// <summary>
        /// 数据流
        /// </summary>
        public List<DataStreamSimple> DataStreams;

        /// <summary>
        /// 新建数据点的数据实体封装
        /// </summary>
        public NewDataPointData()
        {
            DataStreams = new List<DataStreamSimple>();
        }
    }

    /// <summary>
    /// 新建数据点的数据实体
    /// </summary>
    public class DataStreamSimple
    {
        /// <summary>
        /// 数据流的id
        /// </summary>
        public String ID;

        /// <summary>
        /// 多个数据点组成的链表
        /// </summary>
        public List<DataPointSimple> Datapoints;

        /// <summary>
        /// 新建数据点的数据实体
        /// </summary>
        public DataStreamSimple()
        {
            Datapoints = new List<DataPointSimple>();
        }
    }
}