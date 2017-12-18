using System.Collections.Generic;
using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using System;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// HRRegion Service Implementation.
    /// No unit test as implementation is trivial
    /// </summary>
    public class HRRegionsService : IHRRegionsService
    {
        private IRegionsRepository _repo = null;
  
        /// <summary>
        /// Dependancy injection by constructor.
        /// </summary>
        public HRRegionsService(IRegionsRepository rep)
        {
            _repo = rep;
        }
        /// <summary>
        /// Get all Regions available.
        /// 1- If Repository is available return result
        /// 2- Else throw Exception.
        /// </summary>
        /// <returns>All regions avaialble</returns>
        public async Task<IEnumerable<HRRegion>> GetRegionsAsync()
        {
            if (_repo != null)
            {
                return await _repo.GetRegionsAsync();
            }
            else
            {
                //2-
                throw new Exception(HRCountriesServicesSolution.Constant.REGION.REGION_REPOSITORY_ERROR_DESCRIPTION);
            }
        }

        /// <summary>
        /// Get a HRRegion by Id
        /// 1- If Repository is available return result
        /// 2- Else throw Exception.
        /// </summary>
        /// <param name="Id">ID of Region</param>
        /// <returns>The corresponding Region if exists null otherwise</returns>
        public async Task<HRRegion> GetRegionAsync(int Id)
        {
            if (_repo != null)
            {
                //1-
                return await _repo.GetRegionAsync(Id);
            }
            else
            {
                //2-
                throw new Exception(HRCountriesServicesSolution.Constant.REGION.REGION_REPOSITORY_ERROR_DESCRIPTION);
            }
        }

    }
}