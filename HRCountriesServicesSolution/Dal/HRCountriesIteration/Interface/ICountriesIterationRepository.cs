using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICountriesIterationRepository
    {
        //Task<IEnumerable<CountriesIteration>> GetCountriesIterationAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<CountriesIteration> GetCountrieIterationAsync(String Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<CountriesIteration> GetCountriesIterationByRegionAsync(string Id);
    }
}
