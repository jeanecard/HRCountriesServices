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
        /// <returns></returns>
        public RestRequest Generate(double lat, double lon)
        {
            RestRequest retour = new RestRequest(Method.GET);

            //retour.AddUrlSegment(HRCountriesServicesSolution.Constant.WEBCAMTRAVEL.LIMIT_KEY, "5");
            //retour.AddUrlSegment(HRCountriesServicesSolution.Constant.WEBCAMTRAVEL.OFFSET_KEY, "0");
            retour.AddUrlSegment(HRCountriesServicesSolution.Constant.WEBCAMTRAVEL.LAT_KEY, lat.ToString().Replace(',', '.')); 
            retour.AddUrlSegment(HRCountriesServicesSolution.Constant.WEBCAMTRAVEL.LON_KEY, lon.ToString().Replace(',', '.')); 
            retour.AddHeader(HRCountriesServicesSolution.Constant.WEBCAMTRAVEL.X_MASHAPE_KEY, System.Configuration.ConfigurationManager.AppSettings[HRCountriesServicesSolution.Constant.WEBCAMTRAVEL.X_MASHAPE_KEY]);

            return retour;
        }
    }
}
