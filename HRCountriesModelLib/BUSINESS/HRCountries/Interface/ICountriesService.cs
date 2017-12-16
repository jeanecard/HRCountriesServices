using HRCountriesServicesSolution.Models;
using System;

namespace HRCountriesServicesSolution.Business
{
    interface ICountriesService
    {
        CountryModel GetCountryByAlpha3Code(String alpha3Code);
    }
}
