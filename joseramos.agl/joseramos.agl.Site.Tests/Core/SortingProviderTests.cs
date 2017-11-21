using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using JoseRamos.Agl.Core.Models;
using JoseRamos.Agl.Core.Services;

namespace joseramos.agl.Site.Tests.Core
{
    /// <summary>
    /// Summary description for SortingProviderTests
    /// </summary>
    [TestFixture]
    public class SortingProviderTests
    {
        private List<Person> ownerlist;
        [SetUp]
        public void Setup()
        {
            //Load test data from test script file
            ownerlist = new List<Person>()
            {
                new Person
                {
                    Age = 20,
                    Name = "Bob",
                    Gender = "Male",
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Bob's Cat",
                            Type = "Cat"
                        },
                        new Pet
                        {
                            Name = "Wanda",
                            Type = "Fish"
                        },
                        new Pet
                        {
                            Name = "Fred",
                            Type = "Dog"
                        }
                    }
                }
            };
        }

        [Test]
        public void Returns_Null_Object_If_Null_List()
        {
            var sortingProvider = new SortingProvider();
            var result = sortingProvider.SortAndFilter(null, JoseRamos.Agl.Core.Models.Enums.Animal.Cat);
            Assert.IsNull(result);

        }
        [Test]
        public void Check_That_Sorting_Returns_Only_Cats()
        {
           var  sortingProvider = new SortingProvider();
            var result = sortingProvider.SortAndFilter(ownerlist, JoseRamos.Agl.Core.Models.Enums.Animal.Cat);

            foreach (OwnerSortResult item in result)
            {
                Assert.AreEqual(item.AnimalType.ToString(), "Cat");

            }
        }

        [Test]
        public void Check_That_Sorting_Returns_Only_Dogs()
        {
            var sortingProvider = new SortingProvider();
            var result = sortingProvider.SortAndFilter(ownerlist, JoseRamos.Agl.Core.Models.Enums.Animal.Dog);

            foreach (OwnerSortResult item in result)
            {
                foreach (var pet in item.PetNames)
                {
                    //Wanda is the only fish in the test data
                    Assert.AreNotEqual(pet, "Wanda");

                }

                Assert.AreEqual(item.AnimalType.ToString(), "Dog");

            }
        }
    }
}
