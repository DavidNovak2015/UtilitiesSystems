using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VerzovaciSystem.Models.Entities
{
    public class VersionFlagEntity
    {
        public long Id { get; private set; }

        [Display(Name ="Id z VERSION_LOG")]
        public long VersionLogId { get; private set; }

        [Display(Name ="Název flag")]
        public string Flag { get; private set; }

        [Display(Name ="Popisek nebo název souboru")]
        public string Description { get; private set; }

        public DateTime Date { get; private set; }

        public bool IsFile { get; private set; }

        [Display(Name = "log soubor")]
        public string File { get; private set; }

        [Display(Name ="Vytvořeno")]
        public DateTime Created { get; private set; }

        // pro zobrazení všech událostí z VERSION_FLAG bez log souboru
        public VersionFlagEntity(long iD, string flag, string description, DateTime date, bool isFile,DateTime created)
        {
            Id = iD;
            Flag = flag;
            Description = description;
            Date = date;
            IsFile = isFile;
            Created = created;
        }

        //Pro zobrazení versionLogId v nadpisu GetFlagVersions view 
        public VersionFlagEntity(long versionLogId)
        {
            VersionLogId = versionLogId;
        }

        // pro zobrazení obsahu Log souboru patřící k jedné události z VERSION_FLAG.Id
        public VersionFlagEntity(long id,long versionLogId, string file)
        {
            Id = id;
            VersionLogId = versionLogId;
            File = file;
        }
    }
}