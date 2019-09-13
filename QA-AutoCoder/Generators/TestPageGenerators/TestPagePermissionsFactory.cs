using qa_auto_coder.Interfaces;
using qa_auto_coder.Models;
using qa_auto_coder.Templates;
using qa_auto_coder.Templates.TestPageTemplates;
using RunTimeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Generators
{
    public class TestPagePermissionsFactory
    {
        public static string Generate(FactoryInformation information)
        {
            TestPagePermissionsTemplate testPage = new TestPagePermissionsTemplate();
            testPage.Session = new Dictionary<string, object>();

            testPage.Session.Add("ClassName", information.Page.ClassName);
            testPage.Session.Add("ReadWriteUsers", information.Permissions.GetReadWriteUsersString());
            testPage.Session.Add("ReadOnlyUsers", information.Permissions.GetReadOnlyUsersString());
            testPage.Session.Add("NoReadUsers", information.Permissions.GetNoReadUsersString());
            testPage.Session.Add("UsersThatHasAccessToThePage", information.Permissions.GetUsersThatHasAccessToThePagesString());

            testPage.Initialize();
            return testPage.TransformText();
        }
    }
}