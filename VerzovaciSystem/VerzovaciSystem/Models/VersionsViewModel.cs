using System.Collections.Generic;
using System.Linq;
using VerzovaciSystem.Models.Entities;
using VerzovaciSystemDB;

namespace VerzovaciSystem.Models
{
    public class VersionsViewModel
    {
        DbRepository dbRepository = new DbRepository();

        // VYHLEDÁVACÍ MASKA
        // Pro labely
        public SelectionMaskOutputEntity SelectionMaskOutputEntity { get; private set; }
        // Pro výsledky vyhledání
        public List<SelectionMaskOutputEntity> SelectionResult { get; private set; }

        // SEZNAM VERZÍ
        // Pro labely a verzi s všemi údaji z VERSION_LOG
        public VersionEntity Version { get; private set; }        

        // Versions TRUNC(VER_DATETIME) <= TRUNC(SYSDATE) 
        public void GetTodayVersions()
        {
            SelectionMaskOutputEntity = new SelectionMaskOutputEntity();

            List<V_VERSION_LIST2> versionsFromDB = dbRepository.GetAllRecordsFromV_VERSION_LIST2();

            SelectionResult = new List<SelectionMaskOutputEntity>();

            SelectionResult = versionsFromDB.Select(x => new SelectionMaskOutputEntity(x.VER_ID,
                                                                                       x.VER_COMPANY,
                                                                                       x.VER_GROUP,
                                                                                       x.VER_DATETIME,
                                                                                       x.VER_CREATED_DATE,
                                                                                       x.VER_CREATED_USER,
                                                                                       x.STATUS,
                                                                                       x.VER_COMPANY_TYPE
                                                                                      )
                                                   ).ToList(); 
        }

        //Najde verzi z VERSION_LOG
        public void GetVersion(long idVersion)
        {
            VERSION_LOG versionFromDB = new VERSION_LOG();
            versionFromDB = dbRepository.GetVersion(idVersion);
            Version = new VersionEntity(versionFromDB.VER_ID,
                                        versionFromDB.VER_NAME,
                                        versionFromDB.VER_COMPANY,
                                        versionFromDB.VER_SOURCE_PATH,
                                        versionFromDB.VER_SQL_DATA,
                                        versionFromDB.VER_CONFIG,
                                        versionFromDB.VER_DATETIME,
                                        versionFromDB.VER_LOG_USER,
                                        versionFromDB.VER_LOG_DATE,
                                        versionFromDB.VER_CREATED_DATE,
                                        versionFromDB.VER_CREATED_USER,
                                        versionFromDB.VER_LOCK_FLAG,
                                        versionFromDB.VER_DELAY,
                                        versionFromDB.VER_SQL_DATA_CHECK,
                                        versionFromDB.VER_DELETED,
                                        versionFromDB.VER_MAIL,
                                        versionFromDB.VER_MAIL_MESSAGE,
                                        versionFromDB.VER_MODE,
                                        versionFromDB.VER_GROUP,
                                        versionFromDB.VER_LOCK_FLAG,
                                        versionFromDB.VER_FILE_FOLDER_TO_DELETE,
                                        versionFromDB.VER_MAIL_MESSAGE,
                                        versionFromDB.VER_MAIL_FLAG
                                       );
        } 
    }
}