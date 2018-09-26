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
        public VersionEntity Version { get;  set; }        

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

        // naplní db model z viewModelu 
        private VERSION_LOG CompleteDbModel(VersionEntity versionEntity)
        {
            VERSION_LOG versionToDb = new VERSION_LOG();
            versionToDb.VER_ID = versionEntity.Id;
            versionToDb.VER_NAME = versionEntity.Name;
            versionToDb.VER_COMPANY = versionEntity.Company;
            versionToDb.VER_SOURCE_PATH = versionEntity.SourcePath;
            versionToDb.VER_SQL_DATA = versionEntity.SqlData;
            versionToDb.VER_CONFIG = versionEntity.Config;
            versionToDb.VER_DATETIME = versionEntity.Date;
            versionToDb.VER_LOG_USER = versionEntity.LogUser;
            versionToDb.VER_LOG_DATE = versionEntity.LogDate;
            versionToDb.VER_CREATED_DATE = versionEntity.Created;
            versionToDb.VER_CREATED_USER = versionEntity.User;
            versionToDb.VER_LOCK_FLAG = versionEntity.LogFlag;
            versionToDb.VER_DELAY = versionEntity.Delay;
            versionToDb.VER_SQL_DATA_CHECK = versionEntity.SqlDataCheck;
            versionToDb.VER_DELETED = versionEntity.Deleted;
            versionToDb.VER_MAIL = versionEntity.Mail;
            versionToDb.VER_MESSAGE = versionEntity.Message;
            versionToDb.VER_MODE = versionEntity.Mode;
            versionToDb.VER_GROUP = versionEntity.Group;
            versionToDb.VER_S_VER_FLAG = versionEntity.Flag;
            versionToDb.VER_FILE_FOLDER_TO_DELETE = versionEntity.FileFolderToDelete;
            versionToDb.VER_MAIL_MESSAGE = versionEntity.MailMessage;
            versionToDb.VER_MAIL_FLAG = versionEntity.MailFlag;

            return versionToDb;
        }

        // zašle verzi k aktualizaci
        public string ChangeVersion(VersionEntity versionToChange)
        {
            VERSION_LOG versionToDb = CompleteDbModel(versionToChange);
            
            return dbRepository.ChangeVersion(versionToDb);
        }

        // zašle novou verzi k uložení do db
        public string AddVersion(VersionEntity versionEntity)
        {
            VERSION_LOG versionToDb = CompleteDbModel(versionEntity);

            return dbRepository.AddVersion(versionToDb);
        }
    }
}