using RunTimeTemplate.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimeTemplate.Models
{
    public class EditPagePropertiesModel
    {
        public EditPagePropertiesModel(Field field)
        {
            ModelHelpers.ValidateFieldProperties(field);
            PropertieName = ModelHelpers.ConvertToPascalCasePattern(field.Name);
            FieldName = ModelHelpers.ConvertToPrivateVariablePattern(field.Name);
            Type = field.Type;
            DataFieldType = field.DataFieldType;
        }


        public string PropertieName { get; set; }
        public string FieldName { get; set; }
        public string Type { get; set; }
        public string DataFieldType { get; set; }

        public override string ToString()
        {
            return $"   public {Type} {PropertieName}\r\n" +
                    "   {\r\n " +
                    $"     get => Driver.Form.GetFormFieldValue({FieldName}, FieldType.{DataFieldType}).ToString();\r\n" +
                    $"      set => Driver.Form.SetFormFieldValue({FieldName}, value , FieldType.{DataFieldType});\r\n" +
                    "   }\r\n";
        }
        
        public string ToInt()
        {
            return $"   public {Type} {PropertieName}\r\n" +
                    "   {\r\n " +
                    $"     get => Driver.Form.GetFormFieldValue({FieldName}, FieldType.{DataFieldType}).ToInt();\r\n" +
                    $"      set => Driver.Form.SetFormFieldValue({FieldName}, value , FieldType.{DataFieldType});\r\n" +
                    "   }\r\n";
        }

        public string ToBoolean()
        {
            return $"   public {Type} {PropertieName}\r\n" +
                    "   {\r\n " +
                    $"     get => Convert.ToBoolean(Driver.Form.GetFormFieldValue({FieldName}, FieldType.{DataFieldType}).ToString());\r\n" +
                    $"      set => Driver.Form.SetFormFieldValue({FieldName}, value , FieldType.{DataFieldType});\r\n" +
                    "   }\r\n";
        }

        public string ToDateTime()
        {
            return $"   public {Type} {PropertieName}\r\n" +
                    "   {\r\n " +
                    $"     get => DateTime.Parse(Driver.Form.GetFormFieldValue({FieldName}, FieldType.{DataFieldType}).ToString());\r\n" +
                    $"      set => Driver.Form.SetFormFieldValue({FieldName}, value , FieldType.{DataFieldType});\r\n" +
                    "   }\r\n";
        }

        public string ToEnum()
        {
            return $"   public {Type} {PropertieName}\r\n" +
                    "   {\r\n " +
                    $"     get => Driver.Form.GetFormFieldValue({FieldName}, FieldType.{DataFieldType}).ToString().ToEnum<{Type}>();\r\n" +
                    $"      set => Driver.Form.SetFormFieldValue({FieldName}, value , FieldType.{DataFieldType});\r\n" +
                    "   }\r\n";
        }


    }
}
