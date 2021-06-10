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

        [Ignore("Not implemented")]
        [Test]
        public void GivenThatAValidCategoryRequestIsSent_ExactlySevenCategoriesAreReturned()
        {
            //
        }



    }
}
