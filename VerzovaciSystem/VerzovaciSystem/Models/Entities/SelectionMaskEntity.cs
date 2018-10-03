using System;
using System.ComponentModel.DataAnnotations;

namespace VerzovaciSystem.Models.Entities
{
    public class SelectionMaskEntity
    {
        [Display(Name = "Id verze")]
        public long? Id { get; set; }

        [Display(Name = "Typ společnosti")]
        public string CompanyTyp { get; set; }

        [Display(Name = "Společnost")]
        public string Company { get; set; }

        [Display(Name = "Skupina serverů")]
        [StringLength(10, ErrorMessage = "Překročen limit 10 znaků")]
        public string Group { get; set; }

        [Display(Name = "Datum verze od")]
        [DataType(DataType.Date)]
        public DateTime VersionDateFrom { get; set; }

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