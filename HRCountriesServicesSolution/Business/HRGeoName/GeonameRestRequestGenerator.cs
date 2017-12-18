using RestSharp;
using System;
using System.Web.Http.Description;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GeonameRestRequestGenerator : IGeonameRestRequestGenerator
    {
        /// <summary>
        /// Get the RestRequest to query GeoName Service
        /// No unit test as implementation is trivial
        /// </summary>
        /// <param name="placenameToLookup">placeName to lookup</param>
        /// <param name="countryToLookup">Country to lookup</param>
        /// <param name="userNameToUse">User name to use to query GeoName Service.</param>
        /// <returns>The expected RestRequest</returns>
        public RestRequest Generate(String placenameToLookup, String countryToLookup, String userNameToUse)
        {
            //Sample : http://api.geonames.org/searchJSON?q=london&maxRows=10&username=jean.ecard
            var retour = new RestRequest(Method.GET);
            if (placenameToLookup == null)
                placenameToLookup = String.Empty;
            retour.AddParameter(HRCountriesServicesSolution.Constant.GEONAME.PLACENAME_PARAMETER, placenameToLookup); 
            if(!String.IsNullOrEmpty(userNameToUse))
                retour.AddParameter(HRCountriesServicesSolution.Constant.GEONAME.USERNAME_PARAMETER, userNameToUse); 
            if(!String.IsNullOrEmpty(countryToLookup))
                retour.AddParameter(HRCountriesServicesSolution.Constant.GEONAME.COUNTRY_PARAMETER, countryToLookup);

            return retour;
        }
    }
}
