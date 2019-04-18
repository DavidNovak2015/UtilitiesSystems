using System;

namespace VerzovaciSystem.Models
{
    public static class HelpsMethods
    {
        // při načítání ID z db. tab VERSION_COMPANY převede na Int pro tranfer do objektu CompanyEntity
        public static int GetIntFromDecimal(decimal number)
        {
            try
            {
                return Convert.ToInt32(number);
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return 0;
            }
        }
    }
}