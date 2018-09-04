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

        [Display(Name = "VER_CREATED_DATE")]
        public DateTime Created { get; private set; }

        [Display(Name = "VER_CREATED_USER")]
        public string User { get; private set; }

        public string Status { get; private set; }

        public SelectionMaskOutputEntity(long iD, string company, string group, DateTime date, DateTime created, string user, string status)
        {
            Id = iD;
            Company = company;
            Group = group;
            Date = date;
            Created = created;
            User = user;
            Status = status;
        }

        // pro popisky View SelectionMaskOutput
        public SelectionMaskOutputEntity()
        { }
        
    }
}