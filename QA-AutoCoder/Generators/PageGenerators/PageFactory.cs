using qa_auto_coder.Generators;
using qa_auto_coder.Generators.APIGenerators;
using qa_auto_coder.Interfaces;
using qa_auto_coder.Models;
using qa_auto_coder.Templates;
using Newtonsoft.Json;
using RunTimeTemplate.Helper;
using RunTimeTemplate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder
{
    public class PageGenerator
    {
        private FactoryInformation Informations;
        private readonly string outputFolderPath = @"../../Output-Jsons/";

        public PageGenerator(FactoryInformation information)
        {
            this.Informations = information;
        }

       
        public void GeneratePage<T>(string PageTypeToWriteInFileName = "") where T : IFactory
        {
            string pathToRecordFile = outputFolderPath + $"{Informations.Page.ClassName}{PageTypeToWriteInFileName}.cs";

            var pageFactory = (T)Activator.CreateInstance(typeof(T));

            CreateOutputDirectoryIfDoesNotExist();

            File.WriteAllText(pathToRecordFile, pageFactory.Generate(Informations.PageFields, Informations.Page));
        }

        public void GenerateTestPage(List<APIPropertieModel> properties)
        {
            string pathToRecordFile = outputFolderPath + $"{Informations.Page.ClassName}Tests.cs";

            CreateOutputDirectoryIfDoesNotExist();

            File.WriteAllText(pathToRecordFile, TestPageFactory.GenerateTestPage(Informations));
        }

        public void GenerateTestPermissionsPage()
        {
            string pathToRecordFile = outputFolderPath + $"{Informations.Page.ClassName}Tests.Permissions.cs";

            CreateOutputDirectoryIfDoesNotExist();

            File.WriteAllText(pathToRecordFile, TestPagePermissionsFactory.Generate(Informations));
        }

        public void GenerateAPIModelPage(List<APIPropertieModel> properties)
        {
            var fileName = ModelHelpers.ConvertToPascalCasePattern(Informations.Page.MenuName.ToUpper());

            var classModel = new APIClassModel(Informations.Page.ComponentKey.ToUpper(), Informations.Page.ClassName);
            Informations.APIClass = classModel;

            string pathToRecordFile = outputFolderPath + $"{fileName}.cs";
            string pathToRecorAPIFactory = outputFolderPath + $"{fileName}Factory.cs";

            CreateOutputDirectoryIfDoesNotExist();

            File.WriteAllText(pathToRecordFile, APIModelsFactory.Generate(Informations));
            File.WriteAllText(pathToRecorAPIFactory, APIFactoryFactory.Generate(Informations));
        }

        private void CreateOutputDirectoryIfDoesNotExist()
        {
            if (!Directory.Exists(outputFolderPath))
            {
                Directory.CreateDirectory(outputFolderPath);
            }
        }

    }
}
