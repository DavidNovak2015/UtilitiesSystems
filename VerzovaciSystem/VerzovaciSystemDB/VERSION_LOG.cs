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
    
    public partial class VERSION_LOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VERSION_LOG()
        {
            this.VERSION_FLAG = new HashSet<VERSION_FLAG>();
        }
    
        public long VER_ID { get; set; }
        public string VER_NAME { get; set; }
        public string VER_COMPANY { get; set; }
        public string VER_SOURCE_PATH { get; set; }
        public string VER_SQL_DATA { get; set; }
        public string VER_CONFIG { get; set; }
        public System.DateTime VER_DATETIME { get; set; }
        public string VER_LOG_USER { get; set; }
        public Nullable<System.DateTime> VER_LOG_DATE { get; set; }
        public System.DateTime VER_CREATED_DATE { get; set; }
        public string VER_CREATED_USER { get; set; }
        public string VER_LOCK_FLAG { get; set; }
        public byte VER_DELAY { get; set; }
        public string VER_SQL_DATA_CHECK { get; set; }
        public string VER_DELETED { get; set; }
        public string VER_MAIL { get; set; }
        public string VER_MESSAGE { get; set; }
        public string VER_MODE { get; set; }
        public string VER_GROUP { get; set; }
        public string VER_S_VER_FLAG { get; set; }
        public string VER_FILE_FOLDER_TO_DELETE { get; set; }
        public string VER_MAIL_MESSAGE { get; set; }
        public string VER_MAIL_FLAG { get; set; }
    
        public virtual VERSION_COMPANY VERSION_COMPANY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VERSION_FLAG> VERSION_FLAG { get; set; }
    }
}
