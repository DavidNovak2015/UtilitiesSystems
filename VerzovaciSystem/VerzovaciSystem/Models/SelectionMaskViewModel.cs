using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerzovaciSystemDB;
using VerzovaciSystem.Models.Entities;

namespace VerzovaciSystem.Models
{
    public class SelectionMaskViewModel
    {
        DbRepository dbRepository = new DbRepository();

        [Display(Name ="Typ společnosti")]
        [Required(ErrorMessage ="Vyberte prosím typ společnosti")]
        public string CompanyTyp { get; set; }

        [Display(Name = "Společnost")]
        [Required(ErrorMessage = "Vyberte prosím společnost")]
        public string Company { get; set; }

        [Display(Name = "Datum verze od")]
        [Required(ErrorMessage ="Vyberte prosím datum")]
        //[DataType(DataType.Date)]
        public DateTime VersionDateFrom { get; set; }

        [Display(Name = "Datum verze do")]
        [Required(ErrorMessage = "Vyberte prosím datum")]
        [DataType(DataType.Date)]
        public DateTime VersionDateTo { get; set; }

        [Display(Name = "Datum vytvoření od")]
        [Required(ErrorMessage = "Vyberte prosím datum")]
        [DataType(DataType.Date)]
        public DateTime CreationDateFrom { get; set; }

        [Display(Name = "Datum vytvoření do")]
        [Required(ErrorMessage = "Vyberte prosím datum")]
        [DataType(DataType.Date)]
        public DateTime CreationDateTo { get; set; }

        //[Display(Name = "Global status")]
        //[Required(ErrorMessage = "Vyberte prosím global status")]
        //public string GlobalStatus { get; set; }

        public List<SelectListItem> CompanyTypes { get; private set; }

        public List<SelectListItem> Companies { get; private set; }

        //public List<SelectListItem> GlobalStatusChoice { get; private set; }

        public SelectionMaskViewModel()
        {
            VersionDateFrom = DateTime.Now.Date;
            List<EX_COMPANY_TYPE> companyTypesFromDB = dbRepository.GetCompanyTypes();
            List<VERSION_COMPANY> companiesFromDB = dbRepository.GetCompanies();

            List<CompanyTypeEntity> companyTypes = companyTypesFromDB.Select(x => new CompanyTypeEntity(x.EX_COMPANY_TYPE1, x.EX_DESC)).ToList();
            List<CompanyEntity> companies = companiesFromDB.Select(x => new CompanyEntity(HelpsMethods.GetIntValue(x.VER_COMPANY_ID), x.VER_COMPANY)).ToList();
            
            CompanyTypes = new List<SelectListItem>();
            Companies = new List<SelectListItem>();
            //GlobalStatusChoice = new List<SelectListItem>();

            CompanyTypes.Add(new SelectListItem { Text = "option", Value = null });
            foreach (var companyType in companyTypes)
            {
                CompanyTypes.Add(new SelectListItem { Text=companyType.Description, Value=companyType.Type});
            }

            Companies.Add(new SelectListItem { Text = "option", Value = null });
            foreach (var company in companies)
            {
                Companies.Add(new SelectListItem { Text = company.Name, Value = company.Id.ToString() });
            }

            //GlobalStatusChoice.Add(new SelectListItem { Text = "options", Value = null });
            //GlobalStatusChoice.Add(new SelectListItem { Text = "Silver", Value = "Silver" });
            //GlobalStatusChoice.Add(new SelectListItem { Text = "Gold", Value = "Gold" });
        }

        //public static int GetCompanyId (int? companyId)
        //{
        //    if (!companyId.HasValue)
        //        throw new InvalidOperationException($"{nameof(companyId)} is empty");

        //    return companyId.Value;
        //}
    }
}