 using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Objects;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.EntityFramework;
using System.Data.SqlClient;

namespace VerzovaciSystemDB
{
    public class DbRepository
    {
        private const string oracleConnectionString= "User Id=USYSVER;Password=verze;Data Source=localhost:1521/XE";
        // pro výsledek metod
        private string result= ""; 

        // vrátí další neobsazené pořadové číslo pro nový záznam určité tabulky                                GENERALIZOVANÉ METODY
        private int GetNextIdNumberForDbTable(string tabelName, string columnIdName)
        {
            try
            {
                using (OracleConnection accessToDB = new OracleConnection(oracleConnectionString))
                {
                    accessToDB.Open();
                    using (OracleCommand command = new OracleCommand($"SELECT MAX({columnIdName})+1 FROM {tabelName}", accessToDB))
                    {
                        string nextIdFromDB = command.ExecuteScalar().ToString();
                        int nextId = 0;
                        if (!(Int32.TryParse(nextIdFromDB, out nextId)))
                            return 5555;

                        else return nextId;
                    }
                }
            }
            catch 
            {
                return 5555;
            }
        }

        // Nahradí příslušný DB View novým výběrem
        private string ReplaceDbView(string cmdCommand)
        {
            try
            {
                using (OracleConnection accessToDB = new OracleConnection(oracleConnectionString))
                {
                    accessToDB.Open();
                    using (OracleCommand command = new OracleCommand(cmdCommand, accessToDB))
                    {
                        command.ExecuteNonQuery();
                    }
                    return result = String.Empty;
                }
            }
            catch (Exception ex)
            {
                return result = $"Chyba. Popis chyby: \n\n {ex.Message.ToString()}";
            }
        }

        // VYHLEDÁVACÍ MASKA                                                                                        VYHLEDÁVACÍ MASKA

        // Pro zobrazení Vyhledávací masky + GetCompanies() v ČÍSELNÍKY: VERSION_COMPANY 
        public List<EX_COMPANY_TYPE> GetCompanyTypes()
        {
            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                {
                    return accessToDB.EX_COMPANY_TYPE.ToList();
                }
            }
            catch (Exception ex)
            {
                List<EX_COMPANY_TYPE> error = new List<EX_COMPANY_TYPE>();
                error.Add(new EX_COMPANY_TYPE { EX_COMPANY_TYPE1 = ex.Message.ToString() });
                return error;
            }
        }

        // před vyhledáním dle parametrů Vyhledávací masky vloží do V_VERSION_LIST1 výběr dat z VERSION_LOG
        private string ReplaceDbViewV_VERSION_LIST1()
        {
            string cmdCommand = "CREATE OR REPLACE VIEW V_VERSION_LIST1 AS SELECT VER_ID, VERSION_LOG.VER_COMPANY, VERSION_COMPANY.VER_COMPANY_TYPE, VER_GROUP, VER_DATETIME, VER_CREATED_DATE, VER_CREATED_USER, CASE WHEN ver_deleted = 'A' THEN 'ZRUŠENO' WHEN VER_DATETIME < SYSDATE AND  (0 = (SELECT COUNT(*) FROM VERSION_FLAG WHERE VERF_VER_ID=VER_ID)) THEN 'ČEKÁ' WHEN VER_DATETIME < SYSDATE AND  (0 < (SELECT COUNT(*) FROM VERSION_FLAG WHERE VERF_VER_ID=VER_ID)) THEN 'PROBÍHÁ PŘÍPRAVA' WHEN VER_DATETIME > SYSDATE AND  (0 = (SELECT COUNT(*) FROM VERSION_FLAG WHERE VERF_VER_ID=VER_ID AND VERF_desc LIKE '%Spusteni serveru a poolu OK%')) THEN 'PROBÍHÁ' WHEN VER_DATETIME > SYSDATE AND  (0 = (SELECT COUNT(*) FROM VERSION_FLAG WHERE VERF_VER_ID=VER_ID AND VERF_desc LIKE '%Spusteni serveru a poolu OK%')) THEN 'HOTOVO' ELSE  '?' END AS STATUS FROM VERSION_LOG LEFT JOIN VERSION_COMPANY ON VERSION_COMPANY.VER_COMPANY=VERSION_LOG.VER_COMPANY";
            result = ReplaceDbView(cmdCommand);
            return result;
        }

        // pro výsledky hledání dle parametrů vyhledávací masky
        public List<V_VERSION_LIST1> GetAllRecordsFromV_VERSION_LIST1()
        {
            result = ReplaceDbViewV_VERSION_LIST1();
            List<V_VERSION_LIST1> error = new List<V_VERSION_LIST1>(); V_VERSION_LIST1 descriptionError = new V_VERSION_LIST1();

            if (result != String.Empty)
            {
                descriptionError.VER_COMPANY = result;
                error.Add(descriptionError);
                return error;
            }
            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                {
                    return accessToDB.V_VERSION_LIST1.ToList();
                }
            }
            catch (Exception ex)
            {
                error.Clear();
                descriptionError.VER_COMPANY = $"Požadavek NEBYL proveden. Popis chyby:\n\n {ex.Message.ToString()} ";
                error.Add(descriptionError);
                return error;
            }
        }

        // VERZE-dnešní                                                                                                    VERZE-dnešní

        // před načtením dnešních verzí - z V_VERSION_LIST1 vyselektuje dnešní verze
        public string ReplaceDbViewV_VERSION_LIST2()
        {
            string cmdCommand = "CREATE OR REPLACE VIEW V_VERSION_LIST2 AS SELECT VER_ID,VER_COMPANY,VER_GROUP,VER_DATETIME,VER_CREATED_DATE,VER_CREATED_USER,STATUS,VER_COMPANY_TYPE  FROM V_VERSION_LIST1 WHERE TRUNC(VER_DATETIME) >= '30.05.2018'";
            result = ReplaceDbView(cmdCommand);
            return result;
        }

        // pro načtení seznamu dnešních verzí po zapnutí aplikace
        public List<V_VERSION_LIST2>GetAllRecordsFromV_VERSION_LIST2()
        {
            result = ReplaceDbViewV_VERSION_LIST1();
            string result2 = ReplaceDbViewV_VERSION_LIST2();
            List<V_VERSION_LIST2> error = new List<V_VERSION_LIST2>(); V_VERSION_LIST2 descriptionError = new V_VERSION_LIST2();

            if ( (result != String.Empty) || (result2 != String.Empty) )
            {
                descriptionError.VER_COMPANY = result;
                error.Add(descriptionError);
                return error;
            }
            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                {
                    return accessToDB.V_VERSION_LIST2.ToList();
                }
            }
            catch (Exception ex)
            {
                error.Clear();
                descriptionError.VER_COMPANY = $"Požadavek NEBYL proveden. Popis chyby:\n\n {ex.Message.ToString()} ";
                error.Add(descriptionError);
                return error;
            }
        }

        //VERZE z VERSION_LOG-kompletní data:                                                                     VERZE z VERSION_LOG-komplet                                                                                                    

        // Nalezení verze pro její aktualizaci nebo odstranění z tabulky VERSION_LOG
        public VERSION_LOG GetVersion(long idVersion)
        {
            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                {
                    return accessToDB.VERSION_LOG.Where(x => x.VER_ID == idVersion).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                VERSION_LOG error = new VERSION_LOG();
                error.VER_MESSAGE = ex.Message.ToString();
                return error;
            }
        }


        //VERZE z VERSION_FLAG                                                                                   VERZE z VERSION_FLAG

        // Zobrazení záznamu verze z VERSION_FLAG tabulky
        public List<VERSION_FLAG> GetAllRecordsFromVERSION_FLAG(long versionLogId)
        {
            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                {
                    return accessToDB.VERSION_FLAG.Where(dbVersionLogId => dbVersionLogId.VERF_VER_ID == versionLogId).ToList();
                }
            }
            catch(Exception ex)
            {
                List<VERSION_FLAG> error = new List<VERSION_FLAG>();VERSION_FLAG descriptionError = new VERSION_FLAG();
                descriptionError.VERF_DESC = ex.Message.ToString();
                error.Add(descriptionError);
                return error;
            }
        }

        // ČÍSELNÍKY: VERSION_COMPANY                                                                            ČÍSELNÍKY: VERSION_COMPANY

        // také pro Vyhledávací maska - vrátí seznam společností
        public List<VERSION_COMPANY> GetCompanies()
        {
            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                {
                    return accessToDB.VERSION_COMPANY.ToList();
                }
            }
            catch(Exception ex)
            {
                List<VERSION_COMPANY> error = new List<VERSION_COMPANY>();
                error.Add(new VERSION_COMPANY { VER_COMPANY_DESC = ex.InnerException.Message.ToString() });
                return error;
            }
        }

        // Přidání záznamu do VERSION_COMPANY
        public string AddCompany(VERSION_COMPANY companyToDB)
        {
            companyToDB.VER_COMPANY_ID = GetNextIdNumberForDbTable("VERSION_COMPANY", "VER_COMPANY_ID");
            if (companyToDB.VER_COMPANY_ID == 5555)
                return result = "Metoda \"GetLastIdNumberFromVersionCompany\" vrátila chybu";

            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                    {
                    accessToDB.VERSION_COMPANY.Add(companyToDB);
                    accessToDB.SaveChanges();
                    return result = "Požadavek byl proveden";
                    }
            }
            catch (Exception ex)
            {
                return result = $"Požadavek NEBYL proveden. Popis chyby:\n {ex.Message.ToString()}";
            }
        }

        // Nalezení záznamu pro výmaz nebo změnu z VERSION_COMPANY
        public VERSION_COMPANY GetCompanyForDeletion (int idCompany)
        {
            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                {
                    return accessToDB.VERSION_COMPANY.Where(x => x.VER_COMPANY_ID == idCompany).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                VERSION_COMPANY error = new VERSION_COMPANY();
                error.VER_COMPANY_DESC = ex.Message.ToString();
                return error;
            } 
        }

        // Vymazání záznamu z VERSION_COMPANY
        public string DeleteCompany(VERSION_COMPANY companyForDeletion)
        {
            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                {
                    accessToDB.Entry(companyForDeletion).State = System.Data.Entity.EntityState.Deleted;
                    accessToDB.SaveChanges();
                    return result = "Požadavek byl proveden";
                }
            }
            catch (Exception ex)
            {
                return result = $"Požadavek NEBYL proveden.Popis chyby:\n\n { ex.Message.ToString()} ";
            }
        }

        // Aktualizace záznamu v VERSION_COMPANY
        public string ChangeCompany(VERSION_COMPANY companyForChange)
        {
            try
            {
                using (OracleConnectionString accessToDB = new OracleConnectionString())
                {
                    accessToDB.Entry(companyForChange).State = System.Data.Entity.EntityState.Modified;
                    accessToDB.SaveChanges();
                    return result = "Požadavek byl proveden";
                }
            }
            catch (Exception ex)
            {
                return result = $"Požadavek NEBYL proveden.Popis chyby:\n\n { ex.Message.ToString()} ";
            }
        }


    }
}

