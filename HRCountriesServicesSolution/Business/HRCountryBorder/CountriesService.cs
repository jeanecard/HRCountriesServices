using HRCountriesServicesSolution.Constant;
using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using System;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// CountryModel Services Implementation
    /// No unit test as implementation is trivial
    /// </summary>
    public class CountriesService : ICountriesService
    {
        private ICountriesRepository _repo = null;


        /// <summary>
        /// Dependancy injection by constructor.
        /// </summary>
        public CountriesService(ICountriesRepository countryRepo)
        {
            _repo = countryRepo; 
        }
        /// <summary>
        ///  Get CountryModel by alpha3Code
        /// 1- If repository is available, return repository Result
        /// 3- Else, return an Exception
        /// </summary>
        /// <param name="alpha3Code">a Country Alpha3Code. e.g : 'FRA' foir France</param>
        /// <returns>CountryModel with alpha3Code null if does not exists</returns>
        public async Task<CountryModel> GetCountryByAlpha3CodeAsync(string alpha3Code)
        {
            if(_repo != null)
            {
                //1
                return await  _repo.GetCountryByAlpha3CodeAsync(alpha3Code);
            }
            else
            {
                //2-
                throw new Exception(HRCountriesServicesSolution.Constant.COUNTRIES.COUNTRIES_REPOSITORY_ERROR_DESCRIPTION);
            }
        }
    }
}