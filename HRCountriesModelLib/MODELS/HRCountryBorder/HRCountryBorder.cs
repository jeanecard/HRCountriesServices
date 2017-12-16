using System;
using System.ComponentModel.DataAnnotations;

namespace HRCountriesServicesSolution.Models
{
    /// <summary>
    /// Model for embedding OGCFeature with Alpha3Code
    /// </summary>
    public class HRCountryBorder
    {
        /// <summary>
        /// For details on ISO3166 Alpha3Code check : https://en.wikipedia.org/wiki/ISO_3166-1_alpha-3 for more details.
        /// </summary>
        [MaxLength(3)]
        [MinLength(3)]
        public string alpha3Code { get; set; }

        /// <summary>
        /// OpenGis Feature As Json String. check http://www.opengeospatial.org/standards/sfa for more details. 
        /// </summary>
        public String oGCFeature { get; set; }
    }
}