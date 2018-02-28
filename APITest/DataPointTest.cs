using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNET.Api;
using OneNET.Api.Entity;
using OneNET.Api.Request;

namespace APITest
{
    [TestClass]
    public class DataPointTest
    {
        private const string url = "api.heclouds.com";
        private const string appkey = "Hf1hQbdPeOEwlYs04nyzmD2fdQw=";//您在OneNET平台的APIKey

        [TestMethod]
        public void TestAddNewDataPoint()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var streams = new List<DataStreamSimple>
                          {
                              new DataStreamSimple
                              {
                                  ID = "每日出货量",
                                  Datapoints = new List<DataPointSimple>
                                               {
                                                   new DataPointSimple {Value = 88.8, At = "2016-03-23T00:35:43"}
                                               }
                              },
                              new DataStreamSimple
                              {
                                  ID = "每日出货地点",
                                  Datapoints = new List<DataPointSimple>{
                                      new DataPointSimple
                                               {
                                                   Value = new {yyy = 86, zzz = 65, aaa = "blablablabla"}
                                               }
                                  }
                              }
                          };

            var data = new NewDataPointData{ DataStreams = streams};
            var req = new NewDataPointRequest { DeviceID = 768719, Data = data };
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
        }

        [TestMethod]
        public void TestSearchDataPoint()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            //测试无参查询
            var req = new SearchDataPointRequest { DeviceID = "768719", Protocol = Scheme.HTTP };
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Assert.AreEqual(0, rsp.Errno);
            Assert.AreEqual("succ", rsp.Error);
            Assert.IsNotNull(rsp.Data);
            Assert.IsTrue(rsp.Data.Count > 0);
            Assert.IsTrue(rsp.Data.Datastreams[0].Datapoints.Count > 0);
            var val = rsp.Data.Datastreams[0].Datapoints[0].GetValue();
            Assert.IsNotNull(val);
            Console.WriteLine("无参查询结果：" + rsp.Body);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("无参查询转换得到的第一个datapoint参数：" + val);
        }

        [TestMethod]
        public void TestSearchDataPointWithCondition()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            //测试带参查询
            var req1 = new SearchDataPointRequest { DeviceID = "768719", Protocol = Scheme.HTTP };
            req1.DataStreamId = "loc,shake";
            var rsp1 = client.Execute(req1);
            Assert.IsFalse(rsp1.IsError);
            Assert.AreEqual(0, rsp1.Errno);
            Assert.AreEqual("succ", rsp1.Error);
            Assert.IsNotNull(rsp1.Data);
            Assert.AreEqual(2, rsp1.Data.Count);
            Console.WriteLine("带参查询结果：" + rsp1.Body);
        }

        [TestMethod]
        public void TestSearchHistoryData()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var req = new SearchHistoryDataRequest { Start = DateTime.Parse("2012-03-02") };
            var rsp = client.Execute(req);

            Assert.IsFalse(rsp.IsError);
            Assert.IsNotNull(rsp.Data);
            Assert.IsTrue(rsp.Data.DataPoints.Count > 0);
        }
    }
}