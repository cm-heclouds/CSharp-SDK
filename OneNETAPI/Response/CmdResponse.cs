namespace OneNET.Api.Response
{
    /// <summary>
    /// 查询命令响应消息的内容描述
    /// </summary>
    public class CmdStatusData
    {
        /// <summary>
        /// 命令的执行状态 0：设备不在线|Device not online 1：命令已创建| Command Created 2：命令已发往设备|
        /// Command Sent 3：命令发往设备失败| Send Command Failed 4：设备正常响应| Command
        /// Response Received 5：命令执行超时| Command Response Timeout 6：设备响应消息过长 |
        /// Command Response Too Large
        /// </summary>
        public int? Status;
        public CmdStatus? CmdStatus 
        {
            get
            {
                if (Status.HasValue)
                {
                    return (CmdStatus)Status;
                }
                return null;
            }
        }

        public string Desc;
    }

    /// <summary>
    /// 查询命令状态的响应
    /// </summary>
    public class GetCmdStatusResp : OneNETResponse
    {
        /// <summary>
        /// 响应数据
        /// </summary>
        public CmdStatusData Data;

        /// <summary>
        /// 查询命令状态的响应
        /// </summary>
        public GetCmdStatusResp()
        {
            Data = new CmdStatusData();
        }
    }

    public class CmdSendRespData
    {
        /// <summary>
        /// 命令在设备云上的唯一编号
        /// </summary>
        public string Cmd_uuid;
    }

    /// <summary>
    /// 向设备发送命令的响应消息
    /// </summary>
    public class CmdSendResp : OneNETResponse
    {
        /// <summary>
        /// 响应数据
        /// </summary>
        public CmdSendRespData Data;

        /// <summary>
        /// 向设备发送命令的响应消息
        /// </summary>
        public CmdSendResp()
        {
            Data = new CmdSendRespData();
        }
    }
}