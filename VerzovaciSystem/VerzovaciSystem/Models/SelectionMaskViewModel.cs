using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VerzovaciSystemDB;
using VerzovaciSystem.Models.Entities;

namespace VerzovaciSystem.Models
{
    public class SelectionMaskViewModel
    {
        DbRepository dbRepository = new DbRepository();

        // popisky polí a uchování vybraných hodnot ve vyhledávací masce
        public SelectionMaskEntity SelectionMaskEntity { get; set; }

        public List<SelectListItem> CompanyTypes { get; private set; }

        public List<SelectListItem> Companies { get; private set; }

        //public List<SelectListItem> GlobalStatusChoice { get; private set; }

        // výsledek výběru z vyhledávací masky
        public List<SelectionMaskOutputEntity> SelectionResult { get; private set; }
        
        // popisky polí pro výsledek výběru z vyhledávací masky
        public SelectionMaskOutputEntity SelectionMaskOutputEntity { get; private set; }

        //pro zobrazení vyhledávací masky
        public void GetSelectionMask()
        {
            if (SelectionMaskEntity == null)
                SelectionMaskEntity = new SelectionMaskEntity();

            SelectionMaskEntity.VersionDateFrom = DateTime.Now.Date;
            List<EX_COMPANY_TYPE> companyTypesFromDB = dbRepository.GetCompanyTypes();
            List<VERSION_COMPANY> companiesFromDB = dbRepository.GetCompanies();

            List<CompanyTypeEntity> companyTypes = companyTypesFromDB.Select(x => new CompanyTypeEntity(x.EX_COMPANY_TYPE1, x.EX_DESC)).ToList();
            List<CompanyEntity> companies = companiesFromDB.Select(x => new CompanyEntity(HelpsMethods.GetIntFromDecimal(x.VER_COMPANY_ID), x.VER_COMPANY)).OrderBy(company => company.Name).ToList();
            
            CompanyTypes = new List<SelectListItem>();
            Companies = new List<SelectListItem>();
            //GlobalStatusChoice = new List<SelectListItem>();

            CompanyTypes.Add(new SelectListItem { Text = "option", Value = null });
            foreach (var companyType in companyTypes)
            {
                CompanyTypes.Add(new SelectListItem { Text=companyType.Description, Value=companyType.Type});
            }

            Companies.Add(new SelectListItem { Text = "option", Value = null });
            foreach (var company in companies)
            {
                Companies.Add(new SelectListItem { Text = company.Name, Value = company.Name });
            }

            //GlobalStatusChoice.Add(new SelectListItem { Text = "options", Value = null });
            //GlobalStatusChoice.Add(new SelectListItem { Text = "Silver", Value = "Silver" });
            //GlobalStatusChoice.Add(new SelectListItem { Text = "Gold", Value = "Gold" });
        }

        // najde dnešní verze po startu aplikace nebo odkazem v Layotu dle TRUNC(VER_DATETIME) <= TRUNC(SYSDATE)  
        public void GetTodayVersions()
        {
            if (SelectionMaskOutputEntity==null)
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
                                                   ).OrderByDescending(x => x.Id)
                                                    .ToList();
        }

        // Vrátí odpovídající záznamy dle vyhledávací masky vybrané z DB View V_VERSION_LIST1
        public void GetSelectedRecords(SelectionMaskEntity selectionsparameters)
        {
            SelectionMaskOutputEntity = new SelectionMaskOutputEntity();

            if (SelectionResult == null)
                SelectionResult = new List<SelectionMaskOutputEntity>();

            SelectionResult.Clear();

            List<V_VERSION_LIST1> recordsFromDB = dbRepository.GetAllRecordsFromV_VERSION_LIST1();

            IEnumerable<V_VERSION_LIST1> temporaryRecords = recordsFromDB.OrderByDescending(x => x.VER_ID);

            // Id version
            if (selectionsparameters.Id != long.MinValue)
            {
                temporaryRecords = recordsFromDB.Where(versionId => versionId.VER_ID == selectionsparameters.Id).ToList();
            }
            // Company type
            if (selectionsparameters.CompanyTyp != null)
            {
                temporaryRecords = recordsFromDB.Where(companyType => companyType.VER_COMPANY_TYPE == selectionsparameters.CompanyTyp);
            }

            // Company
            if (selectionsparameters.Company != null) // otestováno
            {
                 temporaryRecords = recordsFromDB.Where(company => company.VER_COMPANY == selectionsparameters.Company);
            }

            // VersionDateFrom a VersionDateTo
            if ( (selectionsparameters.VersionDateFrom != null) && (selectionsparameters.VersionDateTo != DateTime.MinValue)) // otestováno
            {
                temporaryRecords = recordsFromDB.Where(versionDateFrom => versionDateFrom.VER_DATETIME >= selectionsparameters.VersionDateFrom)
                                              .Where(versionDateTo => versionDateTo.VER_DATETIME <= selectionsparameters.VersionDateTo);
            }
            if ( (selectionsparameters.VersionDateFrom != null) && (selectionsparameters.VersionDateTo == DateTime.MinValue) )// otestováno
            {
                temporaryRecords = recordsFromDB.Where(versiondateFrom => versiondateFrom.VER_DATETIME >= selectionsparameters.VersionDateFrom);
            }
            if ( (selectionsparameters.VersionDateTo !=DateTime.MinValue) && (selectionsparameters.VersionDateFrom==null) ) // otestováno
            {
                temporaryRecords = recordsFromDB.Where(versiondateTo => versiondateTo.VER_DATETIME <= selectionsparameters.VersionDateTo);
            }

            // CreationDateFrom a CreationDateTo
            if ((selectionsparameters.CreationDateFrom != DateTime.MinValue) && (selectionsparameters.CreationDateTo != DateTime.MinValue)) // otestováno
            {
                temporaryRecords = recordsFromDB.Where(creationDateFrom => creationDateFrom.VER_CREATED_DATE >= selectionsparameters.CreationDateFrom)
                                                .Where(creationDateTo => creationDateTo.VER_CREATED_DATE <= selectionsparameters.CreationDateTo);
            }
            if ( (selectionsparameters.CreationDateFrom != DateTime.MinValue) && (selectionsparameters.CreationDateTo == DateTime.MinValue) )// otestováno
            {
                temporaryRecords = recordsFromDB.Where(creationDateFrom => creationDateFrom.VER_CREATED_DATE >= selectionsparameters.CreationDateFrom);
            }
            if ( (selectionsparameters.CreationDateTo != DateTime.MinValue) && (selectionsparameters.CreationDateFrom == null) )// otestováno
            {
                temporaryRecords = recordsFromDB.Where(creationDateTo => creationDateTo.VER_CREATED_DATE <= selectionsparameters.CreationDateTo);
            }

            SelectionResult = temporaryRecords.Select(x => new SelectionMaskOutputEntity(x.VER_ID,
                                                                                         x.VER_COMPANY,
                                                                                         x.VER_GROUP,
                                                                                         x.VER_DATETIME,
                                                                                         x.VER_CREATED_DATE,
                                                                                         x.VER_CREATED_USER,
                                                                                         x.STATUS,
                                                                                         x.VER_COMPANY_TYPE
                                                                                        )
                                                     ).OrderByDescending(x => x.Id)
                                                      .ToList();
        }
    }
}