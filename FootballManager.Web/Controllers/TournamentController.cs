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
        private readonly IBaseService<Country> _countryService;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentService tournamentService, IBaseService<Country> countryService, IMapper mapper)
        {
            this._tournamentService = tournamentService;
            this._countryService = countryService;
            this._mapper = mapper;
        }

        // GET: Tournament
        public ActionResult Index()
        {
            var tournaments = _tournamentService.GetAll();
            var tournamentModels = _mapper.Map<IEnumerable<Tournament>, IEnumerable<TournamentViewModel>>(tournaments);
            return View(tournamentModels);
        }

        public ActionResult Create()
        {
            ViewBag.CountryList = new SelectList(_countryService.GetAll(), "CountryId", "CountryName");

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