using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class GetJokeResponseTest_HappyPath
    {
        GetJokeService _ps;
        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _ps = new GetJokeService();
            await _ps.MakeRequestAsync();
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenStatusReturns200()
        {
            Assert.That(_ps.CallManager.StatusDescription, Is.EqualTo("OK"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenErrorReturnsalse()
        {
            Assert.That(_ps.JsonResponse["error"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenCategoryIsCorrect()
        {
            Assert.That(_ps.JsonResponse["category"].ToString(), Is.EqualTo("Programming"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenTypeIsCorrect()
        {
            Assert.That(_ps.JsonResponse["type"].ToString(), Is.EqualTo("single"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenJokeIsCorrect()
        {
            Assert.That(_ps.JsonResponse["joke"].ToString(), 
            Is.EqualTo("I've got a really good UDP joke to tell you but I don’t know if you'll get it."));
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenFlagsAreCorrectBool()
        {
            Assert.That(_ps.JsonResponse["flags"]["nsfw"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenIDIsCorrect()
        {
            Assert.That(_ps.JsonResponse["id"].ToString(), Is.EqualTo("0"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenSafeIsTrue()
        {
            Assert.That(_ps.JsonResponse["safe"].ToString().ToLower(), Is.EqualTo("true")); 
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenLanguageIsEnglish()
        {
            Assert.That(_ps.JsonResponse["lang"].ToString().ToLower(), Is.EqualTo("en"));
        }

    }
}
