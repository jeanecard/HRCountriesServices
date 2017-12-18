using HRCountriesServicesSolution.Models;
using System;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    ///  CountryModel Services Interface
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Get CountryModel by alpha3Code
        /// </summary>
        /// <param name="alpha3Code">a Country Alpha3Code. e.g : 'FRA' foir France</param>
        /// <returns>CountryModel with alpha3Code null if does not exists</returns>
        Task<CountryModel> GetCountryByAlpha3CodeAsync(String alpha3Code);
    }
}
