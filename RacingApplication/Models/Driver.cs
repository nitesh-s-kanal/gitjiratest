using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RacingApplication.Models
{
    [Table("Driver")]
    public class Driver
    {

        [DisplayName("Driver Id")]
        public int DriverId { get; set; }
        [DisplayName("Driver Name")]
        public string DriverName { get; set; }
        [DisplayName("Driver Age")]
        public int DriverAge { get; set; }
        [DisplayName("Driver Country")]
        public string DriverCountry { get; set; }
        [DisplayName("Races Won")]
        public int RacesWon { get; set; }
        [DisplayName("Races Lost")]
        public int RacesLost { get; set; }

    }
}