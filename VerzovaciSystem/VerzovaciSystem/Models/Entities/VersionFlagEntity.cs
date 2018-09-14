using System;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name ="log soubor")]
        public string File { get; private set; }

        [Display(Name ="Vytvořeno")]
        public DateTime Created { get; private set; }

        public VersionFlagEntity(long iD, long versionLogId, string flag, string description, DateTime date, string file, DateTime created)
        {
            Id = iD;
            VersionLogId = versionLogId;
            Flag = flag;
            Description = description;
            Date = date;
            File = file;
            Created = created;
        }

        //Pro labely 
        public VersionFlagEntity()
        { }
    }
}