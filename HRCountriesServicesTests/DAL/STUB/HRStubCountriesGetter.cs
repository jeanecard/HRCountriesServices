using HRCountriesServicesSolution.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesTests.DAL
{
    class HRStubCountriesGetter : ITextContentGetter
    {
        public string Parameter
        {
            get
            {
                return String.Empty;
            }

            set
            {
                //Dummy
            }
        }

        public async Task<string> GetBoundariesData()
        {
            String path = Directory.GetCurrentDirectory();
            String filePath = path + @"/../../App_Data/Boundaries.json";
            using (var reader = File.OpenText(filePath))
            {
                var result = await reader.ReadToEndAsync();
                return result;
            }
        }

        public async Task<string> GetCountriesData()
        {
            String path = Directory.GetCurrentDirectory();
            String filePath = path + @"/../../App_Data/allCountries.json";
            using (var reader = File.OpenText(filePath))
            {
                var result = await reader.ReadToEndAsync();
                return result;
            }
        }
    }
}
