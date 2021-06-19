using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestNameSorter
{
    [TestClass]
    public class UnitTestName
    {
        private const string expected = "File does not exist.";

        [TestMethod]
        public void TestMethodMain()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                string[] args = { " " };
                NameSorter.Program.Main(args);
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void ValidateLastNameExistSucessTest()
        {
            NameSorter.Name obj = new NameSorter.Name();
            bool result = obj.ValidateLastNameExist("Vaughn Lewis");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateLastNameExistFailTest()
        {
            NameSorter.Name obj = new NameSorter.Name();
            bool result = obj.ValidateLastNameExist("Parsons");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidStringSucessTest()
        {
            NameSorter.Name obj = new NameSorter.Name();
            bool result = obj.ValidString("Shelby Nathan Yoder");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidStringFailTest()
        {
            NameSorter.Name obj = new NameSorter.Name();
            bool result = obj.ValidString("Marin Al#varez");
            Assert.IsFalse(result);
        }
    }
}
