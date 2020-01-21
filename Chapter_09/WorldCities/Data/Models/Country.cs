using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorldCities.Data.Models
{
    public class Country
    {
        #region Constructor
        public Country()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// The unique id and primary key for this Country
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Country name (in UTF8 format)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Country code (in ISO 3166-1 ALPHA-2 format)
        /// </summary>
        [JsonPropertyName("iso2")]
        public string ISO2 { get; set; }

        /// <summary>
        /// Country code (in ISO 3166-1 ALPHA-3 format)
        /// </summary>
        [JsonPropertyName("iso3")]
        public string ISO3 { get; set; }
        #endregion

        #region Client-side properties
        /// <summary>
        /// The number of cities related to this country.
        /// </summary>
        [NotMapped]
        public int TotCities
        {
            get
            {
                return (Cities != null)
                    ? Cities.Count
                    : _TotCities;
            }
            set { _TotCities = value; }
        }

        private int _TotCities = 0;
        #endregion

        #region Navigation Properties
        /// <summary>
        /// A list containing all the cities related to this country.
        /// </summary>
        [JsonIgnore]
        public virtual List<City> Cities { get; set; }
        #endregion
    }
}
