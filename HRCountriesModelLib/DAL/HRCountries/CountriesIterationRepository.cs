using System;
using System.Collections.Generic;
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class CountriesIterationRepository : ICountriesIterationRepository
    {
        leGrosStub _grosStub = new leGrosStub();
        /// <summary>
        /// 
        /// </summary>
        public CountriesIterationRepository()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CountriesIteration GetCountrieIteration(String Id)
        {
            return _grosStub.GetCountrieIteration(Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CountriesIteration> GetCountriesIteration()
        {
            return _grosStub.GetCountriesIteration();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public CountriesIteration GetCountriesIterationByRegion(string Id)
        {
            return _grosStub.GetCountriesIterationByRegion(Id);
        }
    }
}