using RunTimeTemplate.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimeTemplate.Models
{
    public class EditPageFieldsPropertieModel
    {

        public EditPageFieldsPropertieModel(Field field)
        {
            FieldId = field.Id;
            FieldName = ModelHelpers.ConvertToPrivateVariablePattern(field.Name);
        }

        public string FieldId { get; set; }
        public string FieldName { get; set; }

        public override string ToString()
        {
            return $"    [FindsBy(How = How.Id, Using = \"{FieldId}\")]\r\n" +
                   $"    private IWebElement {FieldName} {{ get; set; }}\r\n";
        }
        
    }
}
