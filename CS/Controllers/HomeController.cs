using System.Web.Mvc;

namespace DockingAddDynamicallyMvc.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        public ActionResult DockPanelPartial(int index) {
            ViewData["index"] = index;
            return PartialView();
        }
    }
}