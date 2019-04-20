using System.Collections.Generic;
using VerzovaciSystem.Models.Entities;
using VerzovaciSystem.Models.Interfaces;
using VerzovaciSystemDB;


namespace VerzovaciSystem.Models
{
    public class TablesListViewModel
    {
        // Seznam tabulek
        public List<TableListEntity> TablesList { get; private set; }

        // Seznam tabulek
        public TablesListViewModel()
        {
            TablesList = new List<TableListEntity>();
            TablesList.Add(new TableListEntity("VERSION_COMPANY", "Companies","Seznam společností"));
            TablesList.Add(new TableListEntity("VERSION_RELEASE_DATE", "Companies", "Evidence vydání release verzí"));
            TablesList.Add(new TableListEntity("VERSION_COMPANY_TNS_ALIAS", "Companies", "Evidence připojení do společnosti"));
            TablesList.Add(new TableListEntity("VERSION_COMPANY_BIGTABLE", "Companies", "Evidence společností, které mají \"velké tabulky\" "));
            TablesList.Add(new TableListEntity("VERSION_COMPANY_BIGTABLES", "Companies", "Seznam \"velkých tabulek\" "));
            TablesList.Add(new TableListEntity("EX_SCHEMA_EXCEPTIONS", "Companies", "Seznam vyjímek pro konkrétní společnosti, které jsou vyloučené ze sychronizace schémat"));
        }

    }
}