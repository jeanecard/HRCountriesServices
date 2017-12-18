using HRCountriesServicesSolution.Constant;
using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HRWebServices.Controllers
{
    /// <summary>
    /// Provide a Rest service for resource CountriesIteration
    /// No unit test as implementation is trivial
    /// </summary>
    public class HRCountriesIterationsController : ApiController
    {
        private ICountriesIterationService _countriesIterationService = null;
        

        /// <summary>
        /// Constructor dependancy injection
        /// </summary>
        /// <param name="countryIterationService"></param>
        public HRCountriesIterationsController(ICountriesIterationService countryIterationService)
        {
            _countriesIterationService = countryIterationService;
        }


        /// <summary>
        /// Get CountrieIteration for a specific ALPHA3CODE.
        /// 1- If _countriesIterationService is available, return service Result
        /// 2- If _countriesIterationService throw an exception, return a CountriesIteration with the resulting error.
        /// 3- Else, return a CountriesIteration with unavailability Error.
        /// </summary>
        /// <param name="alpha3Code">ISO3166 CountryCode. MaxLength = 3. Can be null</param>
        /// <returns>CountriesIteration</returns>
        [Route("api/HRCountriesIterations/Alpha3Code/{alpha3Code:maxlength(3)}")]
        [HttpGet]
        public async Task<CountriesIteration> Alpha3Code(String alpha3Code = null)
        {
            if(_countriesIterationService != null)
            {
                try
                {
                    //1-
                    return await _countriesIterationService.GetCountriesIterationByAlpha3CodeAsync(alpha3Code);
                }
                catch(Exception ex)
                {
                    //2-
                    ServiceErrorGenerator<CountriesIteration> serviceError = new ServiceErrorGenerator<CountriesIteration>();
                    return serviceError.GenerateError(ex.Message);
                }
            }
            else
            {
                //3-
                ServiceErrorGenerator<CountriesIteration> serviceError = new ServiceErrorGenerator<CountriesIteration>();
                return serviceError.GenerateError(HRCountriesServicesSolution.Constant.COUNTRIESITERATION.COUNTRIESITERATION_SERVICE_ERROR_DESCRIPTION);
            }
        }


        /// <summary>
        /// Get a CountriesIteration for a specific Region
        /// 1- If _countriesIterationService is available, return service Result
        /// 2- If _countriesIterationService throw an exception, return a CountriesIteration with the resulting error.
        /// 3- Else, return a CountriesIteration with unavailability Error.
        /// </summary>
        /// <param name="id">String without constraint</param>
        /// <returns>If id can not be retrieved, return {countries:[], finalItemsCount:0, iterationKey:''} </returns>
        [Route("api/HRCountriesIterations/Region/{id:minlength(3)}")]
        [HttpGet]
        public async Task<CountriesIteration> Region(String id = null)
        {
            if (_countriesIterationService != null)
            {
                try
                {
                    //1-
                    return await _countriesIterationService.GetCountriesIterationByRegionAsync(id);
                }
                catch(Exception ex)
                {
                    //-2
                    ServiceErrorGenerator<CountriesIteration> serviceError = new ServiceErrorGenerator<CountriesIteration>();
                    return serviceError.GenerateError(ex.Message);
                }
            }
            else
            {
                //3-
                ServiceErrorGenerator<CountriesIteration> serviceError = new ServiceErrorGenerator<CountriesIteration>();
                return serviceError.GenerateError(HRCountriesServicesSolution.Constant.COUNTRIESITERATION.COUNTRIESITERATION_SERVICE_ERROR_DESCRIPTION);
            }
        }

        /// <summary>
        /// Provide CountriesIteration for a specific iteration Id
        /// 1- If _countriesIterationService is available, return service Result. If Id is null return the first iteration, else return the expected iteration with id.
        /// 2- If _countriesIterationService throw an exception, return a CountriesIteration with the resulting error.
        /// 3- Else, return a CountriesIteration with unavailability Error.
        /// Note This service is asynchronous in backend. A specific delay of 2 seconds can be added for test purpose.
        /// </summary>
        /// <param name="id">String without constraint. Give a null parameter for the first iteration. BackEnd will generate the folllowing iteration sequence in the response body.</param>
        /// <returns>If id can not be retrieved, return {countries:[], finalItemsCount:0, iterationKey:''} </returns>

        public async Task<CountriesIteration> Get(String id = null)
        {
            if (_countriesIterationService != null)
            {
                try
                {
                    //1-
                    return await _countriesIterationService.GetCountrieIterationAsync(id);
                }
                catch(Exception ex)
                {
                    //-2
                    ServiceErrorGenerator<CountriesIteration> serviceError = new ServiceErrorGenerator<CountriesIteration>();
                    return serviceError.GenerateError(ex.Message);
                }
            }
            else
            {
                //3-
                ServiceErrorGenerator<CountriesIteration> serviceError = new ServiceErrorGenerator<CountriesIteration>();
                return serviceError.GenerateError(HRCountriesServicesSolution.Constant.COUNTRIESITERATION.COUNTRIESITERATION_SERVICE_ERROR_DESCRIPTION);
            }
        }
    }
}
