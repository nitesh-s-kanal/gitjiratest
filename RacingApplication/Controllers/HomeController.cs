using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RacingApplication.Models;
namespace RacingApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RacingContext raceContext = new RacingContext();

            //Retrive from DB
            List<RacingSummary> racingDetails = (from driver in raceContext.Driver
                                                 join racing in raceContext.Racing
                                                 on driver.DriverId equals racing.DriverId
                                                 join city in raceContext.City
                                                 on racing.CityId equals city.CityId
                                                 select new RacingSummary
                                                 {
                                                     DriverId = driver.DriverId,
                                                     DriverName = driver.DriverName,
                                                     DriverAge = driver.DriverAge,
                                                     DriverCountry = driver.DriverCountry,
                                                     Category = racing.Category,
                                                     Car = racing.Car,
                                                     TrackId = racing.TrackId,
                                                     CityName = city.CityName,
                                                     TopSpeed = racing.TopSpeed,
                                                     CompletionTime = racing.CompletionTime,
                                                     Status = racing.Status,
                                                     RaceDate = racing.RaceDate,
                                                     Rank = 0,
                                                     RacesLost = driver.RacesLost,
                                                     RacesWon = driver.RacesWon
                                                 }).ToList();

            //Ranking based on completion time
            var rank = (racingDetails.GroupBy(d => new { d.CityName, d.RaceDate })
               .SelectMany(g => g.OrderBy(y => y.CompletionTime)
                                 .Select((x, i) => new { g.Key, Item = x, Rank = i + 1 })));


            var RankedRace = rank.ToList();

            //Update Status, Won and Lose 
            for (int i = 0; i < RankedRace.Count; i++)
            {
                if (RankedRace[i].Rank == 1)
                {
                    RankedRace[i].Item.Status = "Win";
                    RankedRace[i].Item.Rank = RankedRace[i].Rank;
                    RankedRace[i].Item.RacesWon = (RankedRace[i].Item.RacesWon) + 1;
                    RankedRace[i].Item.RacesLost = (RankedRace[i].Item.RacesLost);
                }
                else
                {
                    RankedRace[i].Item.Status = "Lost";
                    RankedRace[i].Item.Rank = RankedRace[i].Rank;
                    RankedRace[i].Item.RacesLost = (RankedRace[i].Item.RacesLost) + 1;
                    RankedRace[i].Item.RacesWon = (RankedRace[i].Item.RacesWon);
                }
            }



            var WinLostSummary = racingDetails.GroupBy(d => d.DriverId)
                                  .SelectMany(g => g.OrderBy(y => y.DriverId)
                                 .Select((x, i) => new { g.Key, Item = x, Rank = i + 1 })).ToList();
            //Update in DB
            for (int i = 0; i < WinLostSummary.Count; i++)
            {
                int id = WinLostSummary[i].Item.DriverId;
                var DriverData = raceContext.Driver.Where(x => x.DriverId == id).FirstOrDefault();
                if (DriverData != null)
                {
                    DriverData.RacesWon = WinLostSummary[i].Item.RacesWon;
                    DriverData.RacesLost = WinLostSummary[i].Item.RacesLost;
                    raceContext.SaveChanges();

                }
            }
           
            return View(racingDetails);
        }

        public ActionResult DriverSummary()
        {
            ViewBag.Message = "Driver Summary";
            RacingContext raceContext = new RacingContext();
            List<RacingSummary> DriverDetails = (from driver in raceContext.Driver
                                                 select new RacingSummary
                                                 {
                                                     DriverId = driver.DriverId,
                                                     DriverName = driver.DriverName,
                                                     DriverAge = driver.DriverAge,
                                                     DriverCountry = driver.DriverCountry,
                                                     RacesLost = driver.RacesLost,
                                                     RacesWon = driver.RacesWon,
                                                 }).ToList();

            return View(DriverDetails);
        }

        
    }
}