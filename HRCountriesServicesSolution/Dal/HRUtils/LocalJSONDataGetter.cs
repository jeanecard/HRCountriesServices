using HRCountriesServicesSolution.Constant;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class LocalJSONDataGetter : ITextContentGetter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetCountriesData()
        {
            string path = HttpContext.Current.Server.MapPath(HRCountriesServicesSolution.Constant.COUNTRIESITERATION_STUB.COUNTRIES_JSON_URL);
            using (var reader = File.OpenText(path))
            {
                var result = await reader.ReadToEndAsync();
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async  Task<string> GetBoundariesData()
        {
            string path = HttpContext.Current.Server.MapPath(HRCountriesServicesSolution.Constant.COUNTRIESITERATION_STUB.BOUNDARIES_JSON_URL);
            using (var reader = File.OpenText(path))
            {
                var result = await reader.ReadToEndAsync();
                return result;
            }

        }
    }
}