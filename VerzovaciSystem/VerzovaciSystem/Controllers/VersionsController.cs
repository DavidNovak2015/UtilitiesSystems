using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{
    public class VersionsController : Controller
    {
        VersionsViewModel versionsViewModel = new VersionsViewModel();

        // vrací jednu verzi z VERSION_LOG se všemi sloupci
        public ActionResult GetVersion(long idVersion)
        {
            versionsViewModel.GetVersion(idVersion);
            return View(versionsViewModel);
        }

        // vrací verzi z VERSION_LOG k potvrzení odstranění
        public ActionResult GetVersionForDeletion(long idVersion)
        {
            versionsViewModel.GetVersion(idVersion);
            return View(versionsViewModel);
        }

        // zašle verzi k odstranění z VERSION_LOG
        public ActionResult DeleteVersion(long idVersion)
        {
            TempData["result"] = versionsViewModel.DeleteVersion(idVersion);
            return RedirectToAction("GetTodayVersions", "SelectionMask");
        }

        // vrací verzi z VERSION_LOG k provedení aktualizace
        public ActionResult GetVersionForChange(long idVersion)
        {
            versionsViewModel.GetVersion(idVersion);
            return View(versionsViewModel);
        }

        // zašle verzi k aktualizaci v VERSION_LOG
        [HttpPost]
        public ActionResult ChangeVersion(VersionsViewModel versionsViewModel)
        {
            TempData["result"] = versionsViewModel.ChangeVersion(versionsViewModel.Version);
            return RedirectToAction("GetVersion", new { idVersion = versionsViewModel.Version.Id });
        }
    }
}