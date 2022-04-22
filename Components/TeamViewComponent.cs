using Microsoft.AspNetCore.Mvc;
using MySQLFun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Components
{
    public class TeamViewComponent : ViewComponent 
    {

        private IBowlerRepository repo { get; set; }

        public TeamViewComponent(IBowlerRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
           
            ViewBag.SelectedTeam = Convert.ToInt32(RouteData?.Values["teamid"]);

            var teamid = repo.Bowlers
                .Select(x => x.TeamID)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            return View(teamid);
        }
    }
}
