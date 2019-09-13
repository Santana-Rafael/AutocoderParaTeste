using qa_auto_coder.Models;
using qa_auto_coder.Templates;
using qa_auto_coder.Templates.TestPageTemplates;
using RunTimeTemplate.Helper;
using RunTimeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Generators
{
    public static class TestPageFactory
    {
        public static string GenerateTestPage(FactoryInformation information)
        {
            List<string> Properties = new List<string>();
            information.PageFields.RemoveAll(field => field.IsListColumnOnly);
            TestModel test = new TestModel(information.PageFields, information.Blocks, Properties);
            test.FormatToListAssignmentFormat();
            TestsTemplate testPage = new TestsTemplate();

            foreach (var item in information.PropertieModels)
            {
                Properties.Add(ModelHelpers.ConvertToPascalCasePattern(item.ColumnName));
            }

            testPage.Session = new Dictionary<string, object>();

            testPage.Session.Add("ColumnsNames", test.ToString());
            testPage.Session.Add("RequiredFields", test.RequiredFields);
            testPage.Session.Add("ClassName", information.Page.ClassName);
            testPage.Session.Add("AllBlocksList", test.AllBlocksList);
            testPage.Session.Add("ReadWriteUsers", information.Permissions.GetReadWriteUsersString());
            testPage.Session.Add("ReadOnlyUsers", information.Permissions.GetReadOnlyUsersString());
            testPage.Session.Add("NoReadUsers", information.Permissions.GetNoReadUsersString());
            testPage.Session.Add("UsersThatHasAccessToThePage", information.Permissions.GetUsersThatHasAccessToThePagesString());
            testPage.Session.Add("EditMethod", test.GenerateEdit());
            testPage.Session.Add("AssertMethod", test.GenerateAssert());

            testPage.Initialize();
            return testPage.TransformText();
        }

    }
}
