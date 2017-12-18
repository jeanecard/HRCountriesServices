using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using HRCountriesServicesTests.BUSINESS.HRCountriesIteration.STUB;
using HRCountriesServicesTests.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesTests.BUSINESS.HRCountriesIteration
{
    [TestClass]
    public class CountriesIterationServiceTest
    {
        [TestMethod]
        public async Task TestCountriesITerationService_GetCountriesIterationByAlpha3CodeAsync_Return_France_When_Called_With_FRA()
        {
            BufferedCountriesIterationRepository repo = new BufferedCountriesIterationRepository(new HRStubCountriesGetter());
            CountriesServiceFRAStub countryService = new CountriesServiceFRAStub();
            CountriesIterationService service = new CountriesIterationService(countryService, repo);
            CountriesIteration ci = await service.GetCountriesIterationByAlpha3CodeAsync("FRA");
            Assert.IsNotNull(ci);
            Assert.AreEqual("", ci.iterationKey);
            Assert.AreEqual("FRA", ci.countries[0].alpha3Code);
            Assert.AreEqual(1, ci.countries.Count);
        }
        [TestMethod]
        public async Task TestCountriesITerationService_GetCountriesIterationByAlpha3CodeAsync_Return_Empty_When_Called_With_Unexisting_Code()
        {
            BufferedCountriesIterationRepository repo = new BufferedCountriesIterationRepository(new HRStubCountriesGetter());
            CountriesServiceFRAStub countryService = new CountriesServiceFRAStub();
            CountriesIterationService service = new CountriesIterationService(countryService, repo);
            CountriesIteration ci = await service.GetCountriesIterationByAlpha3CodeAsync("ZZZ");
            Assert.IsNotNull(ci);
            Assert.AreEqual("", ci.iterationKey);
            Assert.AreEqual(0, ci.countries.Count);
        }
    }
}
