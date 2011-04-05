using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MyPersonalShortner.Lib;

namespace MyPersonalShortner.Tests
{
    [TestFixture]
    class Base62ConversionTest
    {
        private Base10ToN baseConversion;
        [SetUp]
        public void Initialize()
        {
            this.baseConversion = new Base10ToN(62);
        }

        [Test]
        public void encode_0_returns_0()
        {
            var result = this.baseConversion.Encode(0);
            Assert.AreEqual(0, result[0]);
        }

        [Test]
        public void encode_61_returns_61()
        {
            var result = this.baseConversion.Encode(61);
            Assert.AreEqual(61, result[0]);
        }

        [Test]
        public void encode_62_returns_0_and_1()
        {
            var result = this.baseConversion.Encode(62);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);
        }

        [Test]
        public void encode_1000_returns_8_and_16()
        {
            var result = this.baseConversion.Encode(1000);
            Assert.AreEqual(8, result[0]);
            Assert.AreEqual(16, result[1]);
        }

        [Test]
        public void decode_0_returns_0()
        {
            var result = this.baseConversion.Decode(new int[] { 0 });
            Assert.AreEqual(0, result);
        }

        [Test]
        public void decode_61_returns_61()
        {
            var result = this.baseConversion.Decode(new int[] { 61 });
            Assert.AreEqual(61, result);
        }

        [Test]
        public void decode_0_and_1_returns_62()
        {
            var result = this.baseConversion.Decode(new int[] { 0, 1 });
            Assert.AreEqual(62, result);
        }

        [Test]
        public void decode_8_and_16_returns_1000()
        {
            var result = this.baseConversion.Decode(new int[] { 8, 16 });
            Assert.AreEqual(1000, result);
        }
    }
}
