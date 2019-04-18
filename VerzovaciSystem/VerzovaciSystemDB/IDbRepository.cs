using System.Collections.Generic;

namespace VerzovaciSystemDB
{
    public interface IDbRepository
    {
        // VYHLEDÁVACÍ MASKA                                                                                        VYHLEDÁVACÍ MASKA

        // Pro zobrazení Vyhledávací masky + GetCompanies() v ČÍSELNÍKY: VERSION_COMPANY 
        List<EX_COMPANY_TYPE> GetCompanyTypes();

        // Pro zobrazení vyhledávací masky - data do DropDownListu hledání podle společnosti+skupina serverů
        List<V_COMPANY_GROUP> GetCompaniesWithGroupsWithoutEF();

        // pro výsledky hledání dle parametrů vyhledávací masky
        List<V_VERSION_LIST1> GetAllRecordsFromV_VERSION_LIST1();

        // VERZE-dnešní                                                                                                    VERZE-dnešní

        // před načtením dnešních verzí - z V_VERSION_LIST1 vyselektuje dnešní verze
        string ReplaceDbViewV_VERSION_LIST2();

        // pro načtení seznamu dnešních verzí po zapnutí aplikace
        List<V_VERSION_LIST2> GetAllRecordsFromV_VERSION_LIST2();

        //VERZE z VERSION_LOG-kompletní data:                                                                     VERZE z VERSION_LOG-komplet                                                                                                    

        // Nalezení verze pro její aktualizaci nebo odstranění z tabulky VERSION_LOG
        VERSION_LOG GetVersion(long idVersion);

        // Odstranění verze z tabulky VERSION_LOG
        string DeleteVersion(long idVersion);

        // aktualizace verze v tabulce VERSION_LOG
        string ChangeVersion(VERSION_LOG versionToChange);

        // Přidání nové verze do VERSION_LOG
        string AddVersion(VERSION_LOG versionToDb, ref long versionId);

        // Vrátí všechny template z V_VERSION_LOG_TEMPLATE za účelem výběru template pro novou verzi
        List<V_VERSION_LOG_TEMPLATE> GetTemplateVersions();

        // Vrátí template pro novou verzi z V_VERSION_LOG_TEMPLATE
        V_VERSION_LOG_TEMPLATE GetTemplateVersion(long idVersion);

        //UDÁLOSTI z VERSION_FLAG                                                                                   UDÁLOSTI z VERSION_FLAG

        // Vrátí události verze z VERSION_FLAG tabulky
        List<VERSION_FLAG> GetAllRecordsFromVERSION_FLAG(long versionLogId);

        // Vrátí jednu událost k verzi z VERSION_FLAG tabulky pro zobrazení log soubor
        VERSION_FLAG GetFlagEvent(long versionFlagId);

        // ČÍSELNÍKY: VERSION_COMPANY                                                                            ČÍSELNÍKY: VERSION_COMPANY

        // také pro Vyhledávací maska - vrátí seznam společností
        List<VERSION_COMPANY> GetCompanies();

        // Přidání záznamu do VERSION_COMPANY
        string AddCompany(VERSION_COMPANY companyToDB);

        // Nalezení záznamu pro výmaz nebo změnu z VERSION_COMPANY
        VERSION_COMPANY GetCompanyForDeletion(int idCompany);

        // Vymazání záznamu z VERSION_COMPANY
        string DeleteCompany(VERSION_COMPANY companyForDeletion);

        // Aktualizace záznamu v VERSION_COMPANY
        string ChangeCompany(VERSION_COMPANY companyForChange);
    }
}
