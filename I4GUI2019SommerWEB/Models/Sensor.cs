using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace I4GUI2019SommerWEB.Models
{
    public class Sensor
    {
        public double _latitude;
        public double _longitude; 

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression("[0-9]{6}")]
        public int SensorId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public string TreeSort { get; set; }

        [Required]
        public double Latitude {
            get { return Math.Round(_latitude, 2, MidpointRounding.AwayFromZero); }
            set { _latitude = value; }
        }
        
        [Required]
        public double Longitude
        {
            get { return Math.Round(_longitude, 2, MidpointRounding.AwayFromZero); }
            set { _longitude = value; }
        }
    }
}
