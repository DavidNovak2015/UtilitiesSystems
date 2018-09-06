using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models.Entities
{
    public class SelectionMaskOutputEntity
    {
        [Display(Name ="Označení")]
        public long Id { get; private set; }

        [Display(Name = "Jméno společnosti")]
        public string Company { get; private set; }

        [Display(Name = "Skupina serverů")]
        public string Group { get; private set; }

        [Display(Name = "Čas aktualizace")]
        public DateTime Date { get; private set; }

        [Display(Name = "Datum vytvoření")]
        public DateTime Created { get; private set; }

        [Display(Name = "Vytvořil")]
        public string User { get; private set; }

        public string Status { get; private set; }

        [Display(Name ="Typ společnosti")]
        public string CompanyType { get; private set; }

        public SelectionMaskOutputEntity(long iD, string company, string group, DateTime date, DateTime created, string user, string status, string companyType)
        {
            Id = iD;
            Company = company;
            Group = group;
            Date = date;
            Created = created;
            User = user;
            Status = status;
            CompanyType = companyType;
        }

        // pro popisky View SelectionMaskOutput
        public SelectionMaskOutputEntity()
        { }
        
    }
}