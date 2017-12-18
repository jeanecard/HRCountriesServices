using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HRWebServices.Controllers
{
    /// <summary>
    /// Provide Rest Service for resource HRRegion
    /// No unit test as implementation is trivial
    /// </summary>
    public class HRRegionController : ApiController
    {
        private IHRRegionsService _regionsService = null;


        /// <summary>
        /// Constructor for dependancy injection
        /// </summary>
        /// <param name="regionService">injected by StructureMap</param>
        public HRRegionController(IHRRegionsService regionService)
        {
            _regionsService = regionService;
        }

        /// <summary>
        /// Get all HRRegions available.
        /// 1- If regionService is available, return the resulting service
        /// 2- If regionService is unavailable return a IEnumerable"HRRegion" Fill with a HRRegion Error
        /// 3- If any Exception is catch, return a IEnumerable"HRRegion" Fill with a HRRegion Error describing the Exception.
        /// </summary>
        /// <returns>List of HRRegion</returns>
        [HttpGet]
        [Route("api/HRRegions")]
        public async Task<IEnumerable<HRRegion>> Get()
        {
            IEnumerable<HRRegion> retour = null;
            if (_regionsService != null)
            {
                try
                {
                    //1-
                    retour = await _regionsService.GetRegionsAsync();
                }
                catch(Exception ex)
                {
                    //2-
                    ServiceErrorGenerator<HRRegion> serviceError = new ServiceErrorGenerator<HRRegion>();
                    retour = serviceError.GenerateErrors(ex.Message);
                }
            }
            else
            {
                //3-
                ServiceErrorGenerator<HRRegion> serviceError = new ServiceErrorGenerator<HRRegion>();
                retour = serviceError.GenerateErrors(HRCountriesServicesSolution.Constant.REGION.REGION_SERVICE_ERROR_DESCRIPTION);
            }
            return retour;
        }

        //!ToDo improve : Pass minValue(1) and MaxValue(6) as parameter. The controller must not know these contraints
        /// <summary>
        /// Get HRRegion by Id
        /// 1- If regionService is available, return the resulting REgion or all regions if Id do not correspond with any existing ID
        /// 2- If regionService  throw an Error, return a HRRegion Filled with an ErrorDescription of the Exception.
        /// 3- Else if _regionService is unavailable return a HRRegion Fill an ErrorDescription
        /// </summary>
        /// <param name="id">a int value between 1 and 6</param>
        /// <returns>HRRegion</returns>
        [Route("api/HRRegions/{id:int:min(1):max(6)}")]
        [HttpGet]
        public async Task<HRRegion> Get(int id)
        {
            if (_regionsService != null)
            {
                //1-
                try
                {
                    return await _regionsService.GetRegionAsync(id);
                }
                catch(Exception ex)
                {
                    //2-
                    ServiceErrorGenerator<HRRegion> serviceError = new ServiceErrorGenerator<HRRegion>();
                    return serviceError.GenerateError(ex.Message);
                }
            }
            else
            {
                //3-
                ServiceErrorGenerator<HRRegion> serviceError = new ServiceErrorGenerator<HRRegion>();
                return serviceError.GenerateError(HRCountriesServicesSolution.Constant.REGION.REGION_SERVICE_ERROR_DESCRIPTION);
            }
        }
    }
}
