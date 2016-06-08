using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneNET.Api;
using OneNET.Api.Entity;
using OneNET.Api.Request;

namespace APITest
{
    [TestClass]
    public class KeySDKTest
    {
        private const string url = "api.heclouds.com";
        private const string appkey = "yourapikey";//您在OneNET平台的APIKey

        [TestMethod]
        public void TestAddKey()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var permissions = new List<Permission>
                              {
                                  new Permission
                                  {
                                      Access_Methods = new[]
                                                       {
                                                           HttpRequestMethod.Get.GetMethodString(),
                                                           HttpRequestMethod.Post.GetMethodString()
                                                       },
                                      Resources = new List<KeyResource>
                                                  {
                                                      new KeyResource {Dev_Id = "776938"},
                                                      new KeyResource {Dev_Id = "776941"}
                                                  }
                                  }
                              };
            var data = new ApiKeyInfo
                       {
                           Title = "test key from C#",
                           Permissions = permissions
                       };
            var req = new NewKeyRequest {KeyInfo = data};

            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
            Console.WriteLine(rsp.Body);
            Assert.IsNotNull(rsp.Data);
            Assert.IsNotNull(rsp.Data.Key);
        }

        [TestMethod]
        public void TestUpdateKey()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var permissions = new List<Permission>
                              {
                                  new Permission
                                  {
                                      Access_Methods = new[]
                                                       {
                                                           HttpRequestMethod.Get.GetMethodString(),
                                                           HttpRequestMethod.Post.GetMethodString(),
                                                           HttpRequestMethod.Put.GetMethodString()
                                                       },
                                      Resources = new List<KeyResource>
                                                  {
                                                      new KeyResource {Dev_Id = "776938"},
                                                      new KeyResource {Dev_Id = "776941"}
                                                  }
                                  }
                              };
            var data = new ApiKeyInfo
            {
                Title = "test update key from C#",
                Permissions = permissions
            };
            var req = new UpdateKeyRequest { KeyString = "jb3idOcNvc3Tv=WtoBLBLPYgVyg=", KeyInfo = data };
            var rsp = client.Execute(req);
            Assert.IsFalse(rsp.IsError);
        }

        [TestMethod]
        public void TestGetKeys()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            //test get all
            var req = new GetKeysRequest();
            var rsp = client.Execute(req);
            Console.WriteLine(rsp.Body);
            Assert.IsFalse(rsp.IsError);
            Assert.IsNotNull(rsp.Data);
            Assert.IsTrue(rsp.Data.Total_Count > 0);

            //test get by key
            var c1 = new DefaultOneNETClient(url, appkey, "");
            var req1 = new GetKeysRequest { Key = "jb3idOcNvc3Tv=WtoBLBLPYgVyg=" };
            var rsp1 = c1.Execute(req1);
            Assert.IsFalse(rsp1.IsError);
            Assert.IsNotNull(rsp1.Data);
            Assert.IsTrue(rsp1.Data.Total_Count > 0);

            //test get by device id
            var c2 = new DefaultOneNETClient(url, appkey, "");
            var req2 = new GetKeysRequest { DeviceId = "776941" };
            var rsp2 = c2.Execute(req2);
            Assert.IsFalse(rsp2.IsError);
            Assert.IsNotNull(rsp2.Data);
            Assert.IsTrue(rsp1.Data.Total_Count > 0);
        }

        [TestMethod]
        public void TestDeleteKey()
        {
            var client = new DefaultOneNETClient(url, appkey, "");
            var permissions = new List<Permission>
                              {
                                  new Permission
                                  {
                                      Access_Methods = new[]
                                                       {
                                                           HttpRequestMethod.Get.GetMethodString(),
                                                           HttpRequestMethod.Delete.GetMethodString()
                                                       },
                                      Resources = new List<KeyResource>
                                                  {
                                                      new KeyResource {Dev_Id = "768672"}
                                                  }
                                  }
                              };
            var data = new ApiKeyInfo
            {
                Title = "test delete key",
                Permissions = permissions
            };
            var req = new NewKeyRequest { KeyInfo = data };

            var rsp = client.Execute(req);
            Console.WriteLine("key to delete has added:   "+ rsp.Body);
            Assert.IsFalse(rsp.IsError);
            Assert.IsNotNull(rsp.Data);
            Assert.IsNotNull(rsp.Data.Key);

            var c1 = new DefaultOneNETClient(url, appkey, "");
            var req1 = new DeleteKeyRequest {KeyString = rsp.Data.Key};
            var rsp1 = c1.Execute(req1);
            Assert.IsFalse(rsp1.IsError);
        }
    }
}
