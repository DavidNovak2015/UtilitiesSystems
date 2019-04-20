using System.Collections.Generic;
using System.Linq;
using VerzovaciSystem.Models.Entities;
using VerzovaciSystem.Models.Interfaces;
using VerzovaciSystemDB;

namespace VerzovaciSystem.Models
{
    public class VersionsFlagViewModel: IVersionsFlagViewModel
    {
        //Autofac
        private readonly IDbRepository dbRepository;

        //Autofac
        public VersionsFlagViewModel(IDbRepository iDbRepository)
        {
            dbRepository = iDbRepository;
        }

        // pro labely
        public VersionFlagEntity VersionFlagEntity { get; private set; }

        // pro výběr z VERSION_FLAG podle Id z VERSION_LOG
        public List<VersionFlagEntity> SelectionResult { get; private set; }

        // naplní Selectionresult všemi událostmi k předanému číslu verze včetně true/false hodnoty zda je LOGSoubor
        public void GetEventsToVersion(long versionLogId)
        {
            VersionFlagEntity = new VersionFlagEntity(versionLogId);

            List<VERSION_FLAG> versionsFlagFromDB = dbRepository.GetAllRecordsFromVERSION_FLAG(versionLogId);

            SelectionResult = versionsFlagFromDB.Where(udalost => udalost.VERF_FILE != null)
                                              .Select(x => new VersionFlagEntity(x.VERF_ID,
                                                                                 x.VERF_FLAG,
                                                                                 x.VERF_DESC.Replace("\n","<br/>"),
                                                                                 x.VERF_DATE,
                                                                                 true,
                                                                                 x.VERF_CREATED_DATE 
                                                                                )
                                                     ).OrderByDescending(x => x.Id)
                                                      .ToList();

            List<VersionFlagEntity> recordsWithouteventWithDESC = new List<VersionFlagEntity>();

            recordsWithouteventWithDESC = versionsFlagFromDB.Where(udalost => udalost.VERF_FILE == null)
                                                            .Where(description => description.VERF_DESC != null)
                                                .Select(x => new VersionFlagEntity(x.VERF_ID,
                                                                                x.VERF_FLAG,
                                                                                x.VERF_DESC.Replace("\n", "<br/>"),
                                                                                x.VERF_DATE,
                                                                                false,
                                                                                x.VERF_CREATED_DATE
                                                                               )
                                                       ).OrderByDescending(x => x.Id)
                                                        .ToList();

            foreach (var udalost in recordsWithouteventWithDESC)
            {
                SelectionResult.Add(udalost);
            }

            List<VersionFlagEntity> recordsWithouteventWithoutDESC = new List<VersionFlagEntity>();

            recordsWithouteventWithoutDESC = versionsFlagFromDB.Where(udalost => udalost.VERF_FILE == null)
                                                               .Where(description => description.VERF_DESC == null)
                                                .Select(x => new VersionFlagEntity(x.VERF_ID,
                                                                                x.VERF_FLAG,
                                                                                x.VERF_DESC,
                                                                                x.VERF_DATE,
                                                                                false,
                                                                                x.VERF_CREATED_DATE
                                                                               )
                                                       ).OrderByDescending(x => x.Id)
                                                        .ToList();

            foreach (var udalost in recordsWithouteventWithoutDESC)
            {
                SelectionResult.Add(udalost);
            }

            SelectionResult.OrderByDescending(x => x.Id);

        }

        // naplní VersionFlagEntity pouze s flagId, versionLogId a log file
        public void GetLogFile(long versionFlagId)
        {
            VERSION_FLAG flagEventFromDb = dbRepository.GetFlagEvent(versionFlagId);

            VersionFlagEntity = new VersionFlagEntity(flagEventFromDb.VERF_ID,
                                                      flagEventFromDb.VERF_VER_ID,
                                                      flagEventFromDb.VERF_FILE.Replace("\n","<br/>")
                                                     );
        }
    }
}