using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// Implementation of a local buffer of Regions.
    /// This class is used to enable a free deployment on Azure as accessing Azure DB is too expensive for only test reasons.
    /// This class is non unitary tested as it is a trivial implementation.
    /// </summary>
    public class BufferisedRegionsRepository : IRegionsRepository
    {
        private static List<HRRegion> _regions = null;
        private Object _locker = new Object();
        /// <summary>
        /// Faked async method on stubbeed data.
        /// </summary>
        public async Task<List<HRRegion>> GetRegionsAsync()
        {
            await InitAsync();
            return _regions;
        }
        /// <summary>
        /// Faked async method on stubbeed data.
        /// </summary>
        /// <param name="Id">Internal ID if a region</param>
        public async Task<HRRegion> GetRegionAsync(int Id)
        {
            await InitAsync();
            int regionsCount = _regions.Count;
            for(int i = 0; i < regionsCount; i++)
            {
                if(_regions[i].id == Id)
                {
                    return _regions[i];
                }
            }
            return null;
        }
         /// <summary>
        /// Stubbed Data for Azure deployment.
        /// </summary>
        private async Task<bool> InitAsync()
        {
            //Fake async
            await Task.Delay(10);
            lock (_locker)
            {
                if (_regions == null)
                {
                    _regions = new List<HRRegion>();
                    HRRegion region = new HRRegion() { id = 1, region = Constant.REGION_STUB.AFRICA_REGION };
                    _regions.Add(region);
                    region = new HRRegion() { id = 2, region = Constant.REGION_STUB.AMERICAS_REGION };
                    _regions.Add(region);
                    region = new HRRegion() { id = 3, region = Constant.REGION_STUB.ASIA_REGION };
                    _regions.Add(region);
                    region = new HRRegion() { id = 4, region = Constant.REGION_STUB.EUROPE_REGION };
                    _regions.Add(region);
                    region = new HRRegion() { id = 5, region = Constant.REGION_STUB.OCEANIA_REGION };
                    _regions.Add(region);
                    region = new HRRegion() { id = 6, region = Constant.REGION_STUB.POLAR_REGION };
                    _regions.Add(region);
                }
            }
            return true;
        }
    }
}