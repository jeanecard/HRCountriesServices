using System;
using System.ComponentModel.DataAnnotations;

namespace HRCountriesServicesSolution.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PopulationModel
    {
        [Key]
        String population { get; set; }
    }
}