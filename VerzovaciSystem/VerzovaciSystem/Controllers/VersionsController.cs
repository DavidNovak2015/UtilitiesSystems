using System.Web.Mvc;
using System;
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

        // NOVÁ VERZE
        // zobrazí prázdný formulář pro zadání nové verze
        public ActionResult AddVersion()
        {
            versionsViewModel.GetTemplateVersions();
            versionsViewModel.Version = new VersionEntity($"{Environment.MachineName}/{Environment.UserName}",
                                                          DateTime.Now
                                                         );
            return View(versionsViewModel);
        }

        // zobrazí předvyplněný formulář z vybraného vzoru pro zadání nové verze
        [HttpPost]
        public ActionResult GetTemplateVersion(VersionsViewModel versionsViewModel)
        {
            if (versionsViewModel.TemplateVersionId == 0)
            {
                TempData["result"] = "Nebyl vybrán vzor";
                return RedirectToAction("AddVersion");
            }

            versionsViewModel.GetTemplateVersion(versionsViewModel.TemplateVersionId);
            versionsViewModel.GetTemplateVersions();
            return View("AddVersion", versionsViewModel);
        }

        // zašle novou verzi z prázdného formuláře k uložení do db
        [HttpPost]
        public ActionResult AddVersion(VersionsViewModel versionsViewModel)
        {
            if (!ModelState.IsValid)
            {
                versionsViewModel.GetTemplateVersions();
                return View(versionsViewModel);
            }

            if (versionsViewModel.Version.DeletedBool)
                versionsViewModel.Version.DeletedString = "A";
            else
                versionsViewModel.Version.DeletedString = "N";

            TempData["result"] = versionsViewModel.AddVersion(versionsViewModel.Version);
            return RedirectToAction("GetTodayVersions", "SelectionMask");
        }
    }
}