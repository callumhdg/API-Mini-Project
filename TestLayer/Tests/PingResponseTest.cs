using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer
{
    public class PingResponseTest
    {
        PingService _ps;
        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _ps = new PingService();
            await _ps.MakeRequestAsync();
        }
        
        [Test]
        public void GivenThatAPingRequestIsSent_ThenStatusReturns200() 
        {
            Assert.That(_ps.CallManager.StatusDescription,Is.EqualTo("OK")) ;
        }
    }
}
