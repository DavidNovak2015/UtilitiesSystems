using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VerzovaciSystem.Models.Entities;
using VerzovaciSystemDB;
using VerzovaciSystem.Controllers;

namespace VerzovaciSystem.Models
{
    public class TableListViewModel
    {
        DbRepository dbRepository = new DbRepository();

        // popisky sloupců tabulek
        public CompanyEntity CompanyEntity { get; private set; }

        // Seznam tabulek
        public List<TableListEntity> TableList { get; private set; }

        public List<CompanyEntity> TableData { get; private set; }

        // Seznam tabulek
        public TableListViewModel()
        {
            TableList = new List<TableListEntity>();
            TableList.Add(new TableListEntity("VERSION_COMPANY", "Seznam společností"));
            TableList.Add(new TableListEntity("VERSION_RELEASE_DATE", "Evidence vydání release verzí"));
            TableList.Add(new TableListEntity("VERSION_COMPANY_TNS_ALIAS", "Evidence připojení do společnosti"));
            TableList.Add(new TableListEntity("VERSION_COMPANY_BIGTABLE", "Evidence společností, které mají \"velké tabulky\" "));
            TableList.Add(new TableListEntity("VERSION_COMPANY_BIGTABLES", "Seznam \"velkých tabulek\" "));
            TableList.Add(new TableListEntity("EX_SCHEMA_EXCEPTIONS", "Seznam vyjímek pro konkrétní společnosti, které jsou vyloučené ze sychronizace schémat"));
        }

        // Data z vybrané tabulky
        public void GetTableData (Tables tableName)
        {
            CompanyEntity = new CompanyEntity();
            switch (tableName)
            {
                    case Tables.VERSION_COMPANY:
            List<VERSION_COMPANY> companiesFromDB = dbRepository.GetCompanies();
            TableData = companiesFromDB.Select(x => new CompanyEntity(HelpsMethods.GetIntValue(x.VER_COMPANY_ID), x.VER_COMPANY, x.VER_COMPANY_ACTIVE, x.VER_COMPANY_DESC, x.VER_COMPANY_INTERFACE, x.VER_COMPANY_TYPE, x.VER_COMPANY_LANGUAGE)).ToList();
                    break;
            }

        }

    }
}