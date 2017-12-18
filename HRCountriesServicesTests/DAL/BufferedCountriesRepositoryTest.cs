using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using System.Threading.Tasks;
using HRCountriesServicesTests.DAL;
using System.Collections.Generic;

namespace HRCountriesServicesTests
{
    [TestClass]
    public class BufferedCountriesRepositoryTest
    {
        [TestMethod]
        public async Task Test_BufferedCountriesRepository_Return_Fra_When_Called_With_FRA()
        {
            BufferedCountriesRepository repo = new BufferedCountriesRepository(new HRStubCountriesGetter());
            CountryModel cModel = await repo.GetCountryByAlpha3CodeAsync("FRA");
            Assert.IsNotNull(cModel);
            Assert.AreEqual("FRA", cModel.alpha3Code);
        }

        [TestMethod]
        public async Task Test_BufferedCountriesRepository_Return_Null_When_Called_With_Unexisting_Alpha3Code()
        {
            BufferedCountriesRepository repo = new BufferedCountriesRepository(new HRStubCountriesGetter());
            CountryModel cModel = await repo.GetCountryByAlpha3CodeAsync("ZZZ");
            Assert.IsNull(cModel);
        }
        [TestMethod]
        public async Task Test_BufferedCountriesRepository_Return_All_Countries_When_Called_With_No_Parameter()
        {
            BufferedCountriesRepository repo = new BufferedCountriesRepository(new HRStubCountriesGetter());
            List<CountryModel> countries = await repo.GetCountriesAsync();
            Assert.IsNotNull(countries);
            Assert.AreEqual(250, countries.Count);
        }
    }
}
