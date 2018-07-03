using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models.Entities
{
    public class CompanyEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public CompanyEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}