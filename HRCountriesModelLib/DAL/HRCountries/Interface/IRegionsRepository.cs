using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.DAL
{
    interface IRegionsRepository
    {
        List<HRRegion> GetRegions();
        HRRegion GetRegion(int Id);
        void Reset();
        void Initialize();

    }
}
