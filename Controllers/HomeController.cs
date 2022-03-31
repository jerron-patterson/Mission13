using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlerRepository _repo { get; set; }
        public HomeController(IBowlerRepository temp)
        {
            //Constructor
            _repo = temp;
        }
        public IActionResult Index()
        {
            var ds = _repo.Bowlers.ToList();
            return View(ds);
        }
        public IActionResult Test()
        {
            var dt = _repo.Teams.ToList();
            return View(dt);
        }
        //ADD BOWLER
        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.Tea = _repo.Teams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddBowler(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _repo.AddBowler(bowler);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(bowler);
            }
        }
        //EDIT BOWLER
        public IActionResult EditBowler(int id)
        {
            ViewBag.Tea = _repo.Teams.ToList();
            var ent = _repo.Bowlers.Single(x => x.BowlerID == id);
            ViewBag.TeaID = ent.TeamID;
            return View(ent);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler bowler)
        {
            _repo.AddBowler(bowler);
            _repo.SaveChanges();
            return RedirectToAction("Index");
        }
        //DELETE BOWLER
        public IActionResult DeleteBowler(int id)
        {
            var con = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View(con);
        }

        [HttpPost]
        public IActionResult DeleteTask(Bowler bowler)
        {
            _repo.DeleteBowler(bowler);
            _repo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
