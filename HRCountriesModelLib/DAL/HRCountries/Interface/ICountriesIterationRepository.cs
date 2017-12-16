using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.DAL
{
    interface ICountriesIterationRepository
    {
        IEnumerable<CountriesIteration> GetCountriesIteration();
        CountriesIteration GetCountrieIteration(String Id);
        CountriesIteration GetCountriesIterationByRegion(string Id);
    }
}
