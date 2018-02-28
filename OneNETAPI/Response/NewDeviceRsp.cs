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

    public class DeviceRegisterRsp : OneNETResponse
    {
        public DeviceRegisterResult Data;

        public DeviceRegisterRsp()
        {
            Data = new DeviceRegisterResult();
        }
    }

    public class DeviceRegisterResult: NewDeviceResult
    {
        public string Key;
    }
}
