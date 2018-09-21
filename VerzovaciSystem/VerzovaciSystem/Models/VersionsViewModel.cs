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

        // zašle verzi k odstranění z db
        public string DeleteVersion(long idVersion)
        {
            return dbRepository.DeleteVersion(idVersion);
        }

        // zašle verzi k aktualizaci
        public string ChangeVersion(VersionEntity versionToChange)
        {
            VERSION_LOG versionToChangeDB = new VERSION_LOG();
            versionToChangeDB.VER_ID = versionToChange.Id;
            versionToChangeDB.VER_NAME = versionToChange.Name;
            versionToChangeDB.VER_COMPANY = versionToChange.Company;
            versionToChangeDB.VER_SOURCE_PATH = versionToChange.SourcePath;
            versionToChangeDB.VER_SQL_DATA = versionToChange.SqlData;
            versionToChangeDB.VER_CONFIG = versionToChange.Config;
            versionToChangeDB.VER_DATETIME = versionToChange.Date;
            versionToChangeDB.VER_LOG_USER = versionToChange.LogUser;
            versionToChangeDB.VER_LOG_DATE = versionToChange.LogDate;
            versionToChangeDB.VER_CREATED_DATE = versionToChange.Created;
            versionToChangeDB.VER_CREATED_USER = versionToChange.User;
            versionToChangeDB.VER_LOCK_FLAG = versionToChange.LogFlag;
            versionToChangeDB.VER_DELAY = versionToChange.Delay;
            versionToChangeDB.VER_SQL_DATA_CHECK = versionToChange.SqlDataCheck;
            versionToChangeDB.VER_DELETED = versionToChange.Deleted;
            versionToChangeDB.VER_MAIL = versionToChange.Mail;
            versionToChangeDB.VER_MESSAGE = versionToChange.Message;
            versionToChangeDB.VER_MODE = versionToChange.Mode;
            versionToChangeDB.VER_GROUP = versionToChange.Group;
            versionToChangeDB.VER_S_VER_FLAG = versionToChange.Flag;
            versionToChangeDB.VER_FILE_FOLDER_TO_DELETE = versionToChange.FileFolderToDelete;
            versionToChangeDB.VER_MAIL_MESSAGE = versionToChange.MailMessage;
            versionToChangeDB.VER_MAIL_FLAG = versionToChange.MailFlag;

            return dbRepository.ChangeVersion(versionToChangeDB);
        }
    }
}