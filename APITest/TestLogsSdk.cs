using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNET.Api;
using OneNET.Api.Entity;
using OneNET.Api.Request;

namespace APITest
{
    [TestClass]
    public class TestLogsSdk
    {
        private const string url = "api.heclouds.com";
        private const string appkey = "yourapikey";//您在OneNET平台的APIKey

        [TestMethod]
        public void TestSearchLogs()
        {
            //添加数据点
            var client0 = new DefaultOneNETClient(url, appkey, "");
            var streams = new List<DataStreamSimple>
                          {
                              new DataStreamSimple
                              {
                                  ID = "test log",
                                  Datapoints = new List<DataPointSimple>
                                               {
                                                   new DataPointSimple {Value = 88.8, At = "2016-03-23T00:35:43"}
                                               }
                              }
                          };

            var data = new NewDataPointData { DataStreams = streams };
            var req0 = new NewDataPointRequest { DeviceID = 768719, Data = data };
            var rsp0 = client0.Execute(req0);
            Assert.IsFalse(rsp0.IsError);

            //查询日志
            var client = new DefaultOneNETClient(url, appkey, "");
            var req = new SearchLogsRequest { DeviceID = "768719", Start = DateTime.Now.AddHours(-3) };
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Assert.IsNotNull(rsp.Data);
            Console.WriteLine(rsp.Body);
        }
    }
}