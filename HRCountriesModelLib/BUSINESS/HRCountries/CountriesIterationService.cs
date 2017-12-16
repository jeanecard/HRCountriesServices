
using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class CountriesIterationService : ICountriesIterationService
    {
        private ICountriesIterationRepository _repo = null;
        /// <summary>
        /// 
        /// </summary>
        public CountriesIterationService()
        {
            _repo = new CountriesIterationRepository();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CountriesIteration GetCountrieIteration(String Id)
        {
            return _repo.GetCountrieIteration(Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CountriesIteration> GetCountriesIteration()
        {
            return _repo.GetCountriesIteration();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CountriesIteration GetCountriesIterationByRegion(string Id)
        {
            return _repo.GetCountriesIterationByRegion(Id);
        }
    }
}