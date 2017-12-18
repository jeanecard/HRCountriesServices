using HRCountriesServicesSolution.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesTests.BUSINESS.HRCountriesIteration.STUB
{
    public class CountriesServiceFRAStub : ICountriesService
    {
        public async Task<CountryModel> GetCountryByAlpha3CodeAsync(string alpha3Code)
        {
            //Fake async
            await Task.Delay(10);
            if (alpha3Code == "FRA")
            {
                CountryModel retour = new CountryModel();
                retour.alpha3Code = "FRA";
                return retour;
            }
            else
            {
                return null;
            }
        }
    }
}
