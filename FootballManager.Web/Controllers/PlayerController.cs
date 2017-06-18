using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballManager.Domain;
using FootballManager.Service;
using FootballManager.Service.Interfaces;

namespace FootballManager.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ICountryService _countryService;
        private readonly ITeamService _teamService;

        public PlayerController(IPlayerService playerService, ICountryService countryService, ITeamService teamService)
        {
            this._playerService = playerService;
            this._countryService = countryService;
            this._teamService = teamService;
        }

        public ActionResult Index()
        {
            return View(_playerService.GetList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _playerService.GetById(id.Value);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        public ActionResult Create()
        {
            GetSelectList();
            return View();
        }

        private void GetSelectList()
        {
            ViewBag.CountryList = new SelectList(_countryService.GetList(), "CountryId", "Name");
            ViewBag.TeamList = new SelectList(_teamService.GetClubsOnly(), "TeamId", "Name");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _playerService.Insert(player);
                return RedirectToAction("Index");
            }

            return View(player);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _playerService.GetById(id.Value);
            if (player == null)
            {
                return HttpNotFound();
            }

            GetSelectList();
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                _playerService.Update(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _playerService.GetById(id.Value);
            if (player != null)
            {
                _playerService.DeleteById(id.Value);
            }
            return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _playerService.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
