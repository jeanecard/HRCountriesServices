using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HRWebServices.Controllers
{
    /// <summary>
    /// Provide a Rest service for resource HRCountryBorder containing OGCFeature of a country (Check : http://www.opengeospatial.org/standards/sfa for more details)
    /// No unit test as implementation is trivial
    /// </summary>
    public class HRCountryBorderController : ApiController
    {
        private IBorderService _borderService = null;


        /// <summary>
        /// Constructeur pour injection de dépendance.
        /// </summary>
        /// <param name="borderService"></param>
        public HRCountryBorderController(IBorderService borderService)
        {
            _borderService = borderService;
        }

        /// <summary>
        /// Retrieve all Known Features.
        /// 1- If _borderService is available, return the resulting service result
        /// 2- If _borderService throw an Exception, return a HRCountryBorder with an errorDescription of the Exception
        /// 3- Else return a HRCountryBorder with an errorDescription indicating that service is not available.
        /// </summary>
        /// <returns>List Of all Know Country Features by Alpha3 Code</returns>
        [Route("api/HRCountryBorder")]
        [HttpGet]
        public async  Task<IEnumerable<HRCountryBorder>> GetAsync()
        {
            if (_borderService != null)
            {
                try
                {
                    //1-
                    return await _borderService.GetBorderCountriesAsync();
                }
                catch(Exception ex)
                {
                    //2-
                    ServiceErrorGenerator<HRCountryBorder> serviceError = new ServiceErrorGenerator<HRCountryBorder>();
                    return serviceError.GenerateErrors(ex.Message);
                }
            }
            else
            {
                //3-
                ServiceErrorGenerator<HRCountryBorder> serviceError = new ServiceErrorGenerator<HRCountryBorder>();
                return serviceError.GenerateErrors(HRCountriesServicesSolution.Constant.BOUNDARIES.BORDER_SERVICE_ERROR_DESCRIPTION);
            }
        }

        /// <summary>
        /// Retrieve a Country Feature by his specific Alpha3Code.
        /// 1- If _borderService is available, return the resulting service result
        /// 2- If _borderService throw an Exception, return a HRCountryBorder with an errorDescription of the Exception
        /// 3- Else return a HRCountryBorder with an errorDescription indicating that service is not available.
        /// </summary>
        /// <param name="alpha3Code">String MinLength = 3 and MaxLength = 3.
        /// For details on ISO3166 Alpha3Code check : https://en.wikipedia.org/wiki/ISO_3166-1_alpha-3 </param>
        /// <returns>The CountryFeature with his Alpha3Code.
        /// Return {"alpha3Code":null,"oGCFeature":null} if Alpha3Code can not be found.
        /// </returns>
        // GET: 
        [Route("api/HRCountryBorder/byAlpha3Code/{alpha3Code:maxlength(3):minlength(3)}")]
        [HttpGet]
     
        public async Task<HRCountryBorder> byAlpha3Code(String alpha3Code)
        {
            if (_borderService != null)
            {
                try
                {
                    //1-
                    return await _borderService.GetBorderCountriesByAlpha3CodeAsync(alpha3Code);
                }
                catch(Exception ex)
                {
                    //2-
                    ServiceErrorGenerator<HRCountryBorder> serviceError = new ServiceErrorGenerator<HRCountryBorder>();
                    return serviceError.GenerateError(ex.Message);
                }
            }
            else
            {
                //3-
                ServiceErrorGenerator<HRCountryBorder> serviceError = new ServiceErrorGenerator<HRCountryBorder>();
                return serviceError.GenerateError(HRCountriesServicesSolution.Constant.BOUNDARIES.BORDER_SERVICE_ERROR_DESCRIPTION);
            }
        }
    }
}
