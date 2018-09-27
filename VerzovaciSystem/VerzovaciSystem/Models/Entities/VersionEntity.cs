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

        [Display(Name ="Začalo finální stahování")]
        [StringLength(1, ErrorMessage = "Překročen limit 1 znak")]
        [Required(ErrorMessage = "Povinné pole")]
        public string LogFlag { get;  set; }

        [Display(Name ="Kolik minut bude trvat aktualizace, ale i jak dlouho se čeká na ukončení procesu ...")]
        [Range(1,999,ErrorMessage ="Hodnota musí být mezi 1 a 999")]
        [Required(ErrorMessage = "Povinné pole")]
        public byte Delay { get;  set; }

        [Display(Name ="Kontrolní SQL")]
        public string SqlDataCheck { get;  set; }

        [Display(Name = "Smazáno")]
        [StringLength(1, ErrorMessage = "Překročen limit 1 znak")]
        [Required(ErrorMessage = "Povinné pole")]
        public string Deleted { get;  set; }

        [Display(Name = "Email")]
        public string Mail { get;  set; }

        [Display(Name = "Zpráva uživatele")]
        public string Message { get;  set; }

        [Display(Name = "C-kopírovat složku Client\n P-clear conn. pool\n R-refresh catalogs\n T-test\n S-restart serveru")]
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

        public VersionEntity(long iD, string name, string company, string sourcePath, string sqlData, string config, DateTime date, string logUser, DateTime? logDate, DateTime created, string user, string logFlag, byte delay, string sqlDataCheck, string deleted, string mail, string message, string mode, string group, string flag, string fileFolderToDelete, string mailMessage, string mailFlag)
            :base(iD,company, date, created,user, group)
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
            LogFlag = logFlag;
            Delay = delay;
            SqlDataCheck = sqlDataCheck;
            Deleted = deleted;
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