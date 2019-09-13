using qa_auto_coder.Interfaces;
using qa_auto_coder.Models;
using qa_auto_coder.Templates.APITemplates;
using RunTimeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Generators.APIGenerators
{
    public static class APIModelsFactory
    {
        public static string Generate(FactoryInformation information)
        {
            APIModelTemplate modelTemplate = new APIModelTemplate();

            modelTemplate.Session = new Dictionary<string, object>();

            modelTemplate.Session.Add("ClassName", information.Page.ClassName);
            modelTemplate.Session.Add("Constructor", information.APIClass.GetConstructorModel());
            modelTemplate.Session.Add("Properties", information.PropertieModels);

            modelTemplate.Initialize();
            return modelTemplate.TransformText();

        }

    }
}
