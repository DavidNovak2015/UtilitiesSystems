using VerzovaciSystem.Models.Entities;

namespace VerzovaciSystem.Models.Interfaces
{
    public interface IVersionsViewModel
    {
        //Najde verzi z VERSION_LOG
        void GetVersion(long idVersion);

        // naplní Version daty z db VER_SQL_Data
        void GetSqlData(long idVersion);

        // naplní Version daty z db VER_SQL_Data_Check
        void GetSqlDataCheck(long idVersion);

        // odstraní verzi z tabulky VERSION_LOG
        string DeleteVersion(long idVersion);

        // zašle verzi k aktualizaci
        string ChangeVersion(VersionEntity versionToChange);

        // najde všechny template do DropDownListu pro nové verze z V_VERSION_LOG_TEMPLATE
        void GetTemplateVersionsAndCompanies();

        // najde template pro novou verzi z V_VERSION_LOG_TEMPLATE
        void GetTemplateVersion(long idVersion);

        // zašle novou verzi k uložení do db
        string AddVersion(VersionEntity versionEntity, ref long versionId);
    }
}
