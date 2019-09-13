using RunTimeTemplate.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Models.APIModels
{
    public class APIFactoryModel
    {
        private string _auxString;
        private string _className;

        public APIFactoryModel(List<APIPropertieModel> propertieModels, string className)
        {
            foreach (var item in propertieModels)
            {
                Properties.Add(ModelHelpers.ConvertToPascalCasePattern(item.ColumnName));
            }

            _className = className;
        }

        public List<string> Properties { get; set; } = new List<string>();

        public string GenerateInit()
        {
            _auxString = $"var {_className.ToLower()} = new {_className}\n" +
                "            {\r\n";

            foreach (var item in Properties)
            {
                _auxString += $"                {item} = ,\n";
            }

            _auxString += "            };";

            return _auxString;
        }

    }   
}
