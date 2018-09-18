using System;
using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{
    public class SelectionMaskController : Controller
    {
        SelectionMaskViewModel selectionMaskViewModel = new SelectionMaskViewModel();

        public ActionResult SelectionMask()
        {
            selectionMaskViewModel.GetSelectionMask();
            return View(selectionMaskViewModel);
        }

        [HttpPost]
        public ActionResult SelectionMask(SelectionMaskViewModel selectionMaskViewModel)
        {
            if ((selectionMaskViewModel.SelectionMaskEntity.CompanyTyp == null) &&
                (selectionMaskViewModel.SelectionMaskEntity.Company == null) &&
                (selectionMaskViewModel.SelectionMaskEntity.VersionDateFrom == null) &&
                (selectionMaskViewModel.SelectionMaskEntity.VersionDateTo == DateTime.MinValue) &&
                (selectionMaskViewModel.SelectionMaskEntity.CreationDateFrom == DateTime.MinValue) &&
                (selectionMaskViewModel.SelectionMaskEntity.CreationDateTo == DateTime.MinValue) 
               ) 
                {
                TempData["result"] = "Musí být vyplněno aspoň jedno pole";
                return View(selectionMaskViewModel);
                }

            selectionMaskViewModel.GetSelectedRecords(selectionMaskViewModel.SelectionMaskEntity);

            return View("SelectionMaskOutput",selectionMaskViewModel);
        }

        // pro odkaz v Layotu - dnešní verze a po startu aplikace
        public ActionResult GetTodayVersions()
        {
            selectionMaskViewModel.GetTodayVersions();
            TempData["todaysVersions"] = "Seznam dnešních verzí:";
            return View("SelectionMaskOutput", selectionMaskViewModel);
        }
    }
}