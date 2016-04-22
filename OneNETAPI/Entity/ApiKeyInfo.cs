using System;
using System.Collections.Generic;

namespace OneNET.Api.Entity
{
    /// <summary>
    /// Api Key基础实体
    /// </summary>
    public class ApiKeyInfo
    {
        /// <summary>
        /// api key的名称
        /// </summary>
        public string Title;

        /// <summary>
        /// api key值
        /// </summary>
        public string Key;

        /// <summary>
        /// 创建时间（新增时请忽略）
        /// </summary>
        public DateTime Create_Time;

        /// <summary>
        /// 权限,包含资源和授权命令
        /// </summary>
        public List<Permission> Permissions;
        
        /// <summary>
        /// Api Key基础实体
        /// </summary>
        public ApiKeyInfo()
        {
            Permissions = new List<Permission>();
        }
    }

    /// <summary>
    /// 权限实体
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// 设备ID和数据流ID等资源集合
        /// </summary>
        public List<KeyResource> Resources;

        /// <summary>
        /// 被授权的命令，可选。如果没有，表示可以进行任何操作
        /// POST、GET、PUT、DELETE操作
        /// </summary>
        public string[] Access_Methods;

        /// <summary>
        /// 权限实体
        /// </summary>
        public Permission() 
        {
            Resources = new List<KeyResource>();
        }
    }

    /// <summary>
    /// api key对应资源
    /// </summary>
    public class KeyResource
    {
        /// <summary>
        /// 设备ID
        /// </summary>
        public string Dev_Id;

        /// <summary>
        /// 数据流ID（新增Key时忽略，更新时可选）
        /// </summary>
        public string Ds_Id;

        /// <summary>
        /// api key对应资源
        /// </summary>
        public KeyResource()
        {
        }
    }
}