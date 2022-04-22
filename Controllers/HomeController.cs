using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySQLFun.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Controllers
{
    public class HomeController : Controller
    {
        private IBowlerRepository _repo { get; set; }

        public HomeController(IBowlerRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int teamId)
        {
            ViewBag.Teams = _repo.Teams.OrderBy(x => x.TeamName).ToList();
            ViewBag.TeamsTest = _repo.Teams.OrderBy(x => x.TeamName);


            var bowlers = _repo.Bowlers
                .Where(x=> x.TeamID == teamId || teamId == 0)
                .ToList();


            return View(bowlers);
        }

        public IActionResult Teams(int bowlerid)
        {
            var blue = _repo.Teams.ToList();


            return View("TeamsView",blue);
        }






        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            var entry = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            ViewBag.Teams = _repo.Teams.ToList();

            return View("Edit", entry);

        }

        [HttpPost]
        public IActionResult Edit(Bowler bwl)
        {
            _repo.EditResponse(bwl);


            return RedirectToAction("Index");

        }

        public IActionResult Add()
        {
            Bowler bwlr = new Bowler();

            ViewBag.Bowlers = _repo.Bowlers.ToList();
            ViewBag.Teams = _repo.Teams.ToList();
            return View("Edit", bwlr);
        }

        [HttpPost]
        public IActionResult Add(Bowler bwl)
        {

            if (ModelState.IsValid)
            {
                _repo.AddResponse(bwl);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Bowlers = _repo.Bowlers.ToList();
                ViewBag.Teams = _repo.Teams.ToList();

                return View("Edit");
            }
        }

        public IActionResult Delete(Bowler bwl)
        {
            _repo.DeleteResponse(bwl);

            return RedirectToAction("Index");
        }
    }
}
