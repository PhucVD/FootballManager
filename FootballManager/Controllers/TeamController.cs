using System.Linq;
using System.Net;
using System.Web.Mvc;
using FootballManager.Domain;
using FootballManager.Service;

namespace FootballManager.Controllers
{
    public class TeamController : Controller
    {
        //private readonly IBaseService<Team> _service;
        private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            this._service = service;
        }

        // GET: Team
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Team/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = _service.GetById(id.Value);
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
            var nationService = new NationService();
            var nationList = new SelectList(nationService.GetAll(), "NationId", "NationName");
            ViewBag.NationList = nationList;
        }

        // POST: Team/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(team);
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
            Team team = _service.GetById(id.Value);
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
                _service.Update(team);
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
            Team team = _service.GetById(id.Value);
            if (team != null)
            {
                _service.DeleteById(id.Value);
            }
            return HttpNotFound();
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
