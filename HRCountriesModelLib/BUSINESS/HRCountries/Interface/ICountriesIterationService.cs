using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.Business
{
    interface ICountriesIterationService
    {
        IEnumerable<CountriesIteration>  GetCountriesIteration();
        CountriesIteration GetCountrieIteration(String Id);

        CountriesIteration GetCountriesIterationByRegion(String Id);
    }
}
