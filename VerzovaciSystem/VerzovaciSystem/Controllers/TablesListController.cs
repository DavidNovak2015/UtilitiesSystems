using System.Web.Mvc;
using VerzovaciSystem.Models;
using VerzovaciSystem.Models.Interfaces;

namespace VerzovaciSystem.Controllers
{

    public class TablesListController : Controller
    {
        TablesListViewModel tablesListViewModel = new TablesListViewModel();

        // Seznam tabulek
        public ActionResult TablesList()
        {
            return View(tablesListViewModel);
        }
    }
}