using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class TestStringCalculator
    {

        private StringCalculator _calculator;


        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator();
        }

        [Test]
        public void AddNothing()
        {
            Assert.AreEqual(0, _calculator.Add(""));
        }

        [Test]
        public void AddOne()
        {
            Assert.AreEqual(1, _calculator.Add("1"));
        }

        [Test]
        public void AddMultiple()
        {
            Assert.AreEqual(3, _calculator.Add("1,2"));
        }

        [Test]
        public void AddWithNewLines()
        {
            Assert.AreEqual(6, _calculator.Add("1\n2,3"));
        }

        [Test]
        public void AddWithCustomSeperator()
        {
            Assert.AreEqual(3, _calculator.Add("//;\n1;2"));
        }

        [Test]
        public void AddWithNegatives()
        {
            var exception = Assert.Throws<Exception>(() => _calculator.Add("-1,2"));
            Assert.AreEqual("Negative not allowed", exception.Message);
        }

        [Test]
        public void AddWithMultipleNegatives()
        {
            var exception = Assert.Throws<Exception>(() => _calculator.Add("2,-4,-5"));
            Assert.AreEqual("Negative not allowed: -4, -5", exception.Message);
        }

        [Test]
        public void CalledCount()
        {
            _calculator.Add("1,2");
            _calculator.Add("5");
            //Assert.AreEqual(2, _calculator.CalledCount());
        }

        [Test]
        public void OccuredEvent()
        {

        }
    }
}