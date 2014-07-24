﻿using System.Linq;
using System.Web.Mvc;
using EloWeb.Models;
using EloWeb.Persist;
using EloWeb.ViewModels;

namespace EloWeb.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Index()
        {
            var leaderboard = Players.All().OrderByDescending(p => p.Rating);
            if (!leaderboard.Any())
                return Redirect("/Players/NewLeague");

            var players = Players.All();
            ViewData.Model = players.OrderBy(p => p.Name);
            return View();
        }

        // GET: Players/Details?name=......
        public ActionResult Details(string name)
        {
            ViewData.Model = Players.PlayerByName(name);
            return View();
        }

        // GET: Players/Records
        public ActionResult Records()
        {
            var leaderboard = Players.All().OrderByDescending(p => p.Rating);
            if (!leaderboard.Any())
                return Redirect("/Players/NewLeague");

            var recordsView = new Records
            {
                CurrentTopRanked = Record.GetRecordHolders(p => p.Rating),
                MostRatingsPointsEver = Record.GetRecordHolders(p => p.MaxRating),
                BestWinRate = Record.GetRecordHolders(p => p.WinRate),
                LongestWinningStreak = Record.GetRecordHolders(p => p.LongestWinningStreak),
                CurrentWinningStreak = Record.GetRecordHolders(p => p.CurrentWinningStreak),
                MostGamesPlayed = Record.GetRecordHolders(p => p.GamesPlayed),
            };

            ViewData.Model = recordsView;
            return View();
        }

        public ActionResult NewLeague()
        {
            return View();
        }

        // GET: Players/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Player player)
        {
            Players.Add(Players.CreateInitial(player.Name)); 
            PlayersData.PersistPlayer(player.Name);         
            return Redirect("/Players");
        }
    }
}