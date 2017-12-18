using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using System.Threading.Tasks;
using HRCountriesServicesTests.DAL;
using System.Collections.Generic;

namespace HRCountriesServicesTests
{
    [TestClass]
    public class BufferisedHRCountryBorderRepositoryTest
    {
        [TestMethod]
        public async Task Test_BufferedCountriesRepository_GetCountryByAlpha3CodeAsync_Return_FRA_When_Called_With_FRA()
        {
            BufferedCountriesRepository repo = new BufferedCountriesRepository(new HRStubCountriesGetter());
            CountryModel cModel = await repo.GetCountryByAlpha3CodeAsync("FRA");
            Assert.IsNotNull(cModel);
            Assert.AreEqual("FRA", cModel.alpha3Code);
        }
    }
}
