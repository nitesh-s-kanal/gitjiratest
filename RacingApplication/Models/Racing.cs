using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RacingApplication.Models
{
    [Table("RaceDetails")]
    public class Racing
    {
        [Key]
        public int SeqId { get; set; }
        public int CityId { get; set; }
        public string Category { get; set; }
        public string Car { get; set; }
        public decimal TopSpeed { get; set; }
        public decimal CompletionTime { get; set; }
        public int TrackId { get; set; }
        public DateTime RaceDate { get; set; }
        public int DriverId { get; set; }

        public string Status { get; set; }
        public string Rank { get; set; }
        //public string CityName { get; set; }
        //public int DriverId { get; set; }
        //public string DriverName { get; set; }
        //public int DriverAge { get; set; }
        //public string DriverCountry { get; set; }
    }

    public class RacingSummary
    {

        public int SeqId { get; set; }
        public int CityId { get; set; }
        public string Category { get; set; }
        public string Car { get; set; }
        [DisplayName("Top Speed")]
        public decimal TopSpeed { get; set; }
        [DisplayName("Completion Time")]
        public decimal CompletionTime { get; set; }
        [DisplayName("Track Id")]
        public int TrackId { get; set; }
        [DisplayName("Race Date")]
        public DateTime RaceDate { get; set; }
        [DisplayName("Driver Id")]
        public int DriverId { get; set; }
        [DisplayName("Organized City")]
        public string CityName { get; set; }
        [DisplayName("Driver Name")]
        public string DriverName { get; set; }
        public int DriverAge { get; set; }
        [DisplayName("Driver Country")]
        public string DriverCountry { get; set; }
        public string Status { get; set; }
        public int Rank { get; set; }
        [DisplayName("Races Won")]
        public int RacesWon { get; set; }
        [DisplayName("Races Lost")]
        public int RacesLost { get; set; }
    }
    public class CompleteRacingSummary
    {
        public List<List<RacingSummary>> racingSummaryList { get; set; }
    }
}