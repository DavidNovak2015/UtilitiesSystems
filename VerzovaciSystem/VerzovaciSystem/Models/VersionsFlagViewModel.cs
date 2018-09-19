using System.Collections.Generic;
using System.Linq;
using VerzovaciSystem.Models.Entities;
using VerzovaciSystemDB;

namespace VerzovaciSystem.Models
{
    public class VersionsFlagViewModel
    {
        DbRepository dbRepository = new DbRepository();

        // pro labely
        public VersionFlagEntity VersionFlagEntity { get; private set; }

        // pro výběr z VERSION_FLAG podle Id z VERSION_LOG
        public List<VersionFlagEntity> SelectionResult { get; private set; }

        public VersionsFlagViewModel(long versionLogId)
        {
            VersionFlagEntity = new VersionFlagEntity();

            List<VERSION_FLAG> versionsFlagFromDB = dbRepository.GetAllRecordsFromVERSION_FLAG(versionLogId);
            SelectionResult = versionsFlagFromDB.Select(x => new VersionFlagEntity(x.VERF_ID,
                                                                                   x.VERF_VER_ID,
                                                                                   x.VERF_FLAG,
                                                                                   x.VERF_DESC,
                                                                                   x.VERF_DATE,
                                                                                   x.VERF_CREATED_DATE
                                                                                  )
                                                       ).OrderByDescending(x => x.Id)
                                                        .ToList();
        }

        // naplní VersionFlagEntity pouze s flagId, versionLogId a log file
        public void GetLogFile(long versionFlagId)
        {

        }
    }
}