using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models.Entities
{
    public class CompanyEntity
    {
        // pro Vyhledávací masku
        public int Id { get; private set; }
        public string Name { get; private set; }

        // pro Číselníky
        public string Active { get; private set; }
        public string Description { get; private set; }
        public string Interface { get; private set; }
        public string Type { get; private set; }
        public string Language { get; private set; }


        // pro Vyhledávací masku
        public CompanyEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public CompanyEntity (int id, string name, string active, string description, string interfaceC, string type, string language)
        {
            Id = id;
            Name = name;
            Active = active;
            Description = description;
            Interface = interfaceC;
            Type = type;
            Language = language;
        }
        public CompanyEntity()
        { }
    }
}