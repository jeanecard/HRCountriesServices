using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesTests.BUSINESS.HRGeoName
{
    [TestClass]
    public class GeonameRestResponseAnalyserTest
    {
        [TestMethod]
        public void Test_GeonameRestResponseAnalyser_GetBestFittingPlaceName_Return_Null_When_Called_With_Placename_Null()
        {
            GeonameRestResponseAnalyser analyser = new GeonameRestResponseAnalyser();
            List<Geoname> list = new List<Geoname>();
            list.Add(new Geoname());
            Geoname gname = analyser.GetBestFittingPlaceName(null, list);
            Assert.IsNull(gname);
        }
        [TestMethod]
        public void Test_GeonameRestResponseAnalyser_GetBestFittingPlaceName_Return_Null_When_Called_With_Listgeoname_Null()
        {
            GeonameRestResponseAnalyser analyser = new GeonameRestResponseAnalyser();
            Geoname gname = analyser.GetBestFittingPlaceName("TEST", null);
            Assert.IsNull(gname);
        }
        [TestMethod]
        public void Test_GeonameRestResponseAnalyser_GetBestFittingPlaceName_Return_Paris14_When_Called_With_Placename_ListOfParis()
        {
            GeonameRestResponseAnalyser analyser = new GeonameRestResponseAnalyser();
            List<Geoname> list = new List<Geoname>();
            Geoname gname = new Geoname();
            gname.name = "Roule sur Pars";
            list.Add(gname);
            gname = new Geoname();
            gname.name = "Paris la vilette";
            list.Add(gname);
            gname = new Geoname();
            gname.name = "Paris - 14";
            list.Add(gname);

            Geoname gnameresult = analyser.GetBestFittingPlaceName("Paris", list);
            Assert.IsNotNull(gnameresult);
            Assert.AreEqual("Paris - 14", gnameresult.name);
        }
    }
}
