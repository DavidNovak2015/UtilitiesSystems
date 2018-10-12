using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VerzovaciSystem.Models.Entities
{
    public class VersionEntity:SelectionMaskOutputEntity
    {
        // VERSION_LOG
        [StringLength(100, ErrorMessage = "Překročen limit 100 znaků")]
        public string Name { get;  set; }

        [Display(Name ="Cesta k souborům bin a client")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Překročen limit 100 znaků")]
        public string SourcePath { get;  set; }

        [Display(Name = "SqlData")]
        public bool IsSqlData { get; set; }

        [Display(Name ="SqlData")]
        [DataType(DataType.MultilineText)]
        public string SqlData { get;  set; }

        [Display(Name ="Catalogy")]
        public string Config { get;  set; }

        [Display(Name = "Změnil")]
        [StringLength(100, ErrorMessage = "Překročen limit 100 znaků")]
        public string LogUser { get;  set; }

        [Display(Name = "Datum změny")]
        public DateTime? LogDate { get;  set; }

        [Display(Name = "Začalo finální stahování")]
        public bool LogFlagBool { get; set; }

        [Display(Name ="Začalo finální stahování")]
        public string LogFlagString { get;  set; }

        [Display(Name ="Délka verze")]
        [Range(1,999,ErrorMessage ="Hodnota musí být mezi 1 a 999")]
        [Required(ErrorMessage = "Povinné pole")]
        public byte Delay { get;  set; }

        [Display(Name = "Kontrolní SQL")]
        public bool IsSqlDataCheck { get; set; }

        [Display(Name ="Kontrolní SQL")]
        public string SqlDataCheck { get;  set; }

        [Display(Name = "Smazáno")]
        public bool DeletedBool { get; set; }

        [Display(Name = "Smazáno")]
        public string DeletedString { get; set; }

        [Display(Name = "Email")]
        public string Mail { get;  set; }

        [Display(Name = "Zpráva uživatele")]
        public string Message { get;  set; }

        [Display(Name = "Mode")]
        [StringLength(10, ErrorMessage = "Překročen limit 10 znaků")]
        public string Mode { get;  set; }

        [Display(Name = "A-adresář podle ID verze\n X-adresář podle groupy")]
        [StringLength(1, ErrorMessage = "Překročen limit 1 znak")]
        public string Flag { get;  set; }

        [Display(Name = "Smazat")]
        [DataType(DataType.MultilineText)]
        [StringLength(4000, ErrorMessage = "Překročen limit 4000 znaků")]
        public string FileFolderToDelete { get;  set; }

        [Display(Name = "Zpráva email")]
        [StringLength(200, ErrorMessage = "Překročen limit 200 znaků")]
        public string MailMessage { get;  set; }

        [Display(Name = "Email flag")]
        [StringLength(10, ErrorMessage = "Překročen limit 10 znaků")]
        public string MailFlag { get;  set; }

        // pro výpis verze s odkazem na SqlData a SqlDataCheck
        public VersionEntity(long iD, string name, string company, string sourcePath, bool isSqlData, string config, DateTime date, string logUser, DateTime? logDate, DateTime created, string user, string logFlag, byte delay, bool isSqlDataCheck, string deleted1, string mail, string message, string mode, string group, string flag, string fileFolderToDelete, string mailMessage, string mailFlag)
            :base(iD,company, date, created,user, group)
        {
            Id = iD;
            Name = name;
            Company = company;
            SourcePath = sourcePath;
            IsSqlData = isSqlData;
            Config = config;
            Date = date;
            LogUser = logUser;
            LogDate = logDate;
            Created = created;
            User = user;
            LogFlagString = logFlag;
            Delay = delay;
            IsSqlDataCheck = isSqlDataCheck;
            DeletedString = deleted1;
            Mail = mail;
            Message = message;
            Mode = mode;
            Group = group;
            Flag = flag;
            FileFolderToDelete = fileFolderToDelete;
            MailMessage = mailMessage;
            MailFlag = mailFlag;
        }

        // pro výpis verze včetně SqlData a SqlDataCheck pro změnu verze
        public VersionEntity(long iD, string name, string company, string sourcePath, string sqlData, string config, DateTime date, string logUser, DateTime? logDate, DateTime created, string user, string logFlag, byte delay, string sqlDataCheck, string deleted1, string mail, string message, string mode, string group, string flag, string fileFolderToDelete, string mailMessage, string mailFlag)
            : base(iD, company, date, created, user, group)
        {
            Id = iD;
            Name = name;
            Company = company;
            SourcePath = sourcePath;
            SqlData = SqlData;
            Config = config;
            Date = date;
            LogUser = logUser;
            LogDate = logDate;
            Created = created;
            User = user;
            LogFlagString = logFlag;
            Delay = delay;
            SqlDataCheck = SqlDataCheck;
            DeletedString = deleted1;
            Mail = mail;
            Message = message;
            Mode = mode;
            Group = group;
            Flag = flag;
            FileFolderToDelete = fileFolderToDelete;
            MailMessage = mailMessage;
            MailFlag = mailFlag;
        }
        
        // pro výpis SqlData a SqlDataCheck ve zvláštním pohledu 
        public VersionEntity(long id,string sqlData, string sqlDataCheck)
        {
            Id = id;
            SqlData = sqlData;
            SqlDataCheck = sqlDataCheck;
        }

        // pro předvyplnění některých políček do prázdného formuláře nové verze
        public VersionEntity(string user, DateTime created, DateTime date)
        {
            User = user;
            Created = created;
            Date = date;
        }

        // pro změnu verze
        public VersionEntity(long iD, string name, string company, string sourcePath, string sqlData, string config, DateTime date, string logUser, DateTime? logDate, DateTime created, string user, bool logFlag, byte delay, string sqlDataCheck, bool deletedBool, string mail, string message, string mode, string group, string flag, string fileFolderToDelete, string mailMessage, string mailFlag)
            : base(iD, company, date, created, user, group)
        {
            Id = iD;
            Name = name;
            Company = company;
            SourcePath = sourcePath;
            SqlData = sqlData;
            Config = config;
            Date = date;
            LogUser = logUser;
            LogDate = logDate;
            Created = created;
            User = user;
            LogFlagBool = logFlag;
            Delay = delay;
            SqlDataCheck = sqlDataCheck;
            DeletedBool = deletedBool;
            Mail = mail;
            Message = message;
            Mode = mode;
            Group = group;
            Flag = flag;
            FileFolderToDelete = fileFolderToDelete;
            MailMessage = mailMessage;
            MailFlag = mailFlag;
        }
        
        public VersionEntity()
        { }
    }
}