using qa_auto_coder.Models;
using qa_auto_coder.Models.APIModels;
using qa_auto_coder.Templates.APITemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Generators.APIGenerators
{
    class APIFactoryFactory
    {
        public static string Generate(FactoryInformation information)
        {
            APIFactoryTemplate modelTemplate = new APIFactoryTemplate();
            APIFactoryModel aPIFactoryFactory = new APIFactoryModel(information.PropertieModels, information.Page.ClassName);
            modelTemplate.Session = new Dictionary<string, object>();

            modelTemplate.Session.Add("Properties", aPIFactoryFactory.GenerateInit());
            modelTemplate.Session.Add("ClassName", information.Page.ClassName);
            modelTemplate.Session.Add("ObjectName", information.Page.ClassName.ToLower());
            modelTemplate.Initialize();
            
            return modelTemplate.TransformText();
        }

    }
}
