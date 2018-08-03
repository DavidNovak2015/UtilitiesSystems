using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerzovaciSystem.Models;
using VerzovaciSystem.Models.Entities;

namespace VerzovaciSystem.Controllers
{
    public enum Tables { VERSION_COMPANY }

    public class TablesController : Controller
    {
        public Tables TableName { get; set; }
        TablesViewModel tablesViewModel = new TablesViewModel();

        // Seznam tabulek
        public ActionResult TablesList()
        {
            return View(tablesViewModel);
        }

        // Zobrazení dat z vybrané tabulky
        public ActionResult TableView(string tableName)
        {
            switch (tableName)
            {
                case "VERSION_COMPANY":TableName=Tables.VERSION_COMPANY; tablesViewModel.GetTableData(TableName);ViewBag.TableName=tableName ; return View("TableVersionCompanyView", tablesViewModel);
            }
            return RedirectToAction("TablesList");
        }

        // zobrazí objekt pro nový záznam do tabulky
        public ActionResult AddTableRow (string tableName)
        {
            switch (tableName)
            {
                case "VERSION_COMPANY":TableName = Tables.VERSION_COMPANY; ViewBag.TableName = tableName; return View("TableVersionCompanyAddRow", tablesViewModel);
            }
            return RedirectToAction("TablesList");
        }

        // přidá nový záznam do tabulky
        [HttpPost]
        public ActionResult AddTableRow (TablesViewModel tablesViewModel)
        {
            if (!ModelState.IsValid)
                return View("TableVersionCompanyAddRow",tablesViewModel);

            return RedirectToAction("TablesList");
        }
        //public ActionResult ChangeTableRow(int iD, string tableName)
        //{
        //    return View();

        //}
    }
}