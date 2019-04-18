using VerzovaciSystem.Models.Entities;

namespace VerzovaciSystem.Models.Interfaces
{
    public interface ICompaniesViewModel
    {
        // vrátí všechny záznamy
        void GetTableView();

        // uloží nový záznam
        string SaveCompany(CompanyEntity newCompany);

        // vrátí vybraný záznam pro potvrzení vymazání
        void GetCompanyForDeletionAndUpdate(int companyId);

        // odstraní záznam
        string DeleteCompany(CompanyEntity companyForDeletion);

        // aktualizuje záznam
        string ChangeCompany(CompanyEntity companyForChange);
    }
}
