using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{

    public class TablesListController : Controller
    {
        TablesListViewModel tablesViewModel = new TablesListViewModel();

        // Seznam tabulek
        public ActionResult TablesList()
        {
            return View(tablesViewModel);
        }
    }
}