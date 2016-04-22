using System;
using System.Collections.Generic;
using OneNET.Api.Entity;
using OneNET.Api.Response;
using OneNET.Api.Util;

namespace OneNET.Api.Request
{
    /// <summary>
    /// 新增设备，增加成功后，会返回该设备的设备ID。
    /// </summary>
    public class NewDeviceRequest : IOneNETRequest<NewDeviceRsp>
    {
        public const String URI = "<scheme>://<API_ADDRESS>/devices";

        public Scheme Protocol;

        public DeviceBasicInfo NewDevice;

        //public new Object Location;

        private readonly IDictionary<string, string> otherParameters;

        /// <summary>
        /// 新增设备，增加成功后，会返回该设备的设备ID。
        /// </summary>
        public NewDeviceRequest()
        {
            NewDevice = new DeviceBasicInfo {Private = false};//新设备默认为私有
            otherParameters = new Dictionary<string, string>();
        }

        public String GetURL(OneNetContext context)
        {
            var url = URIUtils.fmtURI(URI, context);
            var webUtils = new WebUtils();
            return webUtils.BuildGetUrl(url, otherParameters);
        }

        public HttpRequestMethod RequestMethod()
        {
            return HttpRequestMethod.Post;
        }

        public IDictionary<string, Object> GetParameters()
        {
            var parameters = new OneNETDictionary();
            parameters.AddAll(otherParameters);

            return parameters;
        }

        public object GetPostContent()
        {
            return NewDevice;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(NewDevice.Title))
            {
                throw new OneNETException("请填写设备名称");
            }
            if (NewDevice.Location == null)
            {
                throw new OneNETException("请设置设备所在位置");
            }
        }

        public bool IsRequestForByte()
        {
            return false;
        }
    }
}
