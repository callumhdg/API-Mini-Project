using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class SubmitJokeResponseTest_HappyPath
    {
        SubmitJokeService _sjs;
        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _sjs = new SubmitJokeService();

            JObject body = new JObject();
            body["formatVersion"] = 3;
            body["category"] = "Misc";
            body["type"] = "single";
            body["joke"] = "A horse walks into a bar...";
            body["flags"] =  new JObject
            { ["nsfw"] = false,
                ["religious"] = false,
                ["political"] = false,
                ["racist"] = false,
                ["sexist"] = false,
                ["explicit"] = false,
            };
            body["lang"] = "en";

            await _sjs.SubmitJokeRequestAsync(body);
        }

        [Test]
        public void GivenAValidJoke_Status201IsReturned()
        {
            Assert.That(_sjs.CallManager.StatusDescription, Is.EqualTo("Created"));
        }

        [Test]
        public void GivenAValidJoke_ErrorIsFalse()
        {
            Assert.That(_sjs.JsonResponse["error"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test] 
        public void GivenAValidJoke_MessageIsCorrect()
        {
            Assert.That(_sjs.JsonResponse["message"].ToString(), Is.EqualTo("Joke submission was successfully saved. It will soon be checked out by the author."));
        }

        [Test]
        public void GivenAValidJoke_CategoryIsMisc()
        {
            Assert.That(_sjs.JsonResponse["submission"]["category"].ToString(), Is.EqualTo("Misc"));
        }

        [Test]
        public void GivenAValidJoke_TypeIsSingle()
        {
            Assert.That(_sjs.JsonResponse["submission"]["type"].ToString(), Is.EqualTo("single"));
        }

        [Test]
        public void GivenAValidJoke_JokeIsCorrect()
        {
            Assert.That(_sjs.JsonResponse["submission"]["joke"].ToString(), Is.EqualTo("A horse walks into a bar..."));
        }

        [Test]
        public void GivenAValidJoke_LangIsEn()
        {
            Assert.That(_sjs.JsonResponse["submission"]["lang"].ToString(), Is.EqualTo("en"));
        }

        [Test]
        public void GivenAValidJoke_FlagsNsfwIsFalse()
        {
            Assert.That(_sjs.JsonResponse["submission"]["flags"]["nsfw"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenAValidJoke_FlagsReligiousIsFalse()
        {
            Assert.That(_sjs.JsonResponse["submission"]["flags"]["religious"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenAValidJoke_FlagsPoliticalIsFalse()
        {
            Assert.That(_sjs.JsonResponse["submission"]["flags"]["political"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenAValidJoke_FlagsRacistIsFalse()
        {
            Assert.That(_sjs.JsonResponse["submission"]["flags"]["racist"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenAValidJoke_FlagsSexistIsFalse()
        {
            Assert.That(_sjs.JsonResponse["submission"]["flags"]["sexist"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenAValidJoke_FlagsExplicitIsFalse()
        {
            Assert.That(_sjs.JsonResponse["submission"]["flags"]["explicit"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenAValidJoke_TimesampIsNotNull()
        {
            Assert.That(_sjs.JsonResponse["timestamp"], Is.Not.Null);
        }
    }

    public class SubmitJokeResponseTest_UnhappyPath
    {
        SubmitJokeService _sjs;
        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _sjs = new SubmitJokeService();

            JObject body = new JObject();
            
            await _sjs.SubmitJokeRequestAsync(body);
        }

        [Test]
        public void GivenAnInvalidJoke_StatusBadRequestIsReturned()
        {
            Assert.That(_sjs.CallManager.StatusDescription, Is.EqualTo("BadRequest"));
        }

        [Test]
        public void GivenAnInvalidJoke_ErrorIsTrue()
        {
            Assert.That(_sjs.JsonResponse["error"].ToString().ToLower(), Is.EqualTo("true"));
        }

        [Test]
        public void GivenAnInvalidJoke_MessageIsCorrect()
        {
            Assert.That(_sjs.JsonResponse["message"].ToString(), Is.EqualTo("Malformed Joke"));
        }

        [Test]
        public void GivenAnInvalidJoke_CodeIs105()
        {
            Assert.That(_sjs.JsonResponse["code"].ToString(), Is.EqualTo("105"));
        }

        [Test]
        public void GivenAnInvalidJoke_InternalErrorIsFalse()
        {
            Assert.That(_sjs.JsonResponse["internalError"].ToString().ToLower(), Is.EqualTo("false"));
        }

    }

}
