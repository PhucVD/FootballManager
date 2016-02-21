using System.Linq;
using System.Net;
using System.Web.Mvc;
using FootballManager.Domain;
using FootballManager.Service;

namespace FootballManager.Controllers
{
    public class TeamController : Controller
    {
        //private readonly IBaseService<Team> _teamService = new TeamService_();
        private readonly ITeamService _teamService;

        public TeamController(ITeamService service)
        {
            this._teamService = service;
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
            GetNationList();
            return View();
        }

        private void GetNationList()
        {
            var nationService = new NationService();
            var nationList = new SelectList(nationService.GetAll(), "NationId", "NationName");
            ViewBag.NationList = nationList;
        }

        // POST: Team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            GetNationList();
            return View(team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,TeamName,Nation")] Team team)
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
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
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
