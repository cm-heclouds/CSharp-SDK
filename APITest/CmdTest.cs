using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNET.Api;
using OneNET.Api.Request;

namespace APITest
{
    /// <summary>
    /// 以下方法需要连接真实设备测试
    /// </summary>
    [TestClass]
    public class CmdTest
    {
        private const string url = "api.heclouds.com";
        private const string appkey = "yourapikey";//您在OneNET平台的APIKey

        [TestMethod]
        public void TestSendCmd()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            //todo:待测
            var req = new SendCmdRequest { DeviceID = 768719, Protocol = Scheme.HTTP, CmdContent = new {testpara="test"}};
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Console.WriteLine(rsp.Body);
            Assert.IsNotNull(rsp.Data);
            Assert.IsNotNull(rsp.Data.Cmd_uuid);
        }

        [TestMethod]
        public void TestGetCmdStatus()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            //todo
            var id = "pendingtobetested";
            var req = new GetCmdStatusRequest { CmdUuid = id };
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Console.WriteLine("查询命令"+ id + "的状态结果：");
            Console.WriteLine(rsp.Body);
        }

        [TestMethod]
        public void TestGetCmdResponse()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            //todo
            var id = "pendingtobetested";
            var req = new GetCmdRespRequest { CmdUuid = id };
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Console.WriteLine("查询命令" + id + "的响应结果：");
            Console.WriteLine(rsp.Body);
        }
    }
}