using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MyPersonalShortner.Lib.BaseConversion;
using MyPersonalShortner.Lib.Url;

namespace MyPersonalShortner.Tests
{
    [TestFixture]
    public class UrlGeneratorTest
    {
        UrlGenerator generator;
        [SetUp]
        public void Initialize()
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            IBaseConversion baseConversion = new Base10ToN(chars.Length);
            this.generator = new UrlGenerator(baseConversion, chars);
        }

        [Test]
        public void with_input_0_generates_string_0()
        {
            var result = this.generator.GeneratesFor(0);
            Assert.AreEqual("0", result);
        }

        [Test]
        public void with_input_61_generates_string_Z()
        {
            var result = this.generator.GeneratesFor(61);
            Assert.AreEqual("Z", result);
        }

        [Test]
        public void with_input_62_generates_string_01()
        {
            var result = this.generator.GeneratesFor(62);
            Assert.AreEqual("01", result);
        }

        [Test]
        public void with_input_1000_generates_string_8g()
        {
            var result = this.generator.GeneratesFor(1000);
            Assert.AreEqual("8g", result);
        }
    }
}
