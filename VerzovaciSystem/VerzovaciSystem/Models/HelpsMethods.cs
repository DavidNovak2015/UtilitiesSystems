using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models
{
    public static class HelpsMethods
    {
        public static int GetIntValue(int? nullableInt)
        {
            if (!nullableInt.HasValue)
                throw new InvalidOperationException($"{nameof(nullableInt)} is empty");

            return nullableInt.Value;
        }
    }
}