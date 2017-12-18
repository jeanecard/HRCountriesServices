using HRCountriesServicesSolution.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// HRRegion Service Interface
    /// </summary>
    public interface IHRRegionsService
    {
        /// <summary>
        /// Get all Regions available
        /// </summary>
        /// <returns>All regions avaialble</returns>
        Task<IEnumerable<HRRegion>> GetRegionsAsync();

        /// <summary>
        /// Get a HRRegion by Id
        /// </summary>
        /// <param name="Id">ID of region</param>
        /// <returns>The corresponding Region if exists null otherwise</returns>
        Task<HRRegion> GetRegionAsync(int Id);
    }
}
