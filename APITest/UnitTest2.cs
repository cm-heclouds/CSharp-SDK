using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;

namespace APITest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public string getSignature() 
        {
            var token = ""; 
            var msg = "";
            var randomLenth = 8;
            var nonce = GetRandomStr(randomLenth);
            byte[] signature = new byte[token.Length + randomLenth + msg.Length];
            Array.Copy(Encoding.Default.GetBytes(token), 0, signature, 0, token.Length);
            Array.Copy(Encoding.Default.GetBytes(nonce), 0, signature, token.Length, randomLenth);
            Array.Copy(Encoding.Default.GetBytes(msg), 0, signature, token.Length + randomLenth, msg.Length);
            
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(signature);
            String calSig = Encoding.Default.GetString(result);

            return calSig;
        }

        private static char[] constant =   
          {   
            '0','1','2','3','4','5','6','7','8','9',  
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
          };

        public static string GetRandomStr(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }
    }
}
