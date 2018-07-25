using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VerzovaciSystem.Models.Entities;

namespace VerzovaciSystem.Models
{
    public class TableListViewModel
    {
        public List<TableListEntity> TableList { get; private set; }

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
    }
}