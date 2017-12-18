using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// CountriesIteration Services Interface
    /// </summary>
    public interface ICountriesIterationService
    {
        ///// <summary>
        ///// Get The first CoutnriesIteration that contains the next iteration ID too.
        ///// </summary>
        ///// <returns></returns>
        //Task<IEnumerable<CountriesIteration>>  GetCountriesIterationAsync();

        /// <summary>
        /// Get a specific CountriesIteration.
        /// </summary>
        /// <param name="Id">ID is server given from GetCountriesIteration or String.empty for first iteration.</param>
        /// <returns>A countriesIteration containing the next CountriesIteration ID if exists.</returns>
        Task<CountriesIteration> GetCountrieIterationAsync(String Id);

        /// <summary>
        /// Get a specific countryIteration containing Countries filterd by Region.
        /// </summary>
        /// <param name="Id">ID is server given from GetCountriesIteration or String.empty for first iteration.</param>
        /// <returns>A countryIteration with Country in the given Region and the next CountryIteration ID if exists.</returns>
        Task<CountriesIteration> GetCountriesIterationByRegionAsync(String Id);

        /// <summary>
        /// Get a specific countryIteration containing Countries filterd by alpha3Code.
        /// </summary>
        /// <param name="alpha3Code">a Country Alpha3Code. e.g : 'FRA' foir France.</param>
        /// <returns>The countryIteration with the corresponding Alpha3Code Country if exists.</returns>
        Task<CountriesIteration> GetCountriesIterationByAlpha3CodeAsync(String alpha3Code);
    }
}
