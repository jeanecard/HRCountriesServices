using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRegionsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<HRRegion>> GetRegionsAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<HRRegion> GetRegionAsync(int Id);
    }
}
