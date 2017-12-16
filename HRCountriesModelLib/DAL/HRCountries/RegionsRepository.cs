using HRCountriesServicesSolution.Models;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class RegionsRepository : IRegionsRepository
    {
        private List<HRRegion> _regions = new List<HRRegion>();
        /// <summary>
        /// 
        /// </summary>
        public List<HRRegion> GetRegions()
        {
            if(_regions.Count == 0)
            {
                Reset();
                Initialize();
            }
            return _regions;
        }
        /// <summary>
        /// 
        /// </summary>
        public HRRegion GetRegion(int Id)
        {
            HRRegion retour = null;
            if (_regions.Count == 0)
            {
                Reset();
                Initialize();
            }
            int regionsCount = _regions.Count;
            for(int i = 0; i < regionsCount; i++)
            {
                if(_regions[i].id == Id)
                {
                    retour = _regions[i];
                    break;
                }
            }
            return retour;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _regions.Clear();
        }
        /// <summary>
        /// //!TODO
        /// On stub pour le moment en attendant de faire un distinct sur la liste des pays.
        /// </summary>
        public void Initialize()
        {
            HRRegion region = new HRRegion() { id = 1, region= "Africa" };
            _regions.Add(region);
            region = new HRRegion() { id = 2, region = "Americas" }; 
            _regions.Add(region);
            region = new HRRegion() { id = 3, region = "Asia" };
            _regions.Add(region);
            region = new HRRegion() { id = 4, region = "Europe" };
            _regions.Add(region);
            region = new HRRegion() { id = 5, region = "Oceania" };
            _regions.Add(region);
            region = new HRRegion() { id = 6, region = "Polar" };
            _regions.Add(region);
        }
    }
}