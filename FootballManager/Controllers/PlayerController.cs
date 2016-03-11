using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballManager.Domain;
using FootballManager.Service;

namespace FootballManager.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IBaseService<Player> _service;
        private readonly IBaseService<Nation> _nationService;
        private readonly ITeamService _teamService;

        public PlayerController(IBaseService<Player> service, IBaseService<Nation> nationService, ITeamService teamService)
        {
            _service = service;
            _teamService = teamService;
            _nationService = nationService;
        }

        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _service.GetById(id.Value);
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
                _service.Insert(player);
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
            Player player = _service.GetById(id.Value);
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
                _service.Update(player);
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
            Player player = _service.GetById(id.Value);
            if (player != null)
            {
                _service.DeleteById(id.Value);
            }
            return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
