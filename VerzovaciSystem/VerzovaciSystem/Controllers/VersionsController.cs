﻿using System.Web.Mvc;
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

        public ActionResult GetVersion(long idVersion)
        {
            versionsViewModel.GetVersion(idVersion);
            return View(versionsViewModel);
        }
    }
}