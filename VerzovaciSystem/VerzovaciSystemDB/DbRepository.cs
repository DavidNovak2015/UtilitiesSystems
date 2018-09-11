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

        // pro AddCompany VERSION_COMPANY
        private int GetNextIdNumberFromVersionCompany()
        {
            try
            {
                using (OracleConnection accessToDB = new OracleConnection(oracleConnectionString))
                {
                    accessToDB.Open();
                    using (OracleCommand command = new OracleCommand("SELECT MAX(VER_COMPANY_ID)+1 FROM VERSION_COMPANY", accessToDB))
                    {
                        string maxIdFromDB = command.ExecuteScalar().ToString();
                        int maxId = 0;
                        if (!(Int32.TryParse(maxIdFromDB, out maxId)))
                            return 5555;

                        else return maxId;
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
        // před vyhledáním dle parametrů Vyhledávací masky
        private string ReplaceDbViewV_VERSION_LIST1 ()
        {
            string cmdCommand = "CREATE OR REPLACE VIEW V_VERSION_LIST1 AS SELECT VER_ID, VERSION_LOG.VER_COMPANY, VERSION_COMPANY.VER_COMPANY_TYPE, VER_GROUP, VER_DATETIME, VER_CREATED_DATE, VER_CREATED_USER, CASE WHEN ver_deleted = 'A' THEN 'ZRUŠENO' WHEN VER_DATETIME < SYSDATE AND  (0 = (SELECT COUNT(*) FROM VERSION_FLAG WHERE VERF_VER_ID=VER_ID)) THEN 'ČEKÁ' WHEN VER_DATETIME < SYSDATE AND  (0 < (SELECT COUNT(*) FROM VERSION_FLAG WHERE VERF_VER_ID=VER_ID)) THEN 'PROBÍHÁ PŘÍPRAVA' WHEN VER_DATETIME > SYSDATE AND  (0 = (SELECT COUNT(*) FROM VERSION_FLAG WHERE VERF_VER_ID=VER_ID AND VERF_desc LIKE '%Spusteni serveru a poolu OK%')) THEN 'PROBÍHÁ' WHEN VER_DATETIME > SYSDATE AND  (0 = (SELECT COUNT(*) FROM VERSION_FLAG WHERE VERF_VER_ID=VER_ID AND VERF_desc LIKE '%Spusteni serveru a poolu OK%')) THEN 'HOTOVO' ELSE  '?' END AS STATUS FROM VERSION_LOG LEFT JOIN VERSION_COMPANY ON VERSION_COMPANY.VER_COMPANY=VERSION_LOG.VER_COMPANY";
            result = ReplaceDbView(cmdCommand);
            return result;
        }

        // před načtením Distribuce verzí - verze  po půlnoci aktuálního dne
        public string ReplaceDbViewV_VERSION_LIST2()
        {
            string cmdCommand = "CREATE OR REPLACE VIEW V_VERSION_LIST2 AS SELECT VER_ID,VER_COMPANY,VER_GROUP,VER_DATETIME,VER_CREATED_DATE,VER_CREATED_USER,STATUS,VER_COMPANY_TYPE  FROM V_VERSION_LIST1 WHERE TRUNC(VER_DATETIME) >= '30.05.2018'";
            result = ReplaceDbView(cmdCommand);
            return result;
        }
        // VYHLEDÁVACÍ MASKA

        // Pro zobrazení Vyhledávací masky
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

        // pro načtení seznamu verzí po zapnutí aplikace
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
        // pro výsledky hledání dle parametrů vyhledávací masky
        public List<V_VERSION_LIST1> GetAllRecordsFromV_VERSION_LIST1()
        {
            result = ReplaceDbViewV_VERSION_LIST1();
            List<V_VERSION_LIST1> error = new List<V_VERSION_LIST1>(); V_VERSION_LIST1 descriptionError = new V_VERSION_LIST1();

            if (result !=String.Empty)
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

        // ČÍSELNÍKY: VERSION_COMPANY

        // také pro Vyhledávací maska
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
            companyToDB.VER_COMPANY_ID = GetNextIdNumberFromVersionCompany();
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

        // Aktualizace záznamu z VERSION_COMPANY přes EntityFramework - padá na db sloupci VER_COMPANY
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

