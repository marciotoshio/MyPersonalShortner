using MyPersonalShortner.Lib.Domain.Url;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyPersonalShortner.Tests.Domain
{
    [TestFixture]
    public class CustomUrlTest
    {
        #region Setup/Teardown

        [SetUp]
        public void Initialize()
        {
            customUrl = new CustomUrl {Id = 1, Url = "https://github.com/marciotoshio", CustomPart = "github"};
            validationContext = new ValidationContext(customUrl, null, null);
        }

        #endregion

        private ValidationContext validationContext;
        private CustomUrl customUrl;

        [Test]
        public void url_empty_must_be_invalid()
        {
            customUrl.Url = "";
            var validationResults = new List<ValidationResult>();
            bool result = Validator.TryValidateObject(customUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void custom_part_empty_must_be_invalid()
        {
            customUrl.CustomPart = "";
            var validationResults = new List<ValidationResult>();
            bool result = Validator.TryValidateObject(customUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("CustomPart", validationResults[0].MemberNames.First());
        }

        [Test]
        public void custom_part_greater_than_10_must_be_invalid()
        {
            customUrl.CustomPart = "qwertyuiopa";
            var validationResults = new List<ValidationResult>();
            bool result = Validator.TryValidateObject(customUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("CustomPart", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_must_be_a_url()
        {
            customUrl.Url = "qwerty";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(customUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_must_contains_dot_anything()
        {
            customUrl.Url = "http://test";
            var validationResults1 = new List<ValidationResult>();
            var result1 = Validator.TryValidateObject(customUrl, validationContext, validationResults1, true);

            Assert.IsFalse(result1);
            Assert.AreEqual(1, validationResults1.Count);
            Assert.AreEqual("Url", validationResults1[0].MemberNames.First());

            customUrl.Url = "http://test.com";
            var validationResults2 = new List<ValidationResult>();
            var result2 = Validator.TryValidateObject(customUrl, validationContext, validationResults2, true);

            Assert.IsTrue(result2);
        }

        [Test]
        public void url_null_must_be_invalid()
        {
            customUrl.Url = null;
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(customUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }

        [Test]
        public void url_protocol_can_be_ftp()
        {
            customUrl.Url = "ftp://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(customUrl, validationContext, validationResults, true);

            Assert.IsTrue(result);
        }

        [Test]
        public void url_protocol_can_be_http()
        {
            customUrl.Url = "http://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(customUrl, validationContext, validationResults, true);

            Assert.IsTrue(result);
        }

        [Test]
        public void url_protocol_can_be_https()
        {
            customUrl.Url = "https://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(customUrl, validationContext, validationResults, true);

            Assert.IsTrue(result);
        }

        [Test]
        public void url_protocol_cannot_be_everything_else()
        {
            customUrl.Url = "foo://test.com";
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(customUrl, validationContext, validationResults, true);

            Assert.IsFalse(result);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("Url", validationResults[0].MemberNames.First());
        }
    }
}