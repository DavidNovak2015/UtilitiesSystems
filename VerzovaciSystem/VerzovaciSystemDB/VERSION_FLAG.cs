//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VerzovaciSystemDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class VERSION_FLAG
    {
        public long VERF_ID { get; set; }
        public long VERF_VER_ID { get; set; }
        public string VERF_FLAG { get; set; }
        public string VERF_DESC { get; set; }
        public System.DateTime VERF_DATE { get; set; }
        public string VERF_FILE { get; set; }
        public System.DateTime VERF_CREATED_DATE { get; set; }
    
        public virtual VERSION_LOG VERSION_LOG { get; set; }
    }
}