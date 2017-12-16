using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class WebCamsTravelRestResponseAnalyser : IWebCamsTravelRestResponseAnalyser
    {
        /// <summary>
        /// 
        /// </summary>
        public Webcam GetBestFittingWebCam(List<Webcam> webcams)
        {
            Webcam retour = null;
            if(webcams != null)
            {
                foreach(Webcam iterator in webcams)
                {
                    if(iterator.status == "active" && iterator.player != null)
                    {
                        //Le plus jolie c'est Lifetime donc on le cherche
                        if (iterator.player.lifetime != null && iterator.player.lifetime.available && !String.IsNullOrEmpty(iterator.player.lifetime.embed))
                        {
                            retour = iterator;
                            break;
                        } 
                    }
                }
            }
            return retour;
        }
    }
}
