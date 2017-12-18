using HRCountriesServicesSolution.Constant;
using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// CountriesIterationService interface implementation
    /// </summary>
    public class CountriesIterationService : ICountriesIterationService
    {
        private ICountriesIterationRepository _repo = null;
        private ICountriesService _countryService = null;

        /// <summary>
        /// Constructor dependancy injection
        /// </summary>
        public CountriesIterationService(ICountriesService cService, ICountriesIterationRepository ciRepo)
        {
            _repo = ciRepo;
            _countryService = cService;
        }

        /// <summary>
        /// Get a specific CountriesIteration.
        /// 1- If Repository is available return result
        /// 2- Else throw Exception.
        /// </summary>
        /// <param name="Id">ID is server given from GetCountriesIteration or String.empty for first iteration.</param>
        /// <returns>A countriesIteration containing the next CountriesIteration ID if exists.</returns>
        public async  Task<CountriesIteration> GetCountrieIterationAsync(String Id)
        {
            if (_repo != null)
            {
                //1-
                return await _repo.GetCountrieIterationAsync(Id);
            }
            else
            {
                //2-
                throw new Exception(HRCountriesServicesSolution.Constant.COUNTRIESITERATION.COUNTRIESITERATION_REPOSITORY_ERROR_DESCRIPTION);
            }
        }

        /// <summary>
        /// Get a specific countryIteration containing Countries filterd by alpha3Code.
        /// Based on the CountryService
        /// 1- If CountryService is available return result
        /// 2- Else throw Exception.
        /// </summary>
        /// <param name="alpha3Code">a Country Alpha3Code. e.g : 'FRA' foir France.</param>
        /// <returns>The countryIteration with the corresponding Alpha3Code Country if exists.</returns>
        public async Task<CountriesIteration> GetCountriesIterationByAlpha3CodeAsync(string alpha3Code)
        {
            //1-
            if (_countryService != null)
            {
                //Do not catch Exception
                CountryModel country = await _countryService.GetCountryByAlpha3CodeAsync(alpha3Code);
                CountriesIteration retour = new CountriesIteration();
                retour.countries = new List<CountryModel>();
                if (country != null)
                {
                    retour.countries.Add(country);
                    retour.finalItemsCount = 1;
                }
                else
                {
                    retour.finalItemsCount = 0;
                }
                retour.iterationKey = String.Empty;
                return retour;
            }
            else
            {
                //2-
                throw new Exception(HRCountriesServicesSolution.Constant.COUNTRIESITERATION.COUNTRIESITERATION_SERVICE_ERROR_DESCRIPTION);
            }
        }

        /// <summary>
        /// Get a specific countryIteration containing Countries filterd by Region.
        /// 1- If Repository is available return result
        /// 2- Else throw Exception.
        /// </summary>
        /// <param name="Id">ID is server given from GetCountriesIteration or String.empty for first iteration.</param>
        /// <returns>A countryIteration with Country in the given Region and the next CountryIteration ID if exists.</returns>
        public async Task<CountriesIteration> GetCountriesIterationByRegionAsync(string Id)
        {
            //1-
            if (_repo != null)
            {
                return await _repo.GetCountriesIterationByRegionAsync(Id);
            }
            else
            {
                //2-
                throw new Exception(HRCountriesServicesSolution.Constant.COUNTRIESITERATION.COUNTRIESITERATION_REPOSITORY_ERROR_DESCRIPTION);
            }
        }
    }
}