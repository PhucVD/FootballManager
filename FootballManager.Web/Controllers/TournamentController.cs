﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FootballManager.Domain;
using FootballManager.Service;
using FootballManager.Web.Common;
using FootballManager.Web.Models;
using FootballManager.Service.Interfaces;
using FootballManager.Web.Extensions;

namespace FootballManager.Web.Controllers
{
    public class TournamentController : BaseController
    {
        private readonly ITournamentService _tournamentService;
        private readonly ICountryService _countryService;

        public TournamentController(ITournamentService tournamentService, ICountryService countryService, IMapper mapper): base(mapper)
        {
            this._tournamentService = tournamentService;
            this._countryService = countryService;
        }

        // GET: Tournament
        public ActionResult Index()
        {
            var tournamentModels = GetTournamentList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_TournamentList", tournamentModels);
            }

            return View(tournamentModels);
        }

        public ActionResult Create()
        {
            ViewBag.CountryList = new SelectList(_countryService.GetList(), "CountryId", "CountryName");
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

                return PartialView("_TournamentList", GetTournamentList());
            }

            return Json(new JsonInfo(JsonStatus.Failed), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(XeditableOptions editOptions)
        {
            if (editOptions == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Bad Request");
            }
            int status = _tournamentService.UpdateInfo(editOptions.Pk, editOptions.Name, editOptions.Value);
            return Json(new JsonInfo(status), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Bad Request");
            }
            _tournamentService.DeleteById(id.Value);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_TournamentList", GetTournamentList());
            }
            return Json(new JsonInfo(JsonStatus.Success), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<TournamentViewModel> GetTournamentList()
        {
            var tournaments = _tournamentService.GetList(x => true);
            var tournamentModels = _mapper.Map<IEnumerable<Tournament>, IEnumerable<TournamentViewModel>>(tournaments);
            return tournamentModels;
        } 
    }
}