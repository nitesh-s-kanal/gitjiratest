using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace RacingApplication.Models
{
    [Table("RacingCity")]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
      
    }
}