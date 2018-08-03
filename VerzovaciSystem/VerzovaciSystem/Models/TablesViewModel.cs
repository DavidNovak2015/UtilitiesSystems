using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VerzovaciSystem.Models.Entities;
using VerzovaciSystemDB;
using VerzovaciSystem.Controllers;

namespace VerzovaciSystem.Models
{
    public class TablesViewModel
    {
        DbRepository dbRepository = new DbRepository();

        // popisky sloupců tabulek
        public CompanyEntity CompanyEntity { get; set; }

        // Seznam tabulek
        public List<TableListEntity> TablesList { get; private set; }

        public List<CompanyEntity> TableData { get; private set; }

        // Seznam tabulek + objekty tabulek
        public TablesViewModel()
        {
            TablesList = new List<TableListEntity>();
            TablesList.Add(new TableListEntity("VERSION_COMPANY", "Seznam společností"));
            TablesList.Add(new TableListEntity("VERSION_RELEASE_DATE", "Evidence vydání release verzí"));
            TablesList.Add(new TableListEntity("VERSION_COMPANY_TNS_ALIAS", "Evidence připojení do společnosti"));
            TablesList.Add(new TableListEntity("VERSION_COMPANY_BIGTABLE", "Evidence společností, které mají \"velké tabulky\" "));
            TablesList.Add(new TableListEntity("VERSION_COMPANY_BIGTABLES", "Seznam \"velkých tabulek\" "));
            TablesList.Add(new TableListEntity("EX_SCHEMA_EXCEPTIONS", "Seznam vyjímek pro konkrétní společnosti, které jsou vyloučené ze sychronizace schémat"));

            CompanyEntity = new CompanyEntity();
        }

        // Data z vybrané tabulky
        public void GetTableData (Tables tableName)
        {
            switch (tableName)
            {
                    case Tables.VERSION_COMPANY:
            List<VERSION_COMPANY> companiesFromDB = dbRepository.GetCompanies();
            TableData = companiesFromDB.Select(x => new CompanyEntity(HelpsMethods.GetIntValue(x.VER_COMPANY_ID), x.VER_COMPANY, x.VER_COMPANY_ACTIVE, x.VER_COMPANY_DESC, x.VER_COMPANY_INTERFACE, x.VER_COMPANY_TYPE, x.VER_COMPANY_LANGUAGE))
                                       .OrderBy(a => a.Id)                        
                                       .ToList();
                    break;
            }

        }

        

    }
}