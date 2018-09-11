using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VerzovaciSystem.Models.Entities;
using VerzovaciSystemDB;

namespace VerzovaciSystem.Models
{
    public class VersionsViewModel
    {
        DbRepository dbRepository = new DbRepository();

        // Pro labely
        public SelectionMaskOutputEntity SelectionMaskOutputEntity { get; private set; }

        // Pro výsledky vyhledání
        public List<SelectionMaskOutputEntity> SelectionResult { get; private set; }

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
    }
}