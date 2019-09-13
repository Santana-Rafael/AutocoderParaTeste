using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RunTimeTemplate.Models;
using Newtonsoft.Json;
using qa_auto_coder.Generators;
using MibClient2.Log;
using qa_auto_coder.Helpers;
using qa_auto_coder.Models;
using System.Windows.Forms;

namespace qa_auto_coder
{
    class Program
    {
        private static PageModel pageModel;
        private static List<Field> pageFields;
        private static List<Block> pageBlocks;
        private static List<APIPropertieModel> APIProperties;
        private static PermissionsModel pagePermissions;
        private static readonly string inputFolderPath = "../../Input-Jsons";

        private static void Init()
        {
            if (!Directory.Exists(inputFolderPath))
            {
                LogHelper.NoInputFolderException();
            }

            ReadJsonsInInputFolder();

        }

        static void Main(string[] args)
        {
            Init();

            FactoryInformation information = new FactoryInformation();

            information.PageFields = pageFields;
            information.Blocks = pageBlocks;
            information.Page = pageModel;
            information.Permissions = pagePermissions;
            information.PropertieModels = APIProperties;

            var pageGenerator = new PageGenerator(information);

            pageGenerator.GeneratePage<EditPageFactory>("EditPage");
            pageGenerator.GeneratePage<EditPageFieldsFactory>("EditPageFields");
            pageGenerator.GeneratePage<ListPageFactory>("ListPage");


            pageGenerator.GenerateTestPage(APIProperties);
            pageGenerator.GenerateTestPermissionsPage();
            pageGenerator.GenerateAPIModelPage(APIProperties);

            MessageBox.Show("Process completed with success. Check output json folder to find the files." , "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        private static void ReadJsonsInInputFolder()
        {
            try
            {
                GetFieldsInformationsFromJson();
                GetPageInformationsFromJson();
                GetBlocksInformationsFromJson();
                GetPermissionsInformationsFromJson();
                GetAPIPropertiesInformationsFromJson();
            }
            catch (FileNotFoundException e)
            {
                LogHelper.FileNotFoundException(e.Message);
            }
            catch (JsonSerializationException e)
            {
                LogHelper.JsonException(e.Message);
            }
            catch (Exception e)
            {
                LogHelper.SimpleException(e.Message);
            }
        }

        private static void GetFieldsInformationsFromJson()
        {
            string fieldObjectSerialized = File.ReadAllText($"{inputFolderPath}/fields.json");
            pageFields = JsonConvert.DeserializeObject<List<Field>>(fieldObjectSerialized);
        }

        private static void GetPageInformationsFromJson()
        {
            string pageObjectSerialized = File.ReadAllText($"{inputFolderPath}/page.json");
            pageModel = JsonConvert.DeserializeObject<PageModel>(pageObjectSerialized);
        }

        private static void GetBlocksInformationsFromJson()
        {
            string blocksObjectSerialized = File.ReadAllText($"{inputFolderPath}/blocks.json");
            pageBlocks = JsonConvert.DeserializeObject<List<Block>>(blocksObjectSerialized);
        }

        private static void GetAPIPropertiesInformationsFromJson()
        {
            string APIPropertiesObjectSerialized = File.ReadAllText($"{inputFolderPath}/APIProperties.json");
            APIProperties = JsonConvert.DeserializeObject<List<APIPropertieModel>>(APIPropertiesObjectSerialized);
        }

        private static void GetPermissionsInformationsFromJson()
        {
            string permissionsObjectSerialized = File.ReadAllText($"{inputFolderPath}/permissions.json");
            pagePermissions = JsonConvert.DeserializeObject<PermissionsModel>(permissionsObjectSerialized);
            pagePermissions.FormatUsers();
            pagePermissions.FormatToMibUserType();
        }
    }

}
