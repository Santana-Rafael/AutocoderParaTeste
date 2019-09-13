using qa_auto_coder.Interfaces;
using qa_auto_coder.Templates;
using qa_auto_coder.Templates.ListPageTemplates;
using RunTimeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Generators
{
    public class ListPageFactory : IFactory
    {
        public string Generate(List<Field> pageFields, PageModel page)
        {
            ListPageModel ListPage = new ListPageModel(pageFields);
            ListPage.FormatToListAssignmentFormat();
            ListPageTemplate listPage = new ListPageTemplate();
            listPage.Session = new Dictionary<string, object>();

            listPage.Session.Add("ClassName", page.ClassName);
            listPage.Session.Add("ComponentKey", page.ComponentKey +"_list");
            listPage.Session.Add("MenuName", page.MenuName);
            listPage.Session.Add("ColumnsNames", ListPage.ToString());

            listPage.Initialize();
            return listPage.TransformText();
        }

    }
}
