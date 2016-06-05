using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FootballManager.Domain;
using FootballManager.Service;
using FootballManager.Web.ViewModels;

namespace FootballManager.Web.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentService _tournamentService;
        private readonly IBaseService<Nation> _nationService;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentService tournamentService, IBaseService<Nation> nationService, IMapper mapper)
        {
            this._tournamentService = tournamentService;
            this._nationService = nationService;
            this._mapper = mapper;
        }

        // GET: Tournament
        public ActionResult Index()
        {
            List<TournamentViewModel> tournaments = new List<TournamentViewModel>();
            return View(tournaments);
        }

        public ActionResult Create()
        {
            var nationList = new SelectList(_nationService.GetAll(), "NationId", "NationName");
            ViewBag.NationList = nationList;

            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TournamentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tournament = _mapper.Map<TournamentViewModel, Tournament>(model);
                _tournamentService.Insert(tournament);
                _tournamentService.Save();

                return Json("Create successfully!", JsonRequestBehavior.AllowGet);

            }
            return Json("Failed", JsonRequestBehavior.AllowGet);
        }
    }
}