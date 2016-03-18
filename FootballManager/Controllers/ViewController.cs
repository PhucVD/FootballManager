using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FootballManager.Controllers
{
    public class ViewController : Controller
    {
        public ActionResult Get(string viewName)
        {
            return PartialView("~/Views"+viewName);
        }
    }
}