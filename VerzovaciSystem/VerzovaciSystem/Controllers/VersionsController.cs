using System.Web.Mvc;
using VerzovaciSystem.Models;
using VerzovaciSystem.Models.Entities;

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
        public ActionResult ChangeVersion(long idVersion)
        {
            versionsViewModel.GetVersion(idVersion);
            return View(versionsViewModel.Version);
        }

        // zašle verzi k aktualizaci v VERSION_LOG
        [HttpPost]
        public ActionResult ChangeVersion(VersionEntity versionToChange)
        {
            TempData["result"] = versionsViewModel.ChangeVersion(versionToChange);
            return RedirectToAction("GetVersion", new { idVersion = versionToChange.Id });
        }

        // zobrazí formulář pro zadání nové verze
        public ActionResult AddVersion()
        {
            versionsViewModel.Version = new Models.Entities.VersionEntity();
            return View(versionsViewModel.Version);
        }

        // zašle novou verzi k uložení do db
        [HttpPost]
        public ActionResult AddVersion(VersionEntity newVersion)
        {
            if (!ModelState.IsValid)
                return View(versionsViewModel.Version);

            TempData["result"] = versionsViewModel.AddVersion(newVersion);
            return RedirectToAction("GetTodayVersions", "SelectionMask");
        }
    }
}