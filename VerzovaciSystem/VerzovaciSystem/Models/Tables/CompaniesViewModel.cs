using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VerzovaciSystemDB;
using VerzovaciSystem.Models.Entities;

namespace VerzovaciSystem.Models
{
    // VERSION_COMPANY
    public class CompaniesViewModel
    {
        DbRepository dbRepository = new DbRepository();

        // popisky sloupců tabulek
        public CompanyEntity CompanyEntity { get; set; }

        public List<CompanyEntity> TableData { get; private set; }

        public CompaniesViewModel()
        {
            CompanyEntity = new CompanyEntity();
        }

        public void GetTableView()
        {
            List<VERSION_COMPANY> companiesFromDB = dbRepository.GetCompanies();
            TableData = companiesFromDB.Select(x => new CompanyEntity(HelpsMethods.GetIntValue(x.VER_COMPANY_ID), x.VER_COMPANY, x.VER_COMPANY_ACTIVE, x.VER_COMPANY_DESC, x.VER_COMPANY_INTERFACE, x.VER_COMPANY_TYPE, x.VER_COMPANY_LANGUAGE))
                                       .OrderBy(a => a.Id)
                                       .ToList();
        }

        public string SaveCompany (CompanyEntity newCompany)
        {
            VERSION_COMPANY companyToDB = new VERSION_COMPANY();
            companyToDB.VER_COMPANY = newCompany.Name;
            companyToDB.VER_COMPANY_ACTIVE = newCompany.Active;
            companyToDB.VER_COMPANY_DESC = newCompany.Description;
            companyToDB.VER_COMPANY_INTERFACE = newCompany.Interface;
            companyToDB.VER_COMPANY_TYPE = newCompany.Type;
            companyToDB.VER_COMPANY_LANGUAGE = newCompany.Language;

            return dbRepository.AddCompany(companyToDB);
        }
    }
}