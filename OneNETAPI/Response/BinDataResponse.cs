namespace OneNET.Api.Response
{
    /// <summary>
    /// 新建二进制数据的响应
    /// </summary>
    public class NewBinDataResp : OneNETResponse
    {
        /// <summary>
        /// 响应数据
        /// </summary>
        public NewBinDataRespData Data;

        /// <summary>
        /// 新建二进制数据的响应
        /// </summary>
        public NewBinDataResp()
        {
            Data = new NewBinDataRespData();
        }
    }

    public class NewBinDataRespData
    {
        /// <summary>
        /// 二进制数据的索引值
        /// </summary>
        public string Index;
    }
}