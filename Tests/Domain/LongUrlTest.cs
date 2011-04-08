using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.Tests.Domain
{
    [TestFixture]
    public class LongUrlTest
    {
        private ValidationContext validationContext;
        private LongUrl longUrl;
        [SetUp]
        public void Initialize()
        {
            this.longUrl = new LongUrl { Id = 1, Url = "https://github.com/marciotoshio/MyPersonalShortner" };
            this.validationContext = new ValidationContext(this.longUrl, null, null);
        }

        [Test]
        public void url_null_must_be_invalid()
        {
            this.longUrl.Url = null;
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this.longUrl, this.validationContext, validationResults, true);
            
            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_empty_must_be_invalid()
        {
            this.longUrl.Url = "";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this.longUrl, this.validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_must_be_a_url()
        {
            this.longUrl.Url = "qwerty";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this.longUrl, this.validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_protocol_can_be_http()
        {
            this.longUrl.Url = "http://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this.longUrl, this.validationContext, validationResults, true);

            Assert.IsTrue(result);
        }

        [Test]
        public void url_protocol_can_be_https()
        {
            this.longUrl.Url = "https://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this.longUrl, this.validationContext, validationResults, true);

            Assert.IsTrue(result);
        }

        [Test]
        public void url_protocol_can_be_ftp()
        {
            this.longUrl.Url = "ftp://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this.longUrl, this.validationContext, validationResults, true);

            Assert.IsTrue(result);
        }

        [Test]
        public void url_protocol_cannot_be_everything_else()
        {
            this.longUrl.Url = "foo://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(this.longUrl, this.validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_must_contains_dot_anything()
        {
            this.longUrl.Url = "http://test";
            var validationResults1 = new List<ValidationResult>();
            var result1 = Validator.TryValidateObject(this.longUrl, this.validationContext, validationResults1, true);

            Assert.IsFalse(result1);
            Assert.AreEqual(1, validationResults1.Count);
            Assert.AreEqual("Url", validationResults1[0].MemberNames.First());

            this.longUrl.Url = "http://test.com";
            var validationResults2 = new List<ValidationResult>();
            var result2 = Validator.TryValidateObject(this.longUrl, this.validationContext, validationResults2, true);

            Assert.IsTrue(result2);
        }
    }
}
