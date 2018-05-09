using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tester;

namespace AgeCalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        AgeCalculator ac = new AgeCalculator();
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(25, ac.CalcutaleAge(new DateTime(1992, 12, 03)));
        }
    }


    [TestClass]
    public class AgeCalculatorTester
    {
        private AgeCalculator ac = new AgeCalculator(new DateTime(2018,01,01));
        [TestMethod]
        public void TestMethod2()
        {
            var date = new DateTime(1992,08,02);
            Assert.AreEqual(25, ac.CalcutaleAge(date));
        }
    }

    [TestClass]
    public class SwedenRetirementTester
    {
        Sweden sweden = new Sweden();

        [TestMethod]
        public void PeopleOver65IsRetired()
        {
            Assert.IsTrue(sweden.isRetired(new Person(){Birthday = new DateTime(1948,08,08), isMale = true}));
        }

        [TestMethod]
        public void PeopleUnder65NotRetired()
        {
            Assert.IsFalse(sweden.isRetired(new Person(){Birthday = new DateTime(1992,12,03), isMale = false}));
        }
    }

    [TestClass]
    public class BulgariaRetirementCalculator
    {
        Bulgaria bulgaria = new Bulgaria();

        [TestMethod]
        public void WomenIsRetired()
        {
            Assert.IsTrue(bulgaria.isRetired(new Person(){Birthday = new DateTime(1956,10,19), isMale = false}));
        }

        [TestMethod]
        public void WomenNotRetired()
        {
            Assert.IsFalse(bulgaria.isRetired(new Person(){Birthday = new DateTime(1958,01,01), isMale = false}));
        }

        [TestMethod]
        public void MaleIsRetired()
        {
            Assert.IsTrue(bulgaria.isRetired(new Person(){Birthday = new DateTime(1952,12,12), isMale = true}));
        }

        [TestMethod]
        public void MaleNotRetired()
        {
            Assert.IsFalse(bulgaria.isRetired(new Person(){Birthday = new DateTime(1958,01,01), isMale = true}));
        }
    }
}
