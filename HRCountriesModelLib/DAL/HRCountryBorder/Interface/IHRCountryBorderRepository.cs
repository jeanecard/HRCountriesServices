using HRCountriesServicesSolution.Models;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.DAL
{
    interface IHRCountryBorderRepository
    {
        IEnumerable<HRCountryBorder> GetBorderCountries();
        HRCountryBorder GetBorderCountriesByAlpha3Code(string alpha3Code);
    }
}
