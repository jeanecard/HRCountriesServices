﻿using RestSharp;
using System;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWebCamsTravelRestRequestGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        RestRequest Generate(double lat, double lon, String country);
    }
}
