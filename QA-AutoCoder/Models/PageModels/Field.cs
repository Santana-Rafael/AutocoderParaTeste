using qa_auto_coder.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimeTemplate.Models
{
    public class Field
    {
        public string Name { get; set; }
        public string NameDisplayedInMibPage { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string DataFieldType { get; set; }
        public bool IsListColumnOnly { get; set; } = false;
        public bool IsRequired { get; set; } = false;
    }
}
