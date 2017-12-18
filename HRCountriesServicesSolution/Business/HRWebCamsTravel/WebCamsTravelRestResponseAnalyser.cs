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
        /// Get the Webcam available with lifetime and embeded on
        /// </summary>
        public List<Webcam> GetBestFittingWebCam(List<Webcam> webcams)
        {
            List<Webcam> retour = new List<Webcam>();
            if(webcams != null)
            {
                foreach(Webcam iterator in webcams)
                {
                    if(iterator.status == HRCountriesServicesSolution.Constant.WEBCAMTRAVEL.ACTIVE_STATUS && iterator.player != null)
                    {
                        if (iterator.player.lifetime != null /*&& iterator.player.lifetime.available*/ && !String.IsNullOrEmpty(iterator.player.lifetime.embed))
                        {
                            retour.Add(iterator);
                        } 
                    }
                }
            }
            return retour;
        }
    }
}
