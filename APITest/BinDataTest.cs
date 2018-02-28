using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNET.Api;
using OneNET.Api.Request;

namespace APITest
{
    [TestClass]
    public class BinDataTest
    {
        private const string url = "api.heclouds.com";
        private const string appkey = "yourkey=";//您在OneNET平台的APIKey

        [TestMethod]
        public void TestAddBinData()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var fp = @"../../files/dev_data.txt";
            var fi = new FileInfo(fp);
            var len = fi.Length;
            var fs = new FileStream(fp, FileMode.Open);
            var buffer = new byte[len];
            fs.Read(buffer, 0, (int)len);
            fs.Close();

            var req = new NewBinDataRequest { DeviceID = 3011964, DatastreamId = "data", BinData = buffer };
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Console.WriteLine(rsp.Body);
            Assert.IsNotNull(rsp.Data);
            Assert.IsNotNull(rsp.Data.Index);

            //Thread.Sleep(10000);

            var client1 = new DefaultOneNETClient(url, appkey, "");
            //get bin data added from above test method
            var gReq = new GetBinDataRequest { Index = rsp.Data.Index };
            var gRsp = client1.Execute(gReq);
            Assert.IsFalse(gRsp.IsError);
            Assert.IsNotNull(gRsp.Body);
            Console.WriteLine(gRsp.Body);
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

        //video file is too large
        //[TestMethod]
        //public void TestAddAndGetMP4Data()
        //{
        //    var client = new DefaultOneNETClient(url, appkey, "");
        //    var fp = @"../../files/videotest.mp4";
        //    var fi = new FileInfo(fp);
        //    var len = fi.Length;
        //    var fs = new FileStream(fp, FileMode.Open);
        //    var buffer = new byte[len];
        //    fs.Read(buffer, 0, (int)len);
        //    fs.Close();

        //    var req = new NewBinDataRequest { DeviceID = 3011964, DatastreamId = "data", BinData = buffer };
        //    var rsp = client.Execute(req);
        //    Assert.IsFalse(rsp.IsError);
        //    Console.WriteLine(rsp.Body);
        //    Assert.IsNotNull(rsp.Data);
        //    Assert.IsNotNull(rsp.Data.Index);

        //    //Thread.Sleep(10000);

        //    var client1 = new DefaultOneNETClient(url, appkey, "");
        //    //get bin data added from above test method
        //    var gReq = new GetBinDataRequest { Index = rsp.Data.Index };
        //    var gRsp = client1.Execute(gReq);
        //    Assert.IsFalse(gRsp.IsError);
        //    Assert.IsNotNull(gRsp.Body);
        //    Console.WriteLine(gRsp.Body);

        //    var stream = new MemoryStream(gRsp.BinDataBody);

        //    var bytes = new byte[stream.Length];
        //    stream.Read(bytes, 0, bytes.Length);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    var fileName = "../../files/" + DateTime.Now.ToString("yyyyMMddHHmm") + ".mp4";

        //    var fs2 = new FileStream(fileName, FileMode.Create);
        //    var bw = new BinaryWriter(fs2);
        //    bw.Write(bytes);
        //    bw.Close();
        //    fs2.Close();
        //}
    }
}