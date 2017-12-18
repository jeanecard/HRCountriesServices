using HRCountriesServicesSolution.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesTests.BUSINESS.Tests
{
    class HRWebCamsTravelRestClientStub : IHRWebCamsTravelRestClient
    {
        double _lat = 0;
        public double Lat
        {
            get
            {
                return _lat;
            }

            set
            {
                _lat = value;
            }
        }
        double _lon = 0;
        public double Lon
        {
            get
            {
                return _lon;
            }

            set
            {
                _lon = value;
            }
        }

        public async Task<WebCamsTravelRootObject> ExecuteBestWebCam()
        {
            //Fake await.
            await Task.Delay(10);
            WebCamsTravelRootObject retour = null;
            if(_lat == 10.0 && _lon == 10.0)
            {
                retour = new WebCamsTravelRootObject();
                retour.status = "OK";
                retour.result = new Result();
                retour.result.webcams = new List<Webcam>();
                Webcam webCam = new Webcam();
                webCam.player = new Player();
                webCam.player.lifetime = new Lifetime();
                webCam.player.lifetime.available = true;
                webCam.player.lifetime.embed = "Embeded";
                retour.result.webcams.Add(webCam);
            }
            return retour;
        }
    }
}
