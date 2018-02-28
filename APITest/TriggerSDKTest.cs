using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNET.Api;
using OneNET.Api.Entity;
using OneNET.Api.Request;

namespace APITest
{
    [TestClass]
    public class TriggerSDKTest
    {
        private const string url = "api.heclouds.com";
        private const string appkey = "yourkey=";//您在OneNET平台的APIKey

        [TestMethod]
        public void TestAddTrigger()
        {
            var c1 = new DefaultOneNETClient(url, appkey, "");
            var req1 = new NewTriggerRequest
            {
                Trigger = new NewTriggerInfo
                {
                    Title = "test add trigger for some device in C#",
                    Url = "http://www.baidu.com",
                    Type = TriggerType.Frozen.GetTriggerTypeString(),
                    Threshold = 120,
                    Dev_Ids = new[] { "768672", "776941" },
                    Ds_Id = "AutoAddedFromPointsAdd"
                }
            };

            var rsp1 = c1.Execute(req1);
            Assert.IsFalse(rsp1.IsError);
            Assert.IsNotNull(rsp1.Data);
            Assert.IsNotNull(rsp1.Data.Trigger_Id);
            Console.WriteLine("The second new trigger id: " + rsp1.Data.Trigger_Id);
        }

        [TestMethod]
        public void TestDeleteTrigger()
        {
            //add
            var client = new DefaultOneNETClient(url, appkey, "");
            var req = new NewTriggerRequest
            {
                Trigger = new NewTriggerInfo
                {
                    Title = "test delete trigger for some device",
                    Url = "http://www.baidu.com",
                    Type = TriggerType.InOut.GetTriggerTypeString(),
                    Threshold = new { lolmt = 40, uplmt = 300 },
                    Dev_Ids = new[] { "768672" },
                    Ds_Id = "每日进货量"
                }
            };

            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Assert.IsNotNull(rsp.Data);
            Assert.IsNotNull(rsp.Data.Trigger_Id);

            var c1 = new DefaultOneNETClient(url, appkey, "");
            var req1 = new DeleteTriggerRequest {TriggerID = rsp.Data.Trigger_Id};
            var rsp1 = c1.Execute(req1);
            Assert.IsFalse(rsp1.IsError);
        }

        [TestMethod]
        public void TestUpdateTrigger()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var data = new Trigger
                       {
                           Title = "test update trigger",
                           Type = TriggerType.LargerOrEqual.GetTriggerTypeString(),
                           Threshold = 60
                       };
            var rep = new UpdateTriggerRequest {TriggerID = "20631", Trigger =  data };

            var rsp = client.Execute(rep);
            Assert.IsFalse(rsp.IsError);
        }

        [TestMethod]
        public void TestGetATrigger()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var req = new GetTriggerRequest {TriggerID = "20631"};
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Assert.IsNotNull(rsp.Data);
            Assert.IsNotNull(rsp.Data.Id);
            Console.WriteLine(rsp.Body);
        }

        [TestMethod]
        public void TestSearchTrigger()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var req = new SearchTriggerRequest {Title = "test add"};
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Assert.IsNotNull(rsp.Data);
            Assert.IsTrue(rsp.Data.Total_Count > 0);
            Assert.IsNotNull(rsp.Data.Triggers);
        }
    }
}