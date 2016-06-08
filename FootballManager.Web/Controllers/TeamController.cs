using System.Linq;
using System.Net;
using System.Web.Mvc;
using FootballManager.Domain;
using FootballManager.Service;

namespace FootballManager.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IBaseService<Country> _countryService;

        public TeamController(ITeamService teamService, IBaseService<Country> countryService)
        {
            this._teamService = teamService;
            this._countryService = countryService;
        }

        // GET: Team
        public ActionResult Index()
        {
            return View(_teamService.GetAll());
        }

        // GET: Team/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = _teamService.GetById(id.Value);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            GetSelectList();
            return View();
        }

        private void GetSelectList()
        {
            ViewBag.CountryList = new SelectList(_countryService.GetAll(), "CountryId", "CountryName");
        }

        // POST: Team/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _teamService.Insert(team);
                return RedirectToAction("Index");
            }

            return View(team);
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = _teamService.GetById(id.Value);
            if (team == null)
            {
                return HttpNotFound();
            }
            GetSelectList();
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                _teamService.Update(team);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = _teamService.GetById(id.Value);
            if (team != null)
            {
                _teamService.DeleteById(id.Value);
            }
            return HttpNotFound();
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _teamService.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
