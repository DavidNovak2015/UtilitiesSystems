using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models.Entities
{
    public class TableListEntity
    {
        public string TableName { get; private set; }
        public string TableDescription { get; private set; }

        public TableListEntity(string tableName, string tableDescription)
        {
            TableName = tableName;
            TableDescription = tableDescription;
        }
    }
}