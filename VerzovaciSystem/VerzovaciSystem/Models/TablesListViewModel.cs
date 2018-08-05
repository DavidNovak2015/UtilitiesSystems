using System.Collections.Generic;
using VerzovaciSystem.Models.Entities;
using VerzovaciSystemDB;


namespace VerzovaciSystem.Models
{
    public class TablesListViewModel
    {
        DbRepository dbRepository = new DbRepository();

        // Seznam tabulek
        public List<TableListEntity> TablesList { get; private set; }

        // Seznam tabulek
        public TablesListViewModel()
        {
            TablesList = new List<TableListEntity>();
            TablesList.Add(new TableListEntity("VERSION_COMPANY", "Seznam společností"));
            TablesList.Add(new TableListEntity("VERSION_RELEASE_DATE", "Evidence vydání release verzí"));
            TablesList.Add(new TableListEntity("VERSION_COMPANY_TNS_ALIAS", "Evidence připojení do společnosti"));
            TablesList.Add(new TableListEntity("VERSION_COMPANY_BIGTABLE", "Evidence společností, které mají \"velké tabulky\" "));
            TablesList.Add(new TableListEntity("VERSION_COMPANY_BIGTABLES", "Seznam \"velkých tabulek\" "));
            TablesList.Add(new TableListEntity("EX_SCHEMA_EXCEPTIONS", "Seznam vyjímek pro konkrétní společnosti, které jsou vyloučené ze sychronizace schémat"));
        }
    }
}