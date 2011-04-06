using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using MyPersonalShortner.MvcApp.Controllers;
using Moq;
using System.Web;

namespace MyPersonalShortner.Tests
{
    [TestFixture]
    public class ShortnerControllerTest
    {
        [Test]
        public void index_without_parameters_redirects_to_home_index()
        {
            var controller = new ShortnerController();
            var result = controller.Index(null);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [Test]
        public void index_with_parameters_redirects_permanently()
        {
            var controller = new ShortnerController();
            var result = controller.Index("0");
            Assert.IsInstanceOf<RedirectResult>(result);
            Assert.IsTrue(((RedirectResult)result).Permanent);
        }
    }
}
