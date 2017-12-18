using HRCountriesServicesSolution.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesTests.BUSINESS.HRGeoName
{
    [TestClass]
    public class LevensteinTest
    {
        [TestMethod]
        public void Test_Leveinstein_Return_0_When_Called_With_Two_Identical_Arguments()
        {
            Assert.AreEqual(0, LevenshteinDistance.Compute("FRA", "FRA"));
        }
        [TestMethod]
        public void Test_Leveinstein_Return_0_When_Called_With_Two_Null_Arguments()
        {
            Assert.AreEqual(0, LevenshteinDistance.Compute(null, null));
        }
        [TestMethod]
        public void Test_Leveinstein_Return_4_When_Called_With_FRA_And_Fra12()
        {
            Assert.AreEqual(4, LevenshteinDistance.Compute("FRA", "Fra12"));
        }
        [TestMethod]
        public void Test_Leveinstein_Return_2_When_Called_With_FRA_And_FRA12()
        {
            Assert.AreEqual(2, LevenshteinDistance.Compute("FRA", "FRA12"));
        }
        [TestMethod]
        public void Test_Leveinstein_Return_1_When_Called_With_FRA_And_FRâ()
        {
            Assert.AreEqual(1, LevenshteinDistance.Compute("FRA", "FRâ"));
        }

    }
}
