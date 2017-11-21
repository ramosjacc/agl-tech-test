using JoseRamos.Agl.Core.Models;
using JoseRamos.Agl.Site.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace joseramos.agl.Site.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_Returns_Correctly()
        {
            var autoMocker = new Moq.AutoMock.AutoMocker();
            var sortProvider = autoMocker.GetMock<ISortingProvider>();
            var dataClient = autoMocker.GetMock<IDataClient>();

            //var controller = autoMocker.CreateInstance<HomeController>();
            var controller = new HomeController(sortProvider.Object, dataClient.Object);
            var test = ((ViewResult)controller.Index()).ViewName;
            // TODO: Add your test code here
            Assert.AreEqual("Index", test);
        }
    }
}
