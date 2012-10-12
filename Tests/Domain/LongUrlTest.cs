using MyPersonalShortner.Lib.Domain.Url;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyPersonalShortner.Tests.Domain
{
    [TestFixture]
    public class LongUrlTest
    {
        #region Setup/Teardown

        [SetUp]
        public void Initialize()
        {
            longUrl = new LongUrl {Id = 1, Url = "https://github.com/marciotoshio/MyPersonalShortner"};
            validationContext = new ValidationContext(longUrl, null, null);
        }

        #endregion

        private ValidationContext validationContext;
        private LongUrl longUrl;

        [Test]
        public void url_empty_must_be_invalid()
        {
            longUrl.Url = "";
            var validationResults = new List<ValidationResult>();
            bool result = Validator.TryValidateObject(longUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_must_be_a_url()
        {
            longUrl.Url = "qwerty";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(longUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_must_contains_dot_anything()
        {
            longUrl.Url = "http://test";
            var validationResults1 = new List<ValidationResult>();
            var result1 = Validator.TryValidateObject(longUrl, validationContext, validationResults1, true);

            Assert.IsFalse(result1);
            Assert.AreEqual(1, validationResults1.Count);
            Assert.AreEqual("Url", validationResults1[0].MemberNames.First());

            longUrl.Url = "http://test.com";
            var validationResults2 = new List<ValidationResult>();
            var result2 = Validator.TryValidateObject(longUrl, validationContext, validationResults2, true);

            Assert.IsTrue(result2);
        }

        [Test]
        public void url_null_must_be_invalid()
        {
            longUrl.Url = null;
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(longUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_protocol_can_be_ftp()
        {
            longUrl.Url = "ftp://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(longUrl, validationContext, validationResults, true);

            Assert.IsTrue(result);
        }

        [Test]
        public void url_protocol_can_be_http()
        {
            longUrl.Url = "http://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(longUrl, validationContext, validationResults, true);

            Assert.IsTrue(result);
        }

        [Test]
        public void url_protocol_can_be_https()
        {
            longUrl.Url = "https://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(longUrl, validationContext, validationResults, true);

            Assert.IsTrue(result);
        }

        [Test]
        public void url_protocol_cannot_be_everything_else()
        {
            longUrl.Url = "foo://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(longUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void Accept_url_with_hashbang()
        {
            longUrl.Url = "https://test.com/#!/test";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(longUrl, validationContext, validationResults, true);

            Assert.IsTrue(result);
        }
    }
}