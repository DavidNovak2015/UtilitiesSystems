﻿namespace VerzovaciSystem.Models.Entities
{
    // pro Číselníky - seznam tabulek
    public class TableListEntity
    {
        public string TableName { get; private set; }
        public string ControllerName { get; private set; }
        public string TableDescription { get; private set; }

        public TableListEntity(string tableName, string controllerName,string tableDescription)
        {
            TableName = tableName;
            ControllerName = controllerName;
            TableDescription = tableDescription;
        }
    }
}