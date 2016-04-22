using OneNET.Api.Entity;
using System.Collections.Generic;

namespace OneNET.Api.Response
{
    /// <summary>
    /// 新增触发器的响应
    /// </summary>
    public class NewTriggerRsp : OneNETResponse
    {
        public NewTriggerRspData Data;

        /// <summary>
        /// 新增触发器的响应
        /// </summary>
        public NewTriggerRsp()
        {
            Data = new NewTriggerRspData();
        }
    }

    public class NewTriggerRspData
    {
        /// <summary>
        /// 触发器ID
        /// </summary>
        public string Trigger_Id;
    }

    /// <summary>
    /// 查看单个触发器的sdk响应
    /// </summary>
    public class GetTriggerRsp : OneNETResponse
    {
        public Trigger Data;

        /// <summary>
        /// 查看单个触发器的sdk响应
        /// </summary>
        public GetTriggerRsp()
        {
            Data = new Trigger();
        }
    }

    /// <summary>
    /// 查询多个触发器的sdk响应
    /// </summary>
    public class SearchTriggerRsp : OneNETResponse
    {
        public SearchTriggerRspData Data;

        /// <summary>
        /// 查询多个触发器的sdk响应
        /// </summary>
        public SearchTriggerRsp()
        {
            Data = new SearchTriggerRspData();
        }
    }

    /// <summary>
    /// 触发器模糊查询响应数据实体
    /// </summary>
    public class SearchTriggerRspData
    {
        public int Total_Count;

        public int Per_Page;

        public int Page;

        /// <summary>
        /// 触发器
        /// </summary>
        public List<Trigger> Triggers;

        /// <summary>
        /// 触发器模糊查询响应数据实体
        /// </summary>
        public SearchTriggerRspData()
        {
            Triggers = new List<Trigger>();
        }
    }
}
