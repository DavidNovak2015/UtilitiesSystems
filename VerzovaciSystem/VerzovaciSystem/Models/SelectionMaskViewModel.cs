using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VerzovaciSystem.Models
{
    public class SelectionMaskViewModel
    {
        [Display(Name ="Typ společnosti")]
        [Required(ErrorMessage ="Vyberte prosím typ společnosti")]
        public string CompanyTyp { get; set; }

        [Display(Name = "Společnost")]
        [Required(ErrorMessage = "Vyberte prosím společnost")]
        public string Company { get; set; }

        [Display(Name = "Datum verze od-do")]
        [Required(ErrorMessage ="Vyberte prosím datum")]
        [DataType(DataType.Date)]
        public DateTime VersionDateFrom { get; set; }

        [Display(Name = "                 ")]
        [Required(ErrorMessage = "Vyberte prosím datum")]
        [DataType(DataType.Date)]
        public DateTime VersionDateTo { get; set; }

        [Display(Name = "Datum vytvoření od-do")]
        [Required(ErrorMessage = "Vyberte prosím datum")]
        [DataType(DataType.Date)]
        public DateTime CreationDateFrom { get; set; }

        [Display(Name = "                     ")]
        [Required(ErrorMessage = "Vyberte prosím datum")]
        [DataType(DataType.Date)]
        public DateTime CreationDateTo { get; set; }

        [Display(Name = "Global status")]
        [Required(ErrorMessage = "Vyberte prosím global status")]
        public string GlobalStatus { get; set; }

        public List<SelectListItem> CompanyTypes { get; private set; }

        public List<SelectListItem> Companies { get; private set; }

        public List<SelectListItem> GlobalStatusChoice { get; private set; }

        public SelectionMaskViewModel()
        {
            CompanyTypes = new List<SelectListItem>();
            Companies = new List<SelectListItem>();
            GlobalStatusChoice = new List<SelectListItem>();

            CompanyTypes.Add(new SelectListItem { Text = "options", Value = null});
            CompanyTypes.Add(new SelectListItem { Text = "E", Value = "E" });
            CompanyTypes.Add(new SelectListItem { Text = "W", Value = "W" });
            CompanyTypes.Add(new SelectListItem { Text = "M", Value = "M" });

            Companies.Add(new SelectListItem { Text = "options", Value = null });
            Companies.Add(new SelectListItem { Text = "Asentra, s.r.o.", Value = "Asentra" });
            Companies.Add(new SelectListItem { Text = "ČIA, o.p.s.", Value = "Ostwind" });

            GlobalStatusChoice.Add(new SelectListItem { Text = "options", Value = null });
            GlobalStatusChoice.Add(new SelectListItem { Text = "Silver", Value = "Silver" });
            GlobalStatusChoice.Add(new SelectListItem { Text = "Gold", Value = "Gold" });
        }
    }
}