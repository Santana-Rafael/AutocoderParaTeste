using qa_auto_coder.Interfaces;
using qa_auto_coder.Templates;
using qa_auto_coder.Templates.EditPageTemplates;
using RunTimeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Generators
{
    public class EditPageFactory : IFactory
    {

        public string Generate(List<Field> pageFields, PageModel page)
        {
            List<EditPagePropertiesModel> objetos = new List<EditPagePropertiesModel>();

            foreach (var item in pageFields)
            {
                if (!item.IsListColumnOnly)
                {
                    objetos.Add(new EditPagePropertiesModel(item));
                }
            }

            EditPageTemplate editPage = new EditPageTemplate();
            editPage.Session = new Dictionary<string, object>();

            editPage.Session.Add("ClassName", page.ClassName);
            editPage.Session.Add("ComponentKey", page.ComponentKey + "_edit");
            editPage.Session.Add("MenuName", page.MenuName);
            editPage.Session.Add("Properties", objetos);

            editPage.Initialize();
            return editPage.TransformText();
        }
    }
}
