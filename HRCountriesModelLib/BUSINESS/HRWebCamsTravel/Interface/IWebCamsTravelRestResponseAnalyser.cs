using HRCountriesServicesSolution.Models;
using System.Collections.Generic;


namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWebCamsTravelRestResponseAnalyser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="webcams"></param>
        /// <returns></returns>
        Webcam GetBestFittingWebCam(List<Webcam> webcams);
    }
}
