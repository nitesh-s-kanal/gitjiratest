using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RacingApplication.Models
{
    [Table("TrackDetails")]
    public class Track
    {
        [Key]
        public int TrackNo { get; set; }
        public decimal TrackLength { get; set; }
        public int CityId { get; set; }

    }
}