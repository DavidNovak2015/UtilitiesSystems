using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{
    public class VersionsController : Controller
    {
        VersionsViewModel versionsViewModel = new VersionsViewModel();

        public ActionResult GetTodayVersions()
        {
            versionsViewModel.GetTodayVersions();

            return View(versionsViewModel);
        }
    }
}