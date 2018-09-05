using System.Collections.Generic;
using System.Linq;
using VerzovaciSystemDB;
using VerzovaciSystem.Models.Entities;

namespace VerzovaciSystem.Models
{
    // VERSION_COMPANY
    public class CompaniesViewModel
    {
        DbRepository dbRepository = new DbRepository();

        // popisky sloupců tabulek + záznam z tabulky VERSION_COMPANY pro změnu a výmaz
        public CompanyEntity CompanyEntity { get; set; }

        // pro hodnoty z db tabulky
        public List<CompanyEntity> TableData { get; private set; }

        public CompaniesViewModel()
        {
            CompanyEntity = new CompanyEntity();
        }

        // vrátí všechny záznamy
        public void GetTableView()
        {
            List<VERSION_COMPANY> companiesFromDB = dbRepository.GetCompanies();
            TableData = companiesFromDB.Select(x => new CompanyEntity(HelpsMethods.GetIntFromDecimal(x.VER_COMPANY_ID), x.VER_COMPANY, x.VER_COMPANY_ACTIVE, x.VER_COMPANY_DESC, x.VER_COMPANY_INTERFACE, x.VER_COMPANY_TYPE, x.VER_COMPANY_LANGUAGE))
                                       .OrderByDescending(a => a.Id)
                                       .ToList();
        }

        // uloží nový záznam
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

        // vrátí vybraný záznam pro potvrzení vymazání
        public void GetCompanyForDeletionAndUpdate (int companyId)
        {
            VERSION_COMPANY companyFromDB = dbRepository.GetCompanyForDeletion(companyId);

            CompanyEntity.Actives = new List<System.Web.Mvc.SelectListItem>();

            CompanyEntity = new CompanyEntity(HelpsMethods.GetIntFromDecimal(companyFromDB.VER_COMPANY_ID),
                                              companyFromDB.VER_COMPANY,
                                              companyFromDB.VER_COMPANY_ACTIVE,
                                              companyFromDB.VER_COMPANY_DESC,
                                              companyFromDB.VER_COMPANY_INTERFACE,
                                              companyFromDB.VER_COMPANY_TYPE,
                                              companyFromDB.VER_COMPANY_LANGUAGE,
                                              "not used"
                                             );
        }

        // odstraní záznam
        public string DeleteCompany(CompanyEntity companyForDeletion)
        {
            VERSION_COMPANY companyForDeletionDB = new VERSION_COMPANY();
            companyForDeletionDB.VER_COMPANY_ID = companyForDeletion.Id;
            companyForDeletionDB.VER_COMPANY = companyForDeletion.Name;
            companyForDeletionDB.VER_COMPANY_ACTIVE = companyForDeletion.Active;
            companyForDeletionDB.VER_COMPANY_DESC = companyForDeletion.Description;
            companyForDeletionDB.VER_COMPANY_INTERFACE = companyForDeletion.Interface;
            companyForDeletionDB.VER_COMPANY_TYPE = companyForDeletion.Type;
            companyForDeletionDB.VER_COMPANY_LANGUAGE = companyForDeletion.Language;

            return dbRepository.DeleteCompany(companyForDeletionDB);
        }

        // aktualizuje záznam
        public string ChangeCompany(CompanyEntity companyForChange)
        {
            VERSION_COMPANY companyForChangeDB = new VERSION_COMPANY();
            companyForChangeDB.VER_COMPANY_ID = companyForChange.Id;
            companyForChangeDB.VER_COMPANY = companyForChange.Name;
            companyForChangeDB.VER_COMPANY_ACTIVE = companyForChange.Active;
            companyForChangeDB.VER_COMPANY_DESC = companyForChange.Description;
            companyForChangeDB.VER_COMPANY_INTERFACE = companyForChange.Interface;
            companyForChangeDB.VER_COMPANY_TYPE = companyForChange.Type;
            companyForChangeDB.VER_COMPANY_LANGUAGE = companyForChange.Language;

            return dbRepository.ChangeCompany(companyForChangeDB);
        }
    }
}