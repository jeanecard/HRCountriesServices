using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// Encapsulated RestClient form RestSharp for specific HRGeoNameRootObject
    /// </summary>
    public interface IHRGeonameRestClient
    {
        /// <summary>
        /// Get the corresponding request's Geonames.
        /// </summary>
        /// <returns></returns>
        Task<List<Geoname>> Execute();
        /// <summary>
        /// 
        /// </summary>
        String Capital { get; set; }
        /// <summary>
        /// 
        /// </summary>
        String Country { get; set; }
    }
}
