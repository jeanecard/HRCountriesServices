using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeoJSON.Net.Feature;
using Newtonsoft.Json;
using System.IO;
using HRCountriesServicesSolution.Models;
using log4net;
using System.Reflection;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class HRCountryBorderRepository : IHRCountryBorderRepository
    {

        private static readonly ILog _log = LogManager.GetLogger(typeof(HRCountryBorderRepository));
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HRCountryBorder> GetBorderCountries()
        {
            List<HRCountryBorder> retour = new List<HRCountryBorder>();
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Boundaries.json");
            try
            {
                FeatureCollection featureCollectionToCache = JsonConvert.DeserializeObject<FeatureCollection>(File.ReadAllText(path));
                if (featureCollectionToCache != null)
                {
                    int featuresCount = featureCollectionToCache.Features.Count;
                    for (int i = 0; i < featuresCount; i++)
                    {
                        HRCountryBorder border = new HRCountryBorder();
                        //!Pas en dur.
                        if (featureCollectionToCache.Features[i].Properties != null && featureCollectionToCache.Features[i].Properties.Keys.Contains("ISO3"))
                        {
                            border.alpha3Code = featureCollectionToCache.Features[i].Properties["ISO3"].ToString();
                            FeatureCollection fCollection = new FeatureCollection();
                            fCollection.Features.Add(featureCollectionToCache.Features[i]);
                            border.oGCFeature = JsonConvert.SerializeObject(fCollection);
                            retour.Add(border);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex, System.Reflection.MethodBase.GetCurrentMethod());
            }
            return retour;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha3Code"></param>
        /// <returns></returns>
        public HRCountryBorder GetBorderCountriesByAlpha3Code(string alpha3Code)
        {
            HRCountryBorder countryBorder = new HRCountryBorder();
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Boundaries.json");
            try
            {
                FeatureCollection featureCollectionToCache = JsonConvert.DeserializeObject<FeatureCollection>(File.ReadAllText(path));
                if (featureCollectionToCache != null)
                {
                    int featuresCount = featureCollectionToCache.Features.Count;
                    for (int i = 0; i < featuresCount; i++)
                    {
                        //!Pas en dur.
                        if (featureCollectionToCache.Features[i].Properties != null && featureCollectionToCache.Features[i].Properties.Keys.Contains("ISO3"))
                        {
                            if (featureCollectionToCache.Features[i].Properties["ISO3"].ToString().ToLower() == alpha3Code.ToLower())
                            {
                                countryBorder.alpha3Code = alpha3Code;
                                FeatureCollection fCollection = new FeatureCollection();
                                fCollection.Features.Add(featureCollectionToCache.Features[i]);
                                countryBorder.oGCFeature = JsonConvert.SerializeObject(fCollection);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex, System.Reflection.MethodBase.GetCurrentMethod());
            }
            return countryBorder;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="methodBase"></param>
        private void LogException(Exception ex, MethodBase methodBase)
        {
            if (_log != null && ex != null && methodBase != null)
            {
                _log.DebugFormat("Application raise exception in {0}", methodBase);
                _log.Debug(ex.Message);
            }
        }
    }
}