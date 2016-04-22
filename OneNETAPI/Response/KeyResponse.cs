using System.Collections.Generic;
using OneNET.Api.Entity;

namespace OneNET.Api.Response
{
    public class NewKeyResp : OneNETResponse
    {
        public NewKeyRespData Data;

        public NewKeyResp()
        {
            Data = new NewKeyRespData();
        }
    }

    public class NewKeyRespData
    {
        /// <summary>
        /// api key值，具有唯一性
        /// </summary>
        public string Key;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetKeysResp : OneNETResponse
    {
        public GetKeysRespData Data;

        /// <summary>
        /// 
        /// </summary>
        public GetKeysResp()
        {
            Data = new GetKeysRespData();
        }
    }

    public class GetKeysRespData
    {
        public int Per_Page;

        public int Page;

        public int Total_Count;

        public List<ApiKeyInfo> Keys;

        public GetKeysRespData()
        {
            Keys = new List<ApiKeyInfo>();
        }
    }
}
