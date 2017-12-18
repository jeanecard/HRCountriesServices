using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.Models;
using HRCountriesServicesTests.BUSINESS.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesTests.BUSINESS.HRWebCamsTravel
{
    [TestClass]
    public class WebCamsTravelFacadeTest
    {
        [TestMethod]
        public async Task Test_WebCamsTravelService_GetBestWebCam_Return_Null_When_Capital_Does_Not_Exist()
        {
            WebCamsTravelService service = new WebCamsTravelService(new HRGeonameRestClient_FRA_Paris_Only_Stub(), new HRWebCamsTravelRestClientStub());
            WebCamsTravelRootObject retour = await service.GetBestWebCam("FRA", "ZZZZZZZZZZZZZ");
            Assert.IsNull(retour);
        }
        [TestMethod]
        public async Task Test_WebCamsTravelService_GetBestWebCam_Return_Null_When_Country_Does_Not_Exist()
        {
            WebCamsTravelService service = new WebCamsTravelService( new HRGeonameRestClient_FRA_Paris_Only_Stub(), new HRWebCamsTravelRestClientStub());
            WebCamsTravelRootObject retour = await service.GetBestWebCam("ZZZZZZZZ", "Paris");
            Assert.IsNull(retour);
        }
        [TestMethod]
        public async Task Test_WebCamsTravelService_GetBestWebCam_Return_ParisWebCam_When_Paris_France_Queried()
        {
            WebCamsTravelService service = new WebCamsTravelService( new HRGeonameRestClient_FRA_Paris_Only_Stub(), new HRWebCamsTravelRestClientStub());
            WebCamsTravelRootObject retour = await service.GetBestWebCam("FRA", "Paris");
            Assert.IsNotNull(retour);
            Assert.IsNotNull(retour.result);
            Assert.IsNotNull(retour.result.webcams);
            Assert.IsNotNull(retour.result.webcams[0]);
            Assert.IsNotNull(retour.result.webcams[0].player);
            Assert.IsNotNull(retour.result.webcams[0].player.lifetime);
            Assert.AreEqual("Embeded", retour.result.webcams[0].player.lifetime.embed);
            Assert.AreEqual(true, retour.result.webcams[0].player.lifetime.available);
        }
    }
}
