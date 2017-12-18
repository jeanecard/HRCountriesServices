using HRCountriesServicesSolution.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeoJSON.Net.Feature;
using Newtonsoft.Json;
using System.IO;
using HRCountriesServicesSolution.Models;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// A buffer class to contain data loaded from a local json file.
    /// Used to avoid database access on an azure env.
    /// </summary>
    public class BufferisedHRCountryBorderRepository : IHRCountryBorderRepository
    {
        private Object _locker = new Object();
        private static List<HRCountryBorder> _countriesBorderBuffer = null;
        private ITextContentGetter _contentGetter = null;

        /// <summary>
        /// Constructor for dependancy injection
        /// </summary>
        /// <param name="contentGetter"></param>
        public BufferisedHRCountryBorderRepository(ITextContentGetter contentGetter)
        {
            _contentGetter = contentGetter;
        }
        /// <summary>
        /// 1- If Buffer is null
        /// 1.1- Asynchronous Load of jsonData file
        /// 1.2- ForEach Feature retrieved, add a new HRCountryBorder with ISO3/alpha3Code and Features/OgcFeature
        /// 2- Else retrun true
        /// Does not catch any Exception and throw one if data can not be reached.
        /// </summary>
        /// <returns>true or throw an exception if data can not be loaded</returns>
        private async Task<bool> InitAsync()
        {
            //1-
            if (_countriesBorderBuffer == null)
            {
                //1.1-
                if (_contentGetter != null)
                {
                    FeatureCollection featureCollectionToCache = JsonConvert.DeserializeObject<FeatureCollection>(await _contentGetter.GetBoundariesData());
                    if (featureCollectionToCache != null)
                    {
                        lock (_locker)
                        {
                            _countriesBorderBuffer = new List<HRCountryBorder>();
                            int featuresCount = featureCollectionToCache.Features.Count;
                            //1.2-
                            for (int i = 0; i < featuresCount; i++)
                            {
                                HRCountryBorder border = new HRCountryBorder();
                                Feature featurei = featureCollectionToCache.Features[i];
                                if (featurei.Properties != null 
                                    && featurei.Properties.Keys.Contains(Constant.BOUNDARIES_STUB.ISO3_PROPERTIE_NAME))
                                {
                                    border.alpha3Code = featurei.Properties[Constant.BOUNDARIES_STUB.ISO3_PROPERTIE_NAME].ToString();
                                    FeatureCollection fCollection = new FeatureCollection();
                                    fCollection.Features.Add(featurei);
                                    border.oGCFeature = JsonConvert.SerializeObject(fCollection);
                                    _countriesBorderBuffer.Add(border);
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(Constant.BOUNDARIES_STUB.NO_DATA_ERROR_MESSAGE);
                    }
                }
                else
                {
                    throw new Exception(Constant.BOUNDARIES_STUB.NO_DATA_ERROR_MESSAGE);
                }
            }
            return true;
        }

        /// <summary>
        /// 1- Init buffer
        /// 2- Return initialized buffer if not null else throw Exception.
        /// Does not catch any Exception
        /// </summary>
        /// <returns>All HRBorderCountry available</returns>
        public async Task<IEnumerable<HRCountryBorder>> GetBorderCountriesAsync()
        {
            //1-
            await InitAsync();
            //2-
            if (_countriesBorderBuffer != null)
            {
                return _countriesBorderBuffer;
            }
            else
            {
                throw new Exception(HRCountriesServicesSolution.Constant.BOUNDARIES_STUB.NO_DATA_ERROR_MESSAGE);
            }
        }

        /// <summary>
        /// Get a HRBorderCountry from its alpha3Code.
        /// 1- Init Buffer
        /// 2- Iterate in buffer to get the alpha3Code
        /// Does not catch any Exception and throw one if _countriesBorderBuffer is null.
        /// </summary>
        /// <param name="alpha3Code">Country alpha3Code</param>
        /// <returns>The HRCounrtyBorder if exists or null.</returns>
        public async Task<HRCountryBorder> GetBorderCountriesByAlpha3CodeAsync(string alpha3Code)
        {
            //1-
            await InitAsync();
            if (_countriesBorderBuffer != null)
            {
                //2-
                int countriesBorderCount = _countriesBorderBuffer.Count;
                for (int i = 0; i < countriesBorderCount; i++)
                {
                    if (_countriesBorderBuffer[i].alpha3Code == alpha3Code)
                    {
                        return _countriesBorderBuffer[i];
                    }
                }
            }
            else
            {
                throw new Exception(HRCountriesServicesSolution.Constant.BOUNDARIES_STUB.NO_DATA_ERROR_MESSAGE);
            }
            return null;
        }
    }
}