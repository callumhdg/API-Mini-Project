using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class CategoryResponseTest
    {
        CategoryService _cs;
        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _cs = new CategoryService();
            await _cs.MakeRequestAsync();
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_StatusIsOk()
        {
            Assert.That(_cs.CallManager.StatusDescription, Is.EqualTo("OK"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_ErrorIsFalse()
        {
            Assert.That(_cs.JsonResponse["error"].ToString().ToLower(), Is.EqualTo("false"));
        }
             
        //Testing that there are exactly seven categories so that if any more are added this test will fail 
        [Test]
        public void GivenThatAValidCategoryRequestIsSent_ExactlySevenCategoriesAreReturned()
        {
            Assert.That(_cs.JsonResponse["categories"].Count, Is.EqualTo(7));
        }

        //Tesing categories so that if any change then the tests will fail and we will know that they have changed
        [Test]
        public void GivenThatAValidCategoryRequestIsSent_FirstCategoryIsAny()
        {
            Assert.That(_cs.JsonResponse["categories"][0].ToString().ToLower(), Is.EqualTo("any"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_SecondCategoryIsMisc()
        {
            Assert.That(_cs.JsonResponse["categories"][1].ToString().ToLower(), Is.EqualTo("misc"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_ThirdCategoryIsProgramming()
        {
            Assert.That(_cs.JsonResponse["categories"][2].ToString().ToLower(), Is.EqualTo("programming"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_ForthCategoryIsAny()
        {
            Assert.That(_cs.JsonResponse["categories"][3].ToString().ToLower(), Is.EqualTo("dark"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_FithCategoryIsPun()
        {
            Assert.That(_cs.JsonResponse["categories"][4].ToString().ToLower(), Is.EqualTo("pun"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_SixthCategoryIsSpooky()
        {
            Assert.That(_cs.JsonResponse["categories"][5].ToString().ToLower(), Is.EqualTo("spooky"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_SeventhCategoryIsChristmas()
        {
            Assert.That(_cs.JsonResponse["categories"][6].ToString().ToLower(), Is.EqualTo("christmas"));
        }


        //Tesing Aliases so that if any change then the tests will fail and we will know that they have changed
        [Test]
        public void GivenThatAValidCategoryRequestIsSent_CategoryAliasesOneIsMiscellaneous()
        {
            Assert.That(_cs.JsonResponse["categoryAliases"][0]["alias"].ToString().ToLower(), Is.EqualTo("miscellaneous"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_CategoryAliasesOneIsMisc()
        {
            Assert.That(_cs.JsonResponse["categoryAliases"][0]["resolved"].ToString().ToLower(), Is.EqualTo("misc"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_CategoryAliasesTwoIsCoding()
        {
            Assert.That(_cs.JsonResponse["categoryAliases"][1]["alias"].ToString().ToLower(), Is.EqualTo("coding"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_CategoryAliasesTwoIsProgramming()
        {
            Assert.That(_cs.JsonResponse["categoryAliases"][1]["resolved"].ToString().ToLower(), Is.EqualTo("programming"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_CategoryAliasesThreeIsDevelopment()
        {
            Assert.That(_cs.JsonResponse["categoryAliases"][2]["alias"].ToString().ToLower(), Is.EqualTo("development"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_CategoryAliasesThreeIsProgramming()
        {
            Assert.That(_cs.JsonResponse["categoryAliases"][2]["resolved"].ToString().ToLower(), Is.EqualTo("programming"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_CategoryAliasesFourIsHalloween()
        {
            Assert.That(_cs.JsonResponse["categoryAliases"][3]["alias"].ToString().ToLower(), Is.EqualTo("halloween"));
        }

        [Test]
        public void GivenThatAValidCategoryRequestIsSent_CategoryAliasesFourIsProgramming()
        {
            Assert.That(_cs.JsonResponse["categoryAliases"][3]["resolved"].ToString().ToLower(), Is.EqualTo("spooky"));
        }


    }
}
