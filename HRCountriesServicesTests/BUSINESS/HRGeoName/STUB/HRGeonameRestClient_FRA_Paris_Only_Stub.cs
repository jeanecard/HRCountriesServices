using HRCountriesServicesSolution.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesTests.BUSINESS.Tests
{
    class HRGeonameRestClient_FRA_Paris_Only_Stub : IHRGeonameRestClient
    {
        String _capital = "";
        public string Capital
        {
            get
            {
                return _capital;
            }

            set
            {
                _capital = value;
            }
        }
        String _country = "";
        public string Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }

        public async Task<List<Geoname>> Execute()
        {
            //Fake async
            await Task.Delay(10);
            List<Geoname> retour = new List<Geoname>();
            if (_country == "FRA" && _capital == "Paris")
            {
                Geoname geon = new Geoname();
                geon.name = "PARIS";
                geon.lat = "10.0";
                geon.lng = "10.0";
                retour.Add(geon);
             }
            return retour;
        }
    }
}
