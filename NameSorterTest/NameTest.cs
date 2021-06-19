using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NameSorterTest
{
    [NameTestClass]
    public class NameTest
    {
        [TestMethod]
        public void NameTest( )
        {
        }

        private const string Expected = "Please enter a file name";
        [TestMethod]
        public void TestMethod1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                NameSorter.Program.Main();

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
            }
        }
    }
}
