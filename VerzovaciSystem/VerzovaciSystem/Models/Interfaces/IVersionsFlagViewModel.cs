namespace VerzovaciSystem.Models.Interfaces
{
    public interface IVersionsFlagViewModel
    {
        // naplní Selectionresult všemi událostmi k předanému číslu verze včetně true/false hodnoty zda je LOGSoubor
        void GetEventsToVersion(long versionLogId);

        // naplní VersionFlagEntity pouze s flagId, versionLogId a log file
        void GetLogFile(long versionFlagId);
    }
}
