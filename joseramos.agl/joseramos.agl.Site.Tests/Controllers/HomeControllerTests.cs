using Autofac;
using Autofac.Integration.Mvc;
using JoseRamos.Agl.Core.Models;
using JoseRamos.Agl.Core.Models.Enums;
using JoseRamos.Agl.Core.Services;
using JoseRamos.Agl.Site;
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
        private List<Person> ownerList;
        private List<OwnerSortResult> expectedResult;

        [SetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            

            builder.RegisterType<OwnerDataClient>().As<IDataClient>();
            builder.RegisterType<SortingProvider>().As<ISortingProvider>();
            builder.RegisterType<CacheProvider>().As<ICacheProvider>();

            var container = builder.Build();

            //Load test data from test script file
            expectedResult = new List<OwnerSortResult>
            {

                new OwnerSortResult
                {
                    Gender = "Male",
                    AnimalType = Animal.Cat,
                    PetNames = new List<string>
                    {
                        "Bob's catt"
                    }
                }
            };

        }
        [Test]
        public void Index_Returns_Correctly()
        {
            var autoMocker = new Moq.AutoMock.AutoMocker();
            var sortProvider = autoMocker.GetMock<ISortingProvider>();
            var dataClient = autoMocker.GetMock<IDataClient>();

            //dataClient.Setup(p => p.BaseUrl).Returns(new Uri("http://agl-developer-test.azurewebsites.net/people.json"));
            //var controller = autoMocker.CreateInstance<HomeController>();

            sortProvider.Setup(p => p.SortAndFilter(null, Animal.Cat)).Returns(expectedResult);
            var controller = new HomeController(sortProvider.Object, dataClient.Object);
            var test = ((ViewResult)controller.Index()).ViewName;
            // TODO: Add your test code here
            Assert.AreEqual("Index", test);
        }
    }
}
