namespace OneNET.Api.Entity
{
    public class SearchDeviceReq
    {
        /// <summary>
        /// 设备id或title模糊查询
        /// </summary>
        public string Keywords;
        protected const string Key_WORDS = "key_words";

        public string Tag;
        protected const string TAG = "tag";

        
        public bool? OnLine;
        protected const string ONLINE = "online";

        /// <summary>
        /// 是否私有
        /// </summary>
        public bool? Private;
        protected const string PRIVATE = "private";

        /// <summary>
        /// 页码
        /// </summary>
        public int Page;
        protected const string PAGE = "page";

        /// <summary>
        /// 指定每页输出设备个数,可选,默认30，最多100
        /// </summary>
        public int PageSize;
        protected const string PER_PAGE = "per_page";

        /// <summary>
        /// 指定设备ID,可选,多个用逗号分隔，最多100个
        /// </summary>
        public string DeviceIds;
        protected const string DEVICE_ID = "device_id";

        /// <summary>
        /// 设备查询请求
        /// </summary>
        public SearchDeviceReq()
        {
            Page = 1;
            PageSize = 30;
        }
    }
}