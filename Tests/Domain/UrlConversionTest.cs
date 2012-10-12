using MyPersonalShortner.Lib.Domain.UrlConversion;
using NUnit.Framework;

namespace MyPersonalShortner.Tests.Domain
{
    [TestFixture]
    public class UrlConversionTest
    {
        IUrlConversion urlConversion;
        [SetUp]
        public void Initialize()
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            urlConversion = new Base10ToHash(chars);
        }

        [Test]
        public void with_0_generates_string_0()
        {
            var result = urlConversion.Encode(0);
            Assert.AreEqual("0", result);
        }
        [Test]
        public void with_0_string_returns_0()
        {
            var result = urlConversion.Decode("0");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void with_61_generates_string_Z()
        {
            var result = urlConversion.Encode(61);
            Assert.AreEqual("Z", result);
        }
        [Test]
        public void with_Z_string_returns_61()
        {
            var result = urlConversion.Decode("Z");
            Assert.AreEqual(61, result);
        }

        [Test]
        public void with_62_generates_string_01()
        {
            var result = urlConversion.Encode(62);
            Assert.AreEqual("01", result);
        }
        [Test]
        public void with_01_string_returns_62()
        {
            var result = urlConversion.Decode("01");
            Assert.AreEqual(62, result);
        }

        [Test]
        public void with_1000_generates_string_8g()
        {
            var result = urlConversion.Encode(1000);
            Assert.AreEqual("8g", result);
        }
        [Test]
        public void with_8g_string_returns_1000()
        {
            var result = urlConversion.Decode("8g");
            Assert.AreEqual(1000, result);
        }
    }
}
