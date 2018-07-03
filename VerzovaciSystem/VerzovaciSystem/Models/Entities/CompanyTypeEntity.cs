using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models.Entities
{
    public class CompanyTypeEntity
    {
        public string Type { get; private set; }
        public string Description { get; private set; }

        public CompanyTypeEntity(string type, string description)
        {
            Type = type;
            Description = description;
        }
    }
}