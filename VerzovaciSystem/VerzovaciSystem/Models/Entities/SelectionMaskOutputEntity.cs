using System;
using System.ComponentModel.DataAnnotations;

namespace VerzovaciSystem.Models.Entities
{
    public class SelectionMaskOutputEntity
    {
        [Display(Name ="Označení")]
        public long Id { get; protected set; }

        [Display(Name = "Společnost")]
        public string Company { get; protected set; }

        [Display(Name = "Čas aktualizace")]
        public DateTime Date { get; protected set; }

        [Display(Name = "Datum vytvoření")]
        public DateTime Created { get; protected set; }

        [Display(Name = "Vytvořil")]
        public string User { get; protected set; }

        [Display(Name = "Skupina serverů")]
        public string Group { get; protected set; }

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

        // pro potomka - VersionEntity
        public SelectionMaskOutputEntity(long iD, string company, DateTime date, DateTime created, string user, string group)
        {
            Id = iD;
            Company = company;
            Group = group;
            Date = date;
            Created = created;
            User = user;
        }

    }
}