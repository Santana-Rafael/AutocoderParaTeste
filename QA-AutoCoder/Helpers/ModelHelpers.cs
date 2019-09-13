using qa_auto_coder.Helpers;
using RunTimeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimeTemplate.Helper
{
    public static class ModelHelpers
    {
        public static string ConvertToPascalCasePattern(string name)
        {
            name = name.Replace("_", " ").ToLower();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(name).Replace(" ", string.Empty);
        }

        public static string ConvertToPrivateVariablePattern(string name)
        {
            string propertieFormatName = ConvertToPascalCasePattern(name);
            return "_" + SetFirstLetterOfNameLowerCase(propertieFormatName);
        }

        public static string SetFirstLetterOfNameLowerCase(string name)
        {
            return name.First().ToString().ToLower() + name.Substring(1);
        }

        public static void ValidateFieldProperties(Field field)
        {
            if ((field.Name == "" || field.Type == "" || field.DataFieldType == "" || field.Id == "") && !field.IsListColumnOnly)
                LogHelper.NoValueException();
        }
    }
}
