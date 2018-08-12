using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerzovaciSystemDB;

namespace VerzovaciSystem.Models.Entities
{
    public class CompanyEntity
    {
        DbRepository dbRepository = new DbRepository();

        // pro Vyhledávací masku
        public int Id { get;  set; }

        [Required (ErrorMessage ="Vyplňte prosím")]
        [MaxLength(100, ErrorMessage ="Příliš dlouhé. Zkraťte prosím na max. 99 znaků")]
        public string Name { get; set; }

        // pro Číselníky
        [Required (ErrorMessage ="Vyberte prosím")]
        public string Active { get;  set; }

        [MaxLength(4000, ErrorMessage = "Příliš dlouhé. Zkraťte prosím na max. 3999 znaků")]
        public string Description { get;  set; }

        [MaxLength(4000, ErrorMessage = "Příliš dlouhé. Zkraťte prosím na max. 3999 znaků")]
        public string Interface { get;  set; }

        public string Type { get;  set; }

        [MaxLength(50, ErrorMessage = "Příliš dlouhé. Zkraťte prosím na max. 49 znaků")]
        public string Language { get;  set; }

        // pro nový záznam do tabulky, DropDownList aktivní/neaktivní
        public List<SelectListItem> Actives { get;  set; }

        // pro nový záznam do tabulky, DropDownList  typ společnosti
        public List<SelectListItem> Types { get;  set; }

        // pro Vyhledávací masku
        public CompanyEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // pro Číselníky - výpis záznamu
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

        // pro Číselníky - založení nového záznamu
        public CompanyEntity()
        {
            Actives = new List<SelectListItem>();
            Actives.Add(new SelectListItem { Text = "Option", Value = null });
            Actives.Add(new SelectListItem { Text = "Neaktivní", Value = "N" });
            Actives.Add(new SelectListItem { Text = "Aktivní", Value = "A" });

            List<EX_COMPANY_TYPE> companyTypesFromDB = dbRepository.GetCompanyTypes();

            Types = new List<SelectListItem>();
            Types.Add(new SelectListItem { Text = "option", Value = null });

            foreach (var companyType in companyTypesFromDB)
            {
                Types.Add(new SelectListItem { Text = companyType.EX_DESC, Value = companyType.EX_COMPANY_TYPE1 });
            }

        }

        // pro Číselníky - změna záznamu
        public CompanyEntity(int id, string name, string active, string description, string interfaceC, string type, string language,string notUsed)
        {
            Id = id;
            Name = name;
            Active = active;
            Description = description;
            Interface = interfaceC;
            Type = type;
            Language = language;

            Actives = new List<SelectListItem>();
            Actives.Add(new SelectListItem { Text = "Option", Value = null });
            Actives.Add(new SelectListItem { Text = "Neaktivní", Value = "N" });
            Actives.Add(new SelectListItem { Text = "Aktivní", Value = "A" });

            List<EX_COMPANY_TYPE> companyTypesFromDB = dbRepository.GetCompanyTypes();

            Types = new List<SelectListItem>();
            Types.Add(new SelectListItem { Text = "option", Value = null });

            foreach (var companyType in companyTypesFromDB)
            {
                Types.Add(new SelectListItem { Text = companyType.EX_DESC, Value = companyType.EX_COMPANY_TYPE1 });
            }
        }
    }
}