using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models
{
    public static class HelpsMethods
    {
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