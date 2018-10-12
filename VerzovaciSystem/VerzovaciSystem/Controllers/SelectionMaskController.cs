using System;
using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{
    public class SelectionMaskController : Controller
    {
        SelectionMaskViewModel selectionMaskViewModel = new SelectionMaskViewModel();

        // zobrazení nabídky vyhledávací masky
        public ActionResult SelectionMask()
        {
            selectionMaskViewModel.GetSelectionMask();
            return View(selectionMaskViewModel);
        }

        // zobrazení výsledku hledání dle zadání ve vyhledávací masce
        [HttpPost]
        public ActionResult SelectionMask(SelectionMaskViewModel selectionMaskViewModel)
        {
            if (selectionMaskViewModel.SelectionMaskEntity.Id == null &&
                (selectionMaskViewModel.SelectionMaskEntity.CompanyTyp == null) &&
                (selectionMaskViewModel.SelectionMaskEntity.Company == null) &&
                (selectionMaskViewModel.SelectionMaskEntity.CompanyWithGroup == null) &&
                (selectionMaskViewModel.SelectionMaskEntity.Group == null) &&
                (selectionMaskViewModel.SelectionMaskEntity.VersionDateFrom == DateTime.MinValue) &&
                (selectionMaskViewModel.SelectionMaskEntity.VersionDateTo == DateTime.MinValue) &&
                (selectionMaskViewModel.SelectionMaskEntity.CreationDateFrom == DateTime.MinValue) &&
                (selectionMaskViewModel.SelectionMaskEntity.CreationDateTo == DateTime.MinValue) &&
                (selectionMaskViewModel.SelectionMaskEntity.SearchInDeleted == false) 
               ) 
                {
                TempData["result"] = "Nebylo vyplněno aspoň jedno pole nebo pole nebyla vyplněna správnými hodnotami";

                return RedirectToAction("SelectionMask");
                }

            selectionMaskViewModel.GetSelectedRecords(selectionMaskViewModel.SelectionMaskEntity);
            TempData["selectionMaskVersions"] = "Nalezené verze:";

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