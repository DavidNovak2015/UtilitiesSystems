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

        public List<SelectListItem> CompaniesWithGroups { get; private set; }

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
            List<V_COMPANY_GROUP> companiesWithGroupsFromDB = dbRepository.GetCompaniesWithGroups();

            List<CompanyTypeEntity> companyTypes = companyTypesFromDB.Select(x => new CompanyTypeEntity(x.EX_COMPANY_TYPE1, x.EX_DESC)).ToList();
            List<CompanyEntity> companies = companiesFromDB.Select(x => new CompanyEntity(HelpsMethods.GetIntFromDecimal(x.VER_COMPANY_ID),
                                                                                          x.VER_COMPANY)).OrderBy(company => company.Name)                                                                                          
                                                           .ToList();

            CompanyTypes = new List<SelectListItem>();
            Companies = new List<SelectListItem>();
            CompaniesWithGroups = new List<SelectListItem>();
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

            CompaniesWithGroups.Add(new SelectListItem { Text = "option", Value = null });
            foreach (var companyWithGroup in companiesWithGroupsFromDB)
            {
                if (companyWithGroup.VER_GROUP != null)
                {
                    CompaniesWithGroups.Add(new SelectListItem { Text = $"{companyWithGroup.VER_COMPANY}, {companyWithGroup.VER_GROUP}", Value= $"{companyWithGroup.VER_COMPANY },{companyWithGroup.VER_GROUP }" });
                }
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
            recordsFromDB.OrderByDescending(x => x.VER_ID);
            IEnumerable<V_VERSION_LIST1> temporaryRecords=recordsFromDB.OrderByDescending(x => x.VER_ID);

            // CompanyWithGroup

            if (selectionsparameters.CompanyWithGroup != null)
            {
                string[] pole = selectionsparameters.CompanyWithGroup.Split(',');
                string companyWithGroupCompany = pole[0];
                string companyWithGroupGroup = pole[1];

                temporaryRecords = recordsFromDB.Where(company => company.VER_COMPANY == companyWithGroupCompany)
                                                .Where(group => group.VER_GROUP == companyWithGroupGroup);
            }

            // Company a Group
            if ((selectionsparameters.Company != null) && (selectionsparameters.Group != null))
            {
                temporaryRecords = recordsFromDB.Where(company => company.VER_COMPANY== selectionsparameters.Company)
                                              .Where(group => group.VER_GROUP == selectionsparameters.Group);
            }
            if ((selectionsparameters.Company != null) && (selectionsparameters.Group == null))
            {
                temporaryRecords = recordsFromDB.Where(company => company.VER_COMPANY == selectionsparameters.Company);
            }
            if ((selectionsparameters.Company == null) && (selectionsparameters.Group != null))
            {
                temporaryRecords = recordsFromDB.Where(group => group.VER_GROUP == selectionsparameters.Group);
            }

            // Company type a Company
            if ( (selectionsparameters.CompanyTyp != null) && (selectionsparameters.Company !=null) )
            {
                temporaryRecords = recordsFromDB.Where(companyTyp => companyTyp.VER_COMPANY_TYPE == selectionsparameters.CompanyTyp)
                                              .Where(company => company.VER_COMPANY == selectionsparameters.Company);
            }
            if ((selectionsparameters.CompanyTyp != null) && (selectionsparameters.Company == null))
            {
                temporaryRecords = recordsFromDB.Where(companyTyp => companyTyp.VER_COMPANY_TYPE == selectionsparameters.CompanyTyp);
            }
            if ((selectionsparameters.CompanyTyp == null) && (selectionsparameters.Company != null))
            {
                temporaryRecords = temporaryRecords.Where(company => company.VER_COMPANY == selectionsparameters.Company);
            }

            // VersionDateFrom a VersionDateTo
            if ( (selectionsparameters.VersionDateFrom != DateTime.MinValue) && (selectionsparameters.VersionDateTo != DateTime.MinValue)) // otestováno
            {
                temporaryRecords = recordsFromDB.Where(versionDateFrom => versionDateFrom.VER_DATETIME >= selectionsparameters.VersionDateFrom)
                                              .Where(versionDateTo => versionDateTo.VER_DATETIME <= selectionsparameters.VersionDateTo);
            }
            if ( (selectionsparameters.VersionDateFrom != DateTime.MinValue) && (selectionsparameters.VersionDateTo == DateTime.MinValue) )// otestováno
            {
                temporaryRecords = recordsFromDB.Where(versiondateFrom => versiondateFrom.VER_DATETIME >= selectionsparameters.VersionDateFrom);
            }
            if ( (selectionsparameters.VersionDateTo !=DateTime.MinValue) && (selectionsparameters.VersionDateFrom==DateTime.MinValue) ) // otestováno
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

            // Id version
            if (selectionsparameters.Id != null)
            {
                temporaryRecords = recordsFromDB.Where(versionId => versionId.VER_ID == selectionsparameters.Id).ToList();
            }

            // vrátit výsledky bez smazaných verzí else včetně smazaných verzí
            if (!selectionsparameters.SearchInDeleted)
            {
                SelectionResult = temporaryRecords.Where(x => x.STATUS != "ZRUŠENO")
                                                  .Select(x => new SelectionMaskOutputEntity(x.VER_ID,
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
            else
            {
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
}