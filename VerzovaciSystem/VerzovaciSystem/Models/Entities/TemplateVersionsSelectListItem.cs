using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerzovaciSystem.Models.Entities
{
    // pro DropDownList výběru template pro novou verzi
    public class TemplateVersionsSelectListItem
    {
        public string Text { get; set; }
        public long Value { get; set; }
    }
}