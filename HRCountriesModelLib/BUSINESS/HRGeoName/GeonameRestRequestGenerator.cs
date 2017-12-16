using RestSharp;
using System;
using System.Web.Http.Description;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class GeonameRestRequestGenerator : IGeonameRestRequestGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="placenameToLookup"></param>
        /// <param name="countryToLookup"></param>
        /// <param name="userNameToUse"></param>
        /// <returns></returns>
        public RestRequest Generate(String placenameToLookup, String countryToLookup, String userNameToUse)
        {
            //http://api.geonames.org/searchJSON?q=london&maxRows=10&username=jean.ecard
            var retour = new RestRequest(Method.GET);
            if (placenameToLookup == null)
                placenameToLookup = String.Empty;
            retour.AddParameter("q", placenameToLookup); 
            if(!String.IsNullOrEmpty(userNameToUse))
                retour.AddParameter("username", userNameToUse); 
            if(!String.IsNullOrEmpty(countryToLookup))
                retour.AddParameter("country", countryToLookup);

            return retour;
        }
    }
}
