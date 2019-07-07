using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Server_UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"C:\TFS\Sitecore\Sitecore\WindowsPublishSubscribe\bin\Debug\WindowsPublishSubscribe.exe";
            info.Arguments = @"/server SitecorePipe";

            //Process server = ;
            Assert.IsTrue(!Process.Start(info).HasExited);
        }
    }
}
