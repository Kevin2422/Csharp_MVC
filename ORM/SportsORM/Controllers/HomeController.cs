using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        // need static keyword
        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.Women = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();
             ViewBag.Hockey = _context.Leagues
                .Where(l => l.Name.Contains("Hockey"))
                .ToList();
            ViewBag.NotFootball = _context.Leagues
                .Where(l => !l.Name.Contains("Football"))
                .ToList();
            ViewBag.Conference = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            ViewBag.Atlantic = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.Dallas = _context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();
            ViewBag.Raptors = _context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.City = _context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();
            ViewBag.FirstT = _context.Teams.ToList()
                .Where(l => l.TeamName[0]== 'T')
                ;
            ViewBag.Alphabet = _context.Teams.ToList()
                .OrderBy(p => p.Location);

            ViewBag.RAlphabet = _context.Teams.ToList()
                .OrderByDescending(p => p.TeamName);
            ViewBag.Cooper = _context.Players.ToList()
                .Where(l => l.LastName == "Cooper");
            ViewBag.Joshua = _context.Players.ToList()
                .Where(l => l.FirstName == "Joshua");
             ViewBag.CNJ = _context.Players.ToList()
                .Where(l => l.FirstName != "Joshua")
                .Where(l => l.LastName == "Cooper")
                ;
             ViewBag.AOW = _context.Players.ToList()
                .Where(l => l.FirstName == "Alexander" || l.FirstName == "Wyatt");
                

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            List<Team> x = _context.Teams
            .Include(l => l.CurrLeague)
            .Where(x => x.CurrLeague.Name == "Atlantic Soccer Conference")
            .ToList()
            ;
            
            ViewBag.AtlanticSoccer = x;

            ViewBag.Penguins = _context.Players
            .Include(l => l.CurrentTeam)
            .Where(l => l.CurrentTeam.TeamName == "Penguins")
            .ToList();

            ViewBag.BasebalCol = _context.Players
            .Include(l => l.CurrentTeam)
            .Where(l => l.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference")
            .ToList();

            ViewBag.Lopez = _context.Players
            .Include(l => l.CurrentTeam)
            .Where(l => l.CurrentTeam.CurrLeague.Name == "American Conference of Amateur Football" && l.LastName == "Lopez")
            .ToList();

            ViewBag.FootballP = _context.Players
            .Include(l => l.CurrentTeam)
            .Where(l => l.CurrentTeam.CurrLeague.Sport == "Football")
            .ToList();

            ViewBag.Sophia = _context.Players
            .Include(l => l.CurrentTeam)
            .Where(l => l.FirstName == "Sophia")
            .ToList();
            
            ViewBag.Sophia1 = _context.Players
            .Include(l => l.CurrentTeam)
            .Include(l => l.CurrentTeam.CurrLeague)
            .Where(l => l.FirstName == "Sophia")
            .ToList();

        

            ViewBag.Flores = _context.Players
            .Include(l => l.CurrentTeam)
            .Include(l => l.CurrentTeam.CurrLeague)
            .Where(l => l.LastName == "Flores" && l.CurrentTeam.TeamName != "RoughRiders")
            .ToList();

            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            ViewBag.SamEv = _context.Players
            .Include(l => l.AllTeams)
                .ThenInclude(l => l.TeamOfPlayer)
            .FirstOrDefault(l => l.FirstName == "Samuel" && l.LastName == "Evans");

            ViewBag.TigerCats = _context.Teams
            .Include(l => l.AllPlayers)
                .ThenInclude(l => l.PlayerOnTeam)
                .ThenInclude(l => l.CurrentTeam)
            .FirstOrDefault(l => l.TeamName == "Tiger-Cats");
            

            ViewBag.Vikings = _context.Teams
            .Include(l => l.AllPlayers)
                .ThenInclude(l => l.PlayerOnTeam)
                .ThenInclude(l => l.CurrentTeam)
                
                
            .FirstOrDefault(l => l.TeamName == "Vikings");

            ViewBag.JGray = _context.Players
            .Include(l => l.AllTeams)
                .ThenInclude(l => l.TeamOfPlayer)

            .FirstOrDefault(l => l.FirstName == "Jacob" && l.LastName == "Gray");

            ViewBag.Joshua = _context.Players
            .Include(l => l.AllTeams)
            .ThenInclude(l => l.TeamOfPlayer)
            .ThenInclude(l => l.CurrLeague)
            .Where(l => l.FirstName == "Joshua")
            .Where(l => l.AllTeams.Any(i => i.TeamOfPlayer.CurrLeague.Name == "Atlantic Federation of Amateur Baseball Players" )
            || l.CurrentTeam.CurrLeague.Name =="Atlantic Federation of Amateur Baseball Players")
            .ToList();

            ViewBag.Twelve = _context.Teams
            .Include(l => l.AllPlayers)
            .Include(l => l.CurrentPlayers)
            .Where(l => l.AllPlayers.Count() + l.CurrentPlayers.Count() > 12)
            .ToList();

            ViewBag.NumTeams = _context.Players
            .Include(l => l.AllTeams)
            .OrderByDescending(l => l.AllTeams.Count())
            .ToList();
                
                
                
                




            return View();
        }

    }
}