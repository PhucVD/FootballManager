using System.Linq;
using System.Net;
using System.Web.Mvc;
using FootballManager.Domain;
using FootballManager.Service;

namespace FootballManager.Controllers
{
    public class TeamController : Controller
    {
        private readonly IBaseService<Team> _service;
        private readonly IBaseService<Nation> _nationSerevice;
        //private readonly ITeamService _service;

        public TeamController(IBaseService<Team> service, IBaseService<Nation>  nationSerevice)
        {
            _service = service;
            _nationSerevice = nationSerevice;
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
            var nationList = new SelectList(_nationSerevice.GetAll(), "NationId", "NationName");
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
