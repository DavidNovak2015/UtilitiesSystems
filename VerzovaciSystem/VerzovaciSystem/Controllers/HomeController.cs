using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerzovaciSystem.Models;
using VerzovaciSystemDB;

namespace VerzovaciSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TableList() // zde budou číselníky
        {
            TableListViewModel tableListViewModel = new TableListViewModel();
            return View(tableListViewModel);
        }

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