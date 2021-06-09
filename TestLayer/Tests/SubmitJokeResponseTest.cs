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



    }

}
