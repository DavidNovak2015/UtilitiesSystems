using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{
    public class SelectionMaskController : Controller
    {
        public ActionResult SelectionMask()
        {
            SelectionMaskViewModel selectionMaskViewModel = new SelectionMaskViewModel();
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


            return View(selectionMaskViewModel);
        }
    }
}