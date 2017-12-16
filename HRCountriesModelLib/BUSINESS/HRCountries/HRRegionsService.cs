using System.Collections.Generic;
using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class HRRegionsService : IHRRegionsService

    {
        //!A injecter par constructeur.
        private IRegionsRepository _repo = null;
        /// <summary>
        /// 
        /// </summary>
        public HRRegionsService()
        {
            _repo = new RegionsRepository();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HRRegion> GetRegions()
        {
            IEnumerable<HRRegion> retour = _repo.GetRegions(); 
             return retour;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HRRegion GetRegion(int Id)
        {
            return _repo.GetRegion(Id);
        }

    }
}