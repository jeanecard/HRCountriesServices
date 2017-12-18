using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using HRCountriesServicesTests.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRCountriesServicesTests
{
    [TestClass]
    public class BufferedCountriesIterationRepositoryTest
    {
        [TestMethod]
        public async Task Test_BufferedCountriesIterationRepository_GetCountrieIterationAsync_Return_FirstIteration_When_Called_With_Empty_String()
        {
            BufferedCountriesIterationRepository repo = new BufferedCountriesIterationRepository(new HRStubCountriesGetter());
            CountriesIteration retour = await repo.GetCountrieIterationAsync("");
            Assert.IsNotNull(retour);
            //Test de la première itération
            Assert.AreEqual("1", retour.iterationKey);
            Assert.AreEqual(250, retour.finalItemsCount);
            Assert.IsNull(retour.countries);
        }
        [TestMethod]
        public async Task Test_BufferedCountriesIterationRepository_GetCountrieIterationAsync_Return_Null_When_Called_With_Unexisting_String()
        {
            BufferedCountriesIterationRepository repo = new BufferedCountriesIterationRepository(new HRStubCountriesGetter());
            CountriesIteration retour = await repo.GetCountrieIterationAsync("ZZZZZ");
            Assert.IsNull(retour);
        }
        [TestMethod]
        public async Task Test_BufferedCountriesIterationRepository_GetCountrieIterationAsync_Return_Iteration2_When_Called_With_2()
        {
            BufferedCountriesIterationRepository repo = new BufferedCountriesIterationRepository(new HRStubCountriesGetter());
            CountriesIteration retour = await repo.GetCountrieIterationAsync("2");
            Assert.AreEqual("3", retour.iterationKey);
            Assert.AreEqual(250, retour.finalItemsCount);
            Assert.IsNotNull(retour.countries);
            Assert.AreEqual(101, retour.countries.Count);
        }
        [TestMethod]
        public async Task Test_BufferedCountriesIterationRepository_GetCountriesIterationByRegionAsync_Return_AllEuropean_Countries_When_Called_With_Europe()
        {
            BufferedCountriesIterationRepository repo = new BufferedCountriesIterationRepository(new HRStubCountriesGetter());
            CountriesIteration retour = await repo.GetCountriesIterationByRegionAsync("Europe");
            Assert.AreEqual("", retour.iterationKey);
            Assert.IsTrue(retour.finalItemsCount > 0);
            Assert.IsNotNull(retour.countries);
            Assert.IsTrue(retour.countries.Count > 0);
            foreach(CountryModel iter in retour.countries)
            {
                Assert.AreEqual("Europe", iter.region);
            }

        }
        [TestMethod]
        public async Task Test_BufferedCountriesIterationRepository_GetCountriesIterationByRegionAsync_Return_Null_When_Called_With_Unexisting_Region()
        {
            BufferedCountriesIterationRepository repo = new BufferedCountriesIterationRepository(new HRStubCountriesGetter());
            CountriesIteration retour = await repo.GetCountriesIterationByRegionAsync("ZZZZZZ");
            Assert.AreEqual("", retour.iterationKey);
            Assert.IsTrue(retour.finalItemsCount == 0);
            Assert.IsNotNull(retour.countries);
            Assert.IsTrue(retour.countries.Count == 0);
        }

    }
}
