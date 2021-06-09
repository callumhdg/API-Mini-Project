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
            await _ps.MakeRequestAsync(0);
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenStatusReturnsOK()
        {
            Assert.That(_ps.CallManager.StatusDescription, Is.EqualTo("OK"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSent_ThenErrorReturnsFalse()
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

    public class GetJokeResponseTest_UnHappyPath
    {
        GetJokeService _ps;
        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _ps = new GetJokeService();
            await _ps.MakeRequestAsync(100000);
        }

        [Test]
        public void GivenThatAJokeRequestIsSentAndItDoesNotExist_ThenStatusReturns()
        {
            Assert.That(_ps.CallManager.StatusDescription, Is.EqualTo("OK"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSentAndItDoesNotExist_ThenErrorReturnTrue()
        {
            Assert.That(_ps.JsonResponse["error"].ToString().ToLower(), Is.EqualTo("true"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSentAndItDoesNotExist_ThenTheInternalErrorIsFalse()
        {
            Assert.That(_ps.JsonResponse["internalError"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSentAndItDoesNotExist_ThenCodeIs106()
        {
            Assert.That(_ps.JsonResponse["code"].ToString(), Is.EqualTo("106"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSentAndItDoesNotExist_ThenCorrectMessageIsReturned()
        {
            Assert.That(_ps.JsonResponse["message"].ToString(), Is.EqualTo("No matching joke found"));
        }

        [Test]
        public void GivenThatAJokeRequestIsSentAndItDoesNotExist_ThenCausedByMessageIsCorrect()
        {
            Assert.That(_ps.JsonResponse["causedBy"][0].ToString(), Is.EqualTo("No jokes were found that match your provided filter(s)."));
        }

        [Test]
        public void GivenThatAJokeRequestIsSentAndItDoesNotExist_ThenAdditionalInfoIsReturned()
        {
            Assert.That(_ps.JsonResponse["additionalInfo"].ToString(), 
            Is.EqualTo("The specified ID range is invalid. Got: \"100000\" but max possible ID range is: \"0-303\"."));

        }
    }
}
