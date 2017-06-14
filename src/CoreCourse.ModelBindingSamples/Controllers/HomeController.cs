using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using CoreCourse.ModelBindingSamples.Models;

namespace CoreCourse.ModelBindingSamples.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ActionWithPrimitives(string firstName, string surName, string nickName, int legs, bool isCaptain, int? age)
        {
            var infoString = FormatSailorInfo(firstName, surName, nickName, legs, age, isCaptain, false);
            return Content(infoString);
        }

        public IActionResult ActionWithComplexType(Sailor sailor, bool isShipwrecked)
        {
            var infoString = FormatSailorInfo(sailor.FirstName, sailor.SurName, sailor.NickName, sailor.Legs, sailor.Age, sailor.IsCaptain, isShipwrecked);
            return Content(infoString);
        }

        public IActionResult ActionWithCollection(Sailor[] sailors)
        {
            var infoString = "";
            foreach(var sailor in sailors)
            {
                infoString += FormatSailorInfo(sailor.FirstName, sailor.SurName, sailor.NickName, sailor.Legs, sailor.Age, sailor.IsCaptain, false);
                infoString += Environment.NewLine;
            }
            return Content(infoString);
        }

        public IActionResult ActionWithQueryBindsOnly([FromQuery]string firstName, [FromQuery]string surName, [FromQuery]string nickName, [FromQuery]int legs, [FromQuery]bool isCaptain, [FromQuery]int? age)
        {
            var infoString = FormatSailorInfo(firstName, surName, nickName, legs, age, isCaptain, false);
            return Content(infoString);
        }


        public IActionResult ActionWithHeaderBinds(string firstName, [FromHeader]string surName)
        {
            var infoString = FormatSailorInfo(firstName, surName, null, 2, null, false, false);
            return Content(infoString);
        }

        public IActionResult ActionWithJsonBody([FromBody] Sailor sailor)
        {
            var infoString = FormatSailorInfo(sailor.FirstName, sailor.SurName, sailor.NickName, sailor.Legs, sailor.Age, sailor.IsCaptain, false);
            return Content(infoString);
        }

        private string FormatSailorInfo(string firstName, string surName, string nickName, int legs, int? age, bool isCaptain, bool isShipwrecked)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("     SAILOR     ");
            sb.AppendLine("================");
            sb.AppendLine($"First Name:  {firstName}");
            sb.AppendLine($"Surname:     {surName}");
            sb.AppendLine($"Nickname:    {nickName}");
            sb.AppendLine($"# legs:      {legs}");
            sb.AppendLine($"Age:         {age}");
            sb.AppendLine($"Is Captain?  {isCaptain}");
            sb.AppendLine($"Shipwrecked? {isShipwrecked}");
            return sb.ToString();
        }
    }
}