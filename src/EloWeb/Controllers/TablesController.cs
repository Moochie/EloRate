﻿using System.Linq;
using System.Web.Mvc;
using EloWeb.Models;

namespace EloWeb.Controllers
{
    public class TablesController : Controller
    {
        // GET: Tables
        public ActionResult Rating()
        {
            var table = Players.Active().OrderByDescending(p => p.Rating);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult MaxRating()
        {
            var table = Players.All().OrderByDescending(p => p.Rating.MaxRating);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult WinRate()
        {
            var table = Players.All().OrderByDescending(p => p.WinRate);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult WinningStreak()
        {
            var table = Players.Active().OrderByDescending(p => p.CurrentWinningStreak);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult BestEverWinningStreak()
        {
            var table = Players.All().OrderByDescending(p => p.LongestWinningStreak);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult LosingStreak()
        {
            var table = Players.Active().OrderByDescending(p => p.CurrentLosingStreak);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult WorstEverLosingStreak()
        {
            var table = Players.All().OrderByDescending(p => p.LongestLosingStreak);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }
    }
}