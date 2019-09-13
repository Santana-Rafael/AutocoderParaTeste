using RunTimeTemplate.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Models
{
    public class APIPropertieModel
    {
        private string _propertieName;

        public APIPropertieModel(string columnName, string propertieType)
        {
            this.ColumnName = columnName;
            this.PropertieType = propertieType;
            this._propertieName = ModelHelpers.ConvertToPascalCasePattern(ColumnName);
        }

        public string ColumnName { get; set; }
        public string PropertieType { get; set; }

        public string GetPropertie()
        {
            return $"           [Mib3BaseApiObjectNotation(\"{ColumnName}\")]\n" +
                   $"           public {PropertieType} {_propertieName} {{ get; set; }}\n\n";
        }

    }
}
