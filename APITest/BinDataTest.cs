using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNET.Api;
using OneNET.Api.Request;

namespace APITest
{
    [TestClass]
    public class BinDataTest
    {
        private const string url = "api.heclouds.com";
        private const string appkey = "Hf1hQbdPeOEwlYs04nyzmD2fdQw=";

        [TestMethod]
        public void TestAddBinData()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var fi = new FileInfo(@"../../files/Shaq.jpg");
            var len = fi.Length;
            var fs = new FileStream(@"../../files/Shaq.jpg", FileMode.Open);
            var buffer = new byte[len];
            fs.Read(buffer, 0, (int)len);
            fs.Close();

            var req = new NewBinDataRequest { DeviceID = 768672, DatastreamId = "datastream_id1", BinData = buffer };
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Console.WriteLine(rsp.Body);
            Assert.IsNotNull(rsp.Data);
            Assert.IsNotNull(rsp.Data.Index);
        }

        [TestMethod]
        public void TestGetBinData()
        {
            var client1 = new DefaultOneNETClient(url, appkey, "");
            //get bin data added from above test method
            var gReq = new GetBinDataRequest { Index = "768672_1459242295299_datastream_id1" };
            var gRsp = client1.Execute(gReq);
            Assert.IsFalse(gRsp.IsError);
            Assert.IsNotNull(gRsp.Body);
            Assert.IsNotNull(gRsp.BinDataBody);
            
            var stream = new MemoryStream(gRsp.BinDataBody);
            
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            var fileName = "../../files/" + DateTime.Now.ToString("yyyyMMddHHmm") + ".jpg";
            
            var fs = new FileStream(fileName, FileMode.Create);
            var bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }
    }
}