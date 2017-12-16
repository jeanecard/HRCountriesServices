using HRCountriesServicesSolution.Models;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.Business
{
    interface IHRRegionsService
    {
        IEnumerable<HRRegion> GetRegions();
        HRRegion GetRegion(int Id);
    }
}
