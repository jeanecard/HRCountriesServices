using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.DependencyResolution;
using HRCountriesServicesSolution.Models;
using RestSharp;
using StructureMap;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace HRWebServices.Controllers
{
    /// <summary>
    /// Provide Rest Service for resource WebCamsTravelRootObject
    /// No unit test as implementation is trivial
    /// </summary>
    public class HRWebCamsTravelController : ApiController
    {

        private IWebCamsTravelService _webCamsTravelService = null;


        /// <summary>
        /// Constructeur pour injection de dépendance.
        /// </summary>
        /// <param name="service"></param>
        public HRWebCamsTravelController(IWebCamsTravelService service)
        {
            _webCamsTravelService = service;
        }


        /// <summary>
        /// Retrieve the best popular WebCam of LifeTime type for a town of a given country.
        /// This provider is directly connected to webcamstravel service available on p.mashape.com.
        /// Coming soon, a specific version on Database supported by MongoDB.
        /// 1- If webCamService is available, return the resulting service
        /// 2- If webCamService  throw an Error, return a WebCamsTravelRootObject Filled with an ErrorDescription of the Exception.
        /// 3- Else if webCamService is unavailable return a WebCamsTravelRootObject Fill an ErrorDescription
        /// </summary>
        /// <param name="country">Country ALPHA3Code. MinLength = MaxLength = 3</param>
        /// <param name="capital">a Town name of the given Country.</param>
        /// <returns></returns>
        [Route("api/HRWebCamsTravel/{country:maxlength(2):minlength(2)}/{capital}/Best")]
        [HttpGet]
        public async Task<WebCamsTravelRootObject> Get(String country, String capital)
        {



            if (_webCamsTravelService != null)
            {
                try
                {
                    //1-
                    return await _webCamsTravelService.GetBestWebCam(country, capital);
                }
                catch(Exception ex)
                {
                    //2-
                    ServiceErrorGenerator<WebCamsTravelRootObject> serviceError = new ServiceErrorGenerator<WebCamsTravelRootObject>();
                    return serviceError.GenerateError(ex.Message);
                }
            }
            else
            {
                //3-
                ServiceErrorGenerator<WebCamsTravelRootObject> serviceError = new ServiceErrorGenerator<WebCamsTravelRootObject>();
                return serviceError.GenerateError(HRCountriesServicesSolution.Constant.WEBCAMTRAVEL.WEBCAMS_TRAVEL_SERVICE_ERROR_DESCRIPTION);
            }
        }
    }
}
