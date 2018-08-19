using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models.Entities
{
    public class SelectionMaskOutputEntity
    {
        public long Id { get; private set; }
        public string Company { get; private set; }
        public string Group { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime Created { get; private set; }
        public string User { get; private set; }
        public string Status { get; private set; }

        public SelectionMaskOutputEntity(long iD, string company, string group, DateTime date, DateTime created, string user, string status)
        {
            Id = iD;
            Company = company;
            Group = group;
            Date = date;
            Created = created;
            User = user;
            Status = status;
        }

        // pro popisky View SelectionMaskOutput
        public SelectionMaskOutputEntity()
        { }
        
    }
}