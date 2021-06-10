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
        public void GivenThatAFlagRequestIsSent_ThenFirstFlagIsNsfw()
        {
            Assert.That(_gfs.JsonResponse["flags"][0].ToString(), Is.EqualTo("nsfw"));
        }

        [Test]
        public void GivenThatAFlagRequestIsSent_ThenSecondFlagIsReligious()
        {
            Assert.That(_gfs.JsonResponse["flags"][1].ToString(), Is.EqualTo("religious"));
        }

        [Test]
        public void GivenThatAFlagRequestIsSent_ThenThirdFlagIsPolitical()
        {
            Assert.That(_gfs.JsonResponse["flags"][2].ToString(), Is.EqualTo("political"));
        }

        [Test]
        public void GivenThatAFlagRequestIsSent_ThenFourthFlagIsRacist()
        {
            Assert.That(_gfs.JsonResponse["flags"][3].ToString(), Is.EqualTo("racist"));
        }

        [Test]
        public void GivenThatAFlagRequestIsSent_ThenFifthFlagIsSexist()
        {
            Assert.That(_gfs.JsonResponse["flags"][4].ToString(), Is.EqualTo("sexist"));
        }

        [Test]
        public void GivenThatAFlagRequestIsSent_ThenSixthFlagIsExplicit()
        {
            Assert.That(_gfs.JsonResponse["flags"][5].ToString(), Is.EqualTo("explicit"));
        }



    }
}
