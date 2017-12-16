using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.DAL
{
    interface ICountriesRepository
    {
        CountryModel GetCountryByAlpha3Code(string alpha3Code);
        List<CountryModel> GetCountries();
        void Reset();
        void Initialize();

    }
}
