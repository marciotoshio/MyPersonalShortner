using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using MyPersonalShortner.MvcApp.Controllers;
using Moq;
using System.Web;
using MyPersonalShortner.Lib.Services;
using System.Collections.Specialized;

namespace MyPersonalShortner.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void shorten_with_parameters_return_shortned_url()
        {
            var controller = GetController();
            var result = controller.Index(GetFormCollection());
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual("8g", ((ViewResult)result).ViewBag.ShortenUrl);
        }

        private HomeController GetController()
        {
            var mockService = new Mock<IShortnerService>();
            mockService.Setup(s => s.Shorten(It.IsAny<string>())).Returns("8g");

            var controller = new HomeController(mockService.Object);
            return controller;
        }

        private FormCollection GetFormCollection()
        {
            var nameValue = new NameValueCollection();
            nameValue.Add("url", "http://github.com");
            return new FormCollection(nameValue);
        }
    }
}
