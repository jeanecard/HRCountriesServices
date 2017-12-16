using System;
using System.ComponentModel.DataAnnotations;

namespace HRCountriesServicesSolution.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HRRegion
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String region { get; set; }
    }
}