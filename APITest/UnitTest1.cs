using System;
using System.Web;
using System.Collections.Generic;
using OneNET.Api.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var url = "https://api.github.com/?access_token=";

            var webUtils = new WebUtils();
            var result = webUtils.DoGet(url, null, "Accept: application/vnd.github.v3+json");
            Assert.IsNotNull(result);
            Console.WriteLine(result);
        }
    }
}
