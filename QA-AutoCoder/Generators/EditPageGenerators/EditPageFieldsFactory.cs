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
    public class EditPageFieldsFactory : IFactory
    {
        public string Generate(List<Field> pageFields, PageModel page)
        {
            List<EditPageFieldsPropertieModel> objetos = new List<EditPageFieldsPropertieModel>();

            foreach (var item in pageFields)
            {
                if (!item.IsListColumnOnly)
                    objetos.Add(new EditPageFieldsPropertieModel(item));
            }

            EditPageFieldsTemplate editPageFields = new EditPageFieldsTemplate();
            editPageFields.Session = new Dictionary<string, object>();

            editPageFields.Session.Add("ClassName", page.ClassName);
            editPageFields.Session.Add("Properties", objetos);

            editPageFields.Initialize();
            return editPageFields.TransformText();
        }
    }
}
