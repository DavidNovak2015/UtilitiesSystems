using System.Web.Mvc;
using System;
using VerzovaciSystem.Models;
using VerzovaciSystem.Models.Entities;
using System.Collections.Generic;

namespace VerzovaciSystem.Controllers
{
    public class VersionsController : Controller
    {
        VersionsViewModel versionsViewModel = new VersionsViewModel();

        public List<SelectListItem> Companies { get; private set; }

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
            versionsViewModel.Version.LogUser = $"{Environment.MachineName}/{Environment.UserName}";

            if (versionsViewModel.Version.LogFlagString == "A")
                versionsViewModel.Version.LogFlagBool = true;

            else
                versionsViewModel.Version.LogFlagBool = false;

            return View(versionsViewModel.Version);
        }

        // zašle verzi k aktualizaci v VERSION_LOG
        [HttpPost]
        public ActionResult ChangeVersion(VersionEntity versionToChange)
        {
            if (!ModelState.IsValid)
            {
                return View(versionToChange);
            }

            if (versionToChange.LogFlagBool)
                versionToChange.LogFlagString = "A";
            else
                versionToChange.LogFlagString = "N";

            TempData["result"] = versionsViewModel.ChangeVersion(versionToChange);
            return RedirectToAction("GetVersion", new { idVersion = versionToChange.Id });
        }

        // NOVÁ VERZE
        // zobrazí prázdný formulář pro zadání nové verze
        public ActionResult AddVersion()
        {
            versionsViewModel.GetTemplateVersionsAndCompanies();
            versionsViewModel.Version = new VersionEntity($"{Environment.MachineName}/{Environment.UserName}",
                                                          DateTime.Now,
                                                          new DateTime(2018, 05, 30)
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
            versionsViewModel.GetTemplateVersionsAndCompanies();
            return View("AddVersion", versionsViewModel);
        }

        // zašle novou verzi z formuláře k uložení do db
        [HttpPost]
        public ActionResult AddVersion(VersionsViewModel versionsViewModel)
        {
            versionsViewModel.Version.LogDate = DateTime.Now;
            versionsViewModel.Version.Created = DateTime.Now;

            if (!ModelState.IsValid)
            {
                versionsViewModel.GetTemplateVersionsAndCompanies();
                return View(versionsViewModel);
            }

            if (versionsViewModel.Version.DeletedBool)
                versionsViewModel.Version.DeletedString = "A";
            else
                versionsViewModel.Version.DeletedString = "N";

            if (versionsViewModel.Version.LogFlagBool)
                versionsViewModel.Version.LogFlagString = "A";
            else
                versionsViewModel.Version.LogFlagString = "N";

            long versionId = 0;
            TempData["result"] = versionsViewModel.AddVersion(versionsViewModel.Version,ref versionId);
            return RedirectToAction("GetVersion", new { idVersion = versionId});
        }
    }
}