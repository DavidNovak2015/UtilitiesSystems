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
        private const string oracleConnectionString= "metadata=res://*/Database.csdl|res://*/Database.ssdl|res://*/Database.msl;provider=Oracle.ManagedDataAccess.Client;provider connection string=&quot;DATA SOURCE=localhost:1521/XE;PASSWORD=verze;USER ID=USYSVER&quot";
        // pro výsledek metod
        private string result = "";

        // pro AddCompany VERSION_COMPANY
        private int GetLastIdNumberFromVersionCompany()
        {
            try
            {
                using (OracleConnection accessToDB = new OracleConnection(oracleConnectionString))
                {
                    accessToDB.Open();
                    using (OracleCommand command = new OracleCommand("select max(ver_company_id) from version_company"))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch
            {
                return 5555;
            }
        }
        // Vyhledávací maska
        public List<EX_COMPANY_TYPE> GetCompanyTypes()
        {
            try
            {
                using (EntityFramework accessToDB = new EntityFramework())
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

        // ČÍSELNÍKY: VERSION_COMPANY
        // také pro Vyhledávací maska
        public List<VERSION_COMPANY> GetCompanies()
        {
            try
            {
                using (EntityFramework accessToDB = new EntityFramework())
                {
                    return accessToDB.VERSION_COMPANY.ToList();
                }
            }
            catch(Exception ex)
            {
                List<VERSION_COMPANY> error = new List<VERSION_COMPANY>();
                error.Add(new VERSION_COMPANY { VER_COMPANY_DESC = ex.Message.ToString() });
                return error;
            }
        }

        public string AddCompany(VERSION_COMPANY companyToDB)
        {
            companyToDB.VER_COMPANY_ID = GetLastIdNumberFromVersionCompany();
            try
            {
                using (EntityFramework accessToDB = new EntityFramework())
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
        
    }
}

