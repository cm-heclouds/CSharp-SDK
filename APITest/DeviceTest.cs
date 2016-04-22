using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNET.Api;
using OneNET.Api.Entity;
using OneNET.Api.Request;

namespace APITest
{
    [TestClass]
    public class DeviceTest
    {
        private const string url = "api.heclouds.com";
        private const string appkey = "Hf1hQbdPeOEwlYs04nyzmD2fdQw=";

        [TestMethod]
        public void TestGetDevice()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var req = new GetDeviceRequest { DeviceID = "768672", Protocol = Scheme.HTTP};
            var resp = client.Execute(req);
            Assert.IsFalse(resp.IsError);
            Assert.AreEqual(0, resp.Errno);
            Assert.AreEqual("succ", resp.Error);
            Assert.IsNotNull(resp.Data);
            Assert.IsNotNull(resp.Data.Datastreams);
            var first = resp.Data.Datastreams.FirstOrDefault();
            Assert.IsNotNull(first);
            Assert.IsNotNull(first.Create_Time);
            Console.WriteLine(resp.Body);
        }

        [TestMethod]
        public void TestSearchDevices()
        {
            var client = new DefaultOneNETClient(url, appkey, "");

            //test keywords
            var req = new SearchDeviceRequest
            {
                Protocol = Scheme.HTTP,
                Keywords = "768"
            };
            var resp = client.Execute(req);
            Assert.IsFalse(resp.IsError);
            Assert.AreEqual(0, resp.Errno);
            Assert.AreEqual("succ", resp.Error);
            Assert.IsNotNull(resp.Data);
            Assert.AreEqual(2, resp.Data.Total_Count);

            //test other para
            var req2 = new SearchDeviceRequest
            {
                Protocol = Scheme.HTTP,
                Private = false
            };
            var client2 = new DefaultOneNETClient(url, appkey, "");
            var resp2 = client2.Execute(req2);
            Assert.IsFalse(resp2.IsError);
            Assert.IsNotNull(resp2.Data);
            Assert.AreEqual(1, resp2.Data.Total_Count);
        }

        [TestMethod]
        public void TestAddDevice()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var device = new DeviceBasicInfo
            {
                Title = "测试C# SDK",
                Desc = "一次通过一次通过一次通过",
                Private = true,
                OnLine = false,
                Tags = new[] { "测试", "sdk" },
                Protocol = "HTTP",
                Location = new LocationInfo(370000, 17.609997, 177.03403)
            };
            var req = new NewDeviceRequest
            {
                Protocol = Scheme.HTTP,
                NewDevice = device
            };               
            var resp = client.Execute(req);
            Assert.IsFalse(resp.IsError);
            Assert.IsNotNull(resp.Data);
            Assert.IsTrue(resp.Data.Device_Id > 0);
        }

        [TestMethod]
        public void TestUpdateDevice()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var device = new DeviceBasicInfo
            {
                Title = "测试修改C# SDK的返回结果",
                Desc = "一次通过一次通过一次通过了吗？（update）",
                //Private = true,
                OnLine = true,
                //Tags = new[] { "测试", "sdk" },
                //Location = new LocationInfo(370000, 27.609997, 178.03403)
            };
            var req = new UpdateDeviceRequest { DeviceID = 776941, DeviceInfo = device };
            var resp = client.Execute(req);
            Assert.IsFalse(resp.IsError);
        }

        [TestMethod]
        public void DeleteAddDevice()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var device = new DeviceBasicInfo
            {
                Title = "测试C# SDK",
                Desc = "一次通过一次通过一次通过",
                Private = true,
                OnLine = false,
                Tags = new[] { "测试", "sdk" },
                Protocol = "HTTP",
                Location = new LocationInfo(370000, 17.609997, 177.03403)
            };
            var req = new NewDeviceRequest
            {
                Protocol = Scheme.HTTP,
                NewDevice = device
            };
            var resp = client.Execute(req);
            Assert.IsFalse(resp.IsError);
            Assert.IsNotNull(resp.Data);
            Console.WriteLine(resp.Data.Device_Id);

            //delete
            var delReq = new DeleteDeviceRequest { DeviceID = resp.Data.Device_Id };
            var delResp = client.Execute(delReq);
            Assert.IsFalse(delResp.IsError);
        }
    }
}