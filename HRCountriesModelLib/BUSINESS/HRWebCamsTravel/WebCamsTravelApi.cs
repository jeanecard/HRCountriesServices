using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class WebCamsTravelApi : IWebCamsTravelApi
    {
        static String _connectWebcamsTravelsURL = @"https://webcamstravel.p.mashape.com/webcams/list/limit={limit},{offset}/orderby={orderby}/category={category}/country={country}/nearby={lat},{lon},250?show=webcams:location,image,player";
        static String _connectGeoNamesURL = @"http://api.geonames.org/searchJSON";
        static String _webcamsTravelLogin = @"jean.ecard@outlook.fr";
        static String _webcamsTravelPwd = @"Camben71";
        /// <summary>
        /// 
        /// </summary>
        public WebCamsTravelRootObject GetBestWebCam(string country, string capital)
        {
            WebCamsTravelRootObject retour = new WebCamsTravelRootObject();
            var geonameClient = new RestClient(_connectGeoNamesURL);
            //geonameClient.Authenticator = new HttpBasicAuthenticator(_webcamsTravelLogin, _webcamsTravelPwd);
            GeonameRestRequestGenerator geonameGenerator = new GeonameRestRequestGenerator();

            IRestResponse<HRGeoNameRootObject> geonameResponse = geonameClient.Execute<HRGeoNameRootObject>(geonameGenerator.Generate(capital, country, "jean.ecard"));
            GeonameRestResponseAnalyser analyser = new GeonameRestResponseAnalyser();//!Structure Map
            //!Tester null
            Geoname pCode = analyser.GetBestFittingPlaceName(capital, geonameResponse.Data.geonames);
            double parisLat = 0;
            double parisLon = 0;

            if (pCode != null)
            {
                Double.TryParse(pCode.lat.Replace('.', ','), out parisLat);
                Double.TryParse(pCode.lng.Replace('.', ','), out parisLon);
            }

            //WEBCAMSTRAVEL
            var webCamClient = new RestClient(_connectWebcamsTravelsURL);
            webCamClient.Authenticator = new HttpBasicAuthenticator(_webcamsTravelLogin, _webcamsTravelPwd);

            WebCamsTravelRestRequestGenerator webcamGenerator = new WebCamsTravelRestRequestGenerator();

            var webCamRequest = webcamGenerator.Generate(parisLat, parisLon, country);
            // execute the request
            IRestResponse<WebCamsTravelRootObject> webcamsTravelResponse = webCamClient.Execute<WebCamsTravelRootObject>(webCamRequest);
            if (webcamsTravelResponse != null && webcamsTravelResponse.Data != null && webcamsTravelResponse.Data.result != null)
            {
                WebCamsTravelRestResponseAnalyser webcamsTravelAnalyser = new WebCamsTravelRestResponseAnalyser();
                Webcam bestWebCam = webcamsTravelAnalyser.GetBestFittingWebCam(webcamsTravelResponse.Data.result.webcams);
                if (bestWebCam != null && bestWebCam.player != null)
                {
                    retour.status = "OK";
                    retour.result = new Result();
                    retour.result.limit = 0;
                    retour.result.offset = 0;
                    retour.result.total = 1;
                    retour.result.webcams = new List<Webcam>();
                    retour.result.webcams.Add(bestWebCam);
                }
                else
                {
                    retour.status = "OK";
                    retour.result = new Result();
                    retour.result.limit = 0;
                    retour.result.offset = 0;
                    retour.result.total = 0;
                }
            }
            return retour;
        }
    }
}