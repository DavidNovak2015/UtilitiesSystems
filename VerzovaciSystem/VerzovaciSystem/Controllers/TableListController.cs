﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerzovaciSystem.Models;

namespace VerzovaciSystem.Controllers
{
    public enum Tables { VERSION_COMPANY }

    public class TableListController : Controller
    {
        public Tables TableName { get; set; }
        TableListViewModel tableListViewModel = new TableListViewModel();

        public ActionResult TableList()
        {
            return View(tableListViewModel);
        }

        public ActionResult TableView(string tableName)
        {
            switch (tableName)
            {
                case "VERSION_COMPANY":TableName=Tables.VERSION_COMPANY; tableListViewModel.GetTableData(TableName);ViewBag.TableName=tableName ; break;
            }
            return View(tableListViewModel);
        }
    }
}