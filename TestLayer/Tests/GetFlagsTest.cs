using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class GetFlagsTest_HappyPath
    {
        GetFlagsService _gfs;
        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _gfs = new GetFlagsService();
            await _gfs.MakeRequestAsync();
        }

        [Test]
        public void GivenThatAFlagRequestIsSent_ThenErrorReturnsFalse()
        {
            Assert.That(_gfs.JsonResponse["error"].ToString().ToLower(), Is.EqualTo("false"));
        }

        [Test]
        public void GivenThatAFlagRequestIsSent_ThenAmountOfFlagsIs6()
        {
            var s = _gfs.JsonResponse["flags"];
            Assert.That(_gfs.JsonResponse["flags"].Count(), Is.EqualTo(6));
        }

        [Test]
        public void GivenThatAFlagRequestIsSent_ThenFlagsAreCorrect()
        {
            var s = _gfs.JsonResponse["flags"];
            Assert.That(_gfs.JsonResponse["flags"][0].ToString(), Is.EqualTo("nsfw"));
            Assert.That(_gfs.JsonResponse["flags"][1].ToString(), Is.EqualTo("religious"));
            Assert.That(_gfs.JsonResponse["flags"][2].ToString(), Is.EqualTo("political"));
            Assert.That(_gfs.JsonResponse["flags"][3].ToString(), Is.EqualTo("racist"));
            Assert.That(_gfs.JsonResponse["flags"][4].ToString(), Is.EqualTo("sexist"));
            Assert.That(_gfs.JsonResponse["flags"][5].ToString(), Is.EqualTo("explicit"));
        }
    }
}
