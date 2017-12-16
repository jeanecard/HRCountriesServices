using RestSharp;
using System;
using System.Web.Http.Description;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface  IGeonameRestRequestGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="placenameToLookup"></param>
        /// <param name="countryToLookup"></param>
        /// <param name="userNameToUse"></param>
        /// <returns></returns>
        RestRequest Generate(String placenameToLookup, String countryToLookup, String userNameToUse);
    }
}
