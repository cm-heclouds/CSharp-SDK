using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNET.Api;
using OneNET.Api.Request;
using OneNET.Api.Response;

namespace APITest
{
    [TestClass]
    public class DataStreamTest
    {
        private const string url = "api.heclouds.com";
        private const string appkey = "yourkey=";//您在OneNET平台的APIKey

        [TestMethod]
        public void TestGetDataStream()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var req = new GetDataStreamRequest {DeviceID = "768719", DataStreamId = "x", Protocol = Scheme.HTTP};
            req.AddOtherParameter("newAdd", "true");
            var resp = client.Execute(req);
            Assert.IsFalse(resp.IsError);
            Assert.AreEqual(0, resp.Errno);
            Assert.AreEqual("succ", resp.Error);
            Assert.IsNotNull(resp.Data);
            Console.WriteLine(resp.Body);
        }

        [TestMethod]
        public void TestAddAndDeleteDataStream()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            const int testDeviceId = 768719;
            const string dsId = "testdelete";
            //test add new
            var data = new DataStreamCommon {ID = dsId, Unit = "sth", Unit_Symbol = "sth"};
            var newReq = new NewDataStreamRequest { DeviceID = testDeviceId, DataStream = data };
            var resp = client.Execute(newReq);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Data.Ds_Uuid);
            //test delete
            var client1 = new DefaultOneNETClient(url, appkey, "");
            var delReq = new DeleteDataStreamRequest {DeviceID = testDeviceId, DataStreamId = dsId};
            var delResp = client1.Execute(delReq);
            Assert.IsFalse(delResp.IsError);
        }

        [TestMethod]
        public void TestUpdateDataStream()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            const int testDeviceId = 768719;
            var dsId = "testupdate" + DateTime.Now.Ticks;
            //add new
            var data = new DataStreamCommon { ID = dsId, Unit = "ABC", Unit_Symbol = "abc", Tags = new []{"testupdate","yztest"}};
            var newReq = new NewDataStreamRequest { DeviceID = testDeviceId, DataStream = data };
            var resp = client.Execute(newReq);
            Assert.IsFalse(resp.IsError);
            Console.WriteLine(resp.Data.Ds_Uuid);

            //test update
            var uData = new DataStreamCommon {Unit = "XYZ", Unit_Symbol = "xyz", Tags = new []{"updated","testxyz"}};
            var uReq = new UpdateDataStreamRequest {DeviceID = testDeviceId, DataStreamId = dsId, DataStream = uData};
            var client1 = new DefaultOneNETClient(url, appkey, "");
            var delResp = client1.Execute(uReq);
            Assert.IsFalse(delResp.IsError);
        }
    }
}