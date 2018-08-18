using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models.Entities
{
    public class SelectionMaskEntity
    {
        [Display(Name = "Typ společnosti")]
        public string CompanyTyp { get; set; }

        [Display(Name = "Společnost")]
        public string Company { get; set; }

        [Display(Name = "Datum verze od")]
        [DataType(DataType.DateTime,ErrorMessage ="Zadejte prosím datum ve formátu dd.mm.rrrr")]
        public DateTime? VersionDateFrom { get; set; }

        [Display(Name = "Datum verze do")]
        [DataType(DataType.Date)]
        public DateTime VersionDateTo { get; set; }

        [Display(Name = "Datum vytvoření od")]
        [DataType(DataType.Date)]
        public DateTime CreationDateFrom { get; set; }

        [Display(Name = "Datum vytvoření do")]
        [DataType(DataType.Date)]
        public DateTime CreationDateTo { get; set; }

        //[Display(Name = "Global status")]
        //[Required(ErrorMessage = "Vyberte prosím global status")]
        //public string GlobalStatus { get; set; }
    }
}