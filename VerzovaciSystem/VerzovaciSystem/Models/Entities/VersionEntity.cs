using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models.Entities
{
    public class VersionEntity:SelectionMaskOutputEntity
    {
        public string Name { get; private set; }

        [Display(Name ="Cesta k souborům bin a client")]
        public string SourcePath { get; private set; }

        [Display(Name ="uprava.sql (není SQL file)")]
        public string SqlData { get; private set; }

        [Display(Name ="Catalogy")]
        public string Config { get; private set; }

        public string LogUser { get; private set; }

        public DateTime LogDate { get; private set; }

        [Display(Name ="Začalo finální stahování")]
        public string LogFlag { get; private set; }

        [Display(Name ="Kolik minut bude trvat aktualizace, ale i jak dlouho se čeká na ukončení procesu ...")]
        public byte Delay { get; private set; }

        [Display(Name ="Kontrolní SQL")]
        public string SqlDataCheck { get; private set; }

        public string Deleted { get; private set; }

        [Display(Name = "Email")]
        public string Mail { get; private set; }

        public string Message { get; private set; }

        [Display(Name = "C-kopírovat složku Client\n P-clear conn. pool\n R-refresh catalogs\n T-test\n S-restart serveru")]
        public string Mode { get; private set; }

        [Display(Name = "A-adresář podle ID verze\n X-adresář podle groupy")]
        public string Flag { get; private set; }

        [Display(Name = "Kontrolní SQL")]
        public string FileFolderToDelete { get; private set; }

        [Display(Name = "")]
        public string MailMessage { get; private set; }

        [Display(Name = "P-\n F-\n S-")]
        public string MailFlag { get; private set; }
    }
}