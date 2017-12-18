using RestSharp;
using System;
using System.Web.Http.Description;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// GeonameRestRequestGenerator Interface
    /// </summary>
    public interface  IGeonameRestRequestGenerator
    {
        /// <summary>
        /// Get the RestRequest to query GeoName Service
        /// </summary>
        /// <param name="placenameToLookup">placeName to lookup</param>
        /// <param name="countryToLookup">Country to lookup</param>
        /// <param name="userNameToUse">User name to use to query GeoName Service.</param>
        /// <returns>The expected RestRequest</returns>
        RestRequest Generate(String placenameToLookup, String countryToLookup, String userNameToUse);
    }
}
