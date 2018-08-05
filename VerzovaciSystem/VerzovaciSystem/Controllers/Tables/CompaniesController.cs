using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerzovaciSystem.Models;


namespace VerzovaciSystem.Controllers
{
    // VERSION_COMPANY
    public class CompaniesController : Controller
    {
        CompaniesViewModel companiesViewModel = new CompaniesViewModel();

        // ZOBRAZENÍ CELÉ TABULKY
        public ActionResult TableView()
        {
            companiesViewModel.GetTableView();     
            return View(companiesViewModel);
        }

        // zobrazí objekt pro nový záznam do tabulky
        public ActionResult AddTableRow()
        {
            return View(companiesViewModel);
        }

        // přidá nový záznam do tabulky
        [HttpPost]
        public ActionResult AddTableRow(CompaniesViewModel companiesViewModel)
        {
            if (!ModelState.IsValid)
                return View(companiesViewModel);

            TempData["result"] = companiesViewModel.SaveCompany(companiesViewModel.CompanyEntity);
            return RedirectToAction("TableView");
        }
        //public ActionResult ChangeTableRow(int iD, string tableName)
        //{
        //    return View();

        //}
    }
}