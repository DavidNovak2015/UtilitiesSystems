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
            if (!ModelState.IsValid)
                return View(selectionMaskViewModel);



            return View();
        }
    }
}