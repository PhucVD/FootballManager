﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballManager.Domain;
using FootballManager.Service;

namespace FootballManager.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IBaseService<Player> _playerService;
        private readonly IBaseService<Nation> _nationService;
        private readonly ITeamService _teamService;

        public PlayerController(IBaseService<Player> playerService, IBaseService<Nation> nationService, ITeamService teamService)
        {
            this._playerService = playerService;
            this._nationService = nationService;
            this._teamService = teamService;
        }

        public ActionResult Index()
        {
            return View(_playerService.GetAll());
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
            ViewBag.NationList = new SelectList(_nationService.GetAll(), "NationId", "NationName");
            ViewBag.TeamList = new SelectList(_teamService.GetClubsOnly(), "TeamId", "TeamName");
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