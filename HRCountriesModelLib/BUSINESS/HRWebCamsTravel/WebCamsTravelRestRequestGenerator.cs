using System;
using RestSharp;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class WebCamsTravelRestRequestGenerator : IWebCamsTravelRestRequestGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public RestRequest Generate(double lat, double lon, string country)
        {
            RestRequest retour = new RestRequest(Method.GET);

            if (!String.IsNullOrEmpty(country))
            {
                retour.AddUrlSegment("country", country); 
            }
            retour.AddUrlSegment("category", "city");
            retour.AddUrlSegment("orderby", "popularity");
            retour.AddUrlSegment("limit", "5");
            retour.AddUrlSegment("offset", "0");
            retour.AddUrlSegment("lat", lat.ToString().Replace(',', '.')); //!Attention culture
            retour.AddUrlSegment("lon", lon.ToString().Replace(',', '.')); //!Attention culture

            retour.AddHeader("X-Mashape-Key", "WGWfdo3VCYmshOJ8rpb36B9xZNNlp1aE3i2jsnoh53YXtpyeKo");

            return retour;
        }
    }
}
