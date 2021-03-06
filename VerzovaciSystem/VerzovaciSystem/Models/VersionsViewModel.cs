﻿using System.Collections.Generic;
using System;
using VerzovaciSystem.Models.Entities;
using VerzovaciSystemDB;
using System.Web.Mvc;
using System.Linq;
using VerzovaciSystem.Models.Interfaces;

namespace VerzovaciSystem.Models
{
    public class VersionsViewModel: IVersionsViewModel
    {
        DbRepository dbRepository = new DbRepository();

        //Autofac
        //private readonly IDbRepository dbRepository;

        // VYHLEDÁVACÍ MASKA
        // Pro labely
        public SelectionMaskOutputEntity SelectionMaskOutputEntity { get; private set; }
        // Pro výsledky vyhledání
        public List<SelectionMaskOutputEntity> SelectionResult { get; private set; }

        // SEZNAM VERZÍ
        // Pro labely a verzi s všemi údaji z VERSION_LOG
        public VersionEntity Version { get;  set; }

        // pro DropDownList výběru template pro novou verzi
        public List<TemplateVersionsSelectListItem> TemplateVersions { get; set; }

        // pro DropDownList výběru společnosti pro novou verzi
        public List<SelectListItem> Companies { get; private set; }

        // pro uložení hodnoty z DropDownList výběru template pro novou verzi
        public long TemplateVersionId { get; set; }

        //Autofac
        //public VersionsViewModel(IDbRepository iDbRepository)
        //{
        //    dbRepository = iDbRepository;
        //}

        public VersionsViewModel()
        { }

        //Najde verzi z VERSION_LOG
        public void GetVersion(long idVersion)
        {
            VERSION_LOG versionFromDB = new VERSION_LOG();
            versionFromDB = dbRepository.GetVersion(idVersion);

            bool isSqlData = false; bool isSqlDataCheck = false;

            if (versionFromDB.VER_SQL_DATA != null)
                isSqlData = true;

            if (versionFromDB.VER_SQL_DATA_CHECK != null)
                isSqlDataCheck = true;

            Version = new VersionEntity(versionFromDB.VER_ID,
                                        versionFromDB.VER_NAME,
                                        versionFromDB.VER_COMPANY,
                                        versionFromDB.VER_SOURCE_PATH,
                                        isSqlData,
                                        versionFromDB.VER_CONFIG,
                                        versionFromDB.VER_DATETIME,
                                        versionFromDB.VER_LOG_USER,
                                        versionFromDB.VER_LOG_DATE,
                                        versionFromDB.VER_CREATED_DATE,
                                        versionFromDB.VER_CREATED_USER,
                                        versionFromDB.VER_LOCK_FLAG,
                                        versionFromDB.VER_DELAY,
                                        isSqlDataCheck,
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

        // naplní Version daty z db VER_SQL_Data
        public void GetSqlData(long idVersion)
        {
            VERSION_LOG versionFromDB = new VERSION_LOG();
            versionFromDB = dbRepository.GetVersion(idVersion);

            Version = new VersionEntity(versionFromDB.VER_ID,
                                        versionFromDB.VER_SQL_DATA.Replace("\n","<br/>"), 
                                        null);
        }

        // naplní Version daty z db VER_SQL_Data_Check
        public void GetSqlDataCheck(long idVersion)
        {
            VERSION_LOG versionFromDB = new VERSION_LOG();
            versionFromDB = dbRepository.GetVersion(idVersion);

            Version = new VersionEntity(versionFromDB.VER_ID, 
                                        null, 
                                        versionFromDB.VER_SQL_DATA_CHECK.Replace("\n","<br/>")
                                       );
        }

        // odstraní verzi z tabulky VERSION_LOG
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
            versionToDb.VER_LOCK_FLAG = versionEntity.LogFlagString;
            versionToDb.VER_DELAY = versionEntity.Delay;
            versionToDb.VER_SQL_DATA_CHECK = versionEntity.SqlDataCheck;
            versionToDb.VER_DELETED = versionEntity.DeletedString;
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

        // najde všechny template do DropDownListu pro nové verze z V_VERSION_LOG_TEMPLATE
        public void GetTemplateVersionsAndCompanies()
        {
            // Template versions:
            List<V_VERSION_LOG_TEMPLATE> templateVersionsFromDb = dbRepository.GetTemplateVersions();

            if (TemplateVersions == null)
                TemplateVersions = new List<TemplateVersionsSelectListItem>();

            TemplateVersions.Clear();

            TemplateVersions.Add(new TemplateVersionsSelectListItem { Text = "option", Value = 0 });

            foreach (V_VERSION_LOG_TEMPLATE templateVersion in templateVersionsFromDb)
            {
                TemplateVersions.Add(new TemplateVersionsSelectListItem { Text = $"{templateVersion.VER_ID.ToString()} {templateVersion.VER_NAME}",
                                                                          Value =templateVersion.VER_ID
                                                                        } 
                                    );
            }

            // Companies:
            if (Companies == null)
            {
            List<VERSION_COMPANY> companiesFromDB = dbRepository.GetCompanies();
            List<CompanyEntity> companies = companiesFromDB.Select(x => new CompanyEntity(HelpsMethods.GetIntFromDecimal(x.VER_COMPANY_ID), x.VER_COMPANY)).OrderBy(company => company.Name).ToList();
                Companies = new List<SelectListItem>();
                Companies.Add(new SelectListItem { Text = "option", Value = null });
                foreach(var company in companies)
                {
                    Companies.Add(new SelectListItem { Text = company.Name, Value = company.Name });
                }
            }
            
        }

        // najde template pro novou verzi z V_VERSION_LOG_TEMPLATE
        public void GetTemplateVersion (long idVersion)
        {
            V_VERSION_LOG_TEMPLATE templateVersionFromDb = dbRepository.GetTemplateVersion(idVersion);
            Version = new VersionEntity(templateVersionFromDb.VER_ID,
                                        templateVersionFromDb.VER_NAME,
                                        templateVersionFromDb.VER_COMPANY,
                                        templateVersionFromDb.VER_SOURCE_PATH,
                                        templateVersionFromDb.VER_SQL_DATA,
                                        templateVersionFromDb.VER_CONFIG,
                                        templateVersionFromDb.VER_DATETIME,
                                        templateVersionFromDb.VER_LOG_USER,
                                        templateVersionFromDb.VER_LOG_DATE,
                                        DateTime.Now,
                                        $"{Environment.MachineName}/{Environment.UserName}",
                                        templateVersionFromDb.VER_LOCK_FLAG,
                                        templateVersionFromDb.VER_DELAY,
                                        templateVersionFromDb.VER_SQL_DATA_CHECK,
                                        templateVersionFromDb.VER_DELETED,
                                        templateVersionFromDb.VER_MAIL,
                                        templateVersionFromDb.VER_MAIL_MESSAGE,
                                        templateVersionFromDb.VER_MODE,
                                        templateVersionFromDb.VER_GROUP,
                                        templateVersionFromDb.VER_LOCK_FLAG,
                                        templateVersionFromDb.VER_FILE_FOLDER_TO_DELETE,
                                        templateVersionFromDb.VER_MAIL_MESSAGE,
                                        templateVersionFromDb.VER_MAIL_FLAG
                                       );

        }
        // zašle novou verzi k uložení do db
        public string AddVersion(VersionEntity versionEntity, ref long versionId)
        {
            VERSION_LOG versionToDb = CompleteDbModel(versionEntity);

            return dbRepository.AddVersion(versionToDb,ref versionId);
        }
    }
}