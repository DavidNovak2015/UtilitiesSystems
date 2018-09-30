using System;
using System.ComponentModel.DataAnnotations;

namespace VerzovaciSystem.Models.Entities
{
    public class SelectionMaskOutputEntity
    {
        [Display(Name ="Id verze")]
        public long Id { get;  set; }

        [Display(Name = "Společnost")]
        [StringLength(100, ErrorMessage ="Překročen limit 100 znaků")]
        [Required(ErrorMessage ="Povinné pole")]
        public string Company { get; set; }

        [Display(Name = "Čas aktualizace")]
        [Required(ErrorMessage = "Povinné pole")]
        [DataType(DataType.Date)]
        public DateTime Date { get;  set; }

        [Display(Name = "Datum vytvoření")]
        [Required(ErrorMessage = "Povinné pole")]
        [DataType(DataType.Date)]
        public DateTime Created { get;  set; }

        [Display(Name = "Vytvořil")]
        [StringLength(100, ErrorMessage = "Překročen limit 100 znaků")]
        [Required(ErrorMessage = "Povinné pole")]
        public string User { get;  set; }

        [Display(Name = "Skupina serverů")]
        [StringLength(10, ErrorMessage = "Překročen limit 10 znaků")]
        public string Group { get;  set; }

        public string Status { get;  set; }

        [Display(Name ="Typ společnosti")]
        public string CompanyType { get;  set; }

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