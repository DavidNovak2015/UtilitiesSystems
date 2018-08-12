﻿using System;
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

        // vrátí vybraný záznam pro výmaz
        public ActionResult DeleteTableRow(int iD)
        {
            companiesViewModel.GetCompanyForDeletionAndUpdate(iD);
            return View(companiesViewModel);
        }

        // Vymaže potvrzený vybraný záznam
        [HttpPost]
        public ActionResult DeleteTableRow(CompaniesViewModel companiesViewModel)
        {
            TempData["result"] = companiesViewModel.DeleteCompany(companiesViewModel.CompanyEntity);
            return RedirectToAction("TableView");
        }

        // vrátí vybraný záznam pro aktualizaci
        public ActionResult ChangeTableRow(int iD)
        {
            companiesViewModel.GetCompanyForDeletionAndUpdate(iD);
            return View(companiesViewModel);
        }

        // Vymaže potvrzený vybraný záznam
        [HttpPost]
        public ActionResult ChangeTableRow(CompaniesViewModel companiesViewModel)
        {
            companiesViewModel.ChangeCompany(companiesViewModel.CompanyEntity);
            return RedirectToAction("TableView");
        }
    }
}