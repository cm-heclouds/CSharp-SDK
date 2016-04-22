namespace OneNET.Api.Response
{
    public class NewDeviceRsp : OneNETResponse
    {
        public NewDeviceResult Data;

        public NewDeviceRsp()
        {
            Data = new NewDeviceResult();
        }
    }

    public class NewDeviceResult
    {
        public int Device_Id;
    }
}
