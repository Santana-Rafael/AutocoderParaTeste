using MibClient2.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qa_auto_coder.Helpers
{
    public static class LogHelper
    {
        private static readonly string _messageBoxCaption = "Error";

        public static void SimpleException(string e)
        {
            new MibLog("Auto-Coder-Error-Log").Log($"A expection has been thrown. Exeception: {e}");
            ShowMessageBox("A expection has been thrown. See logs for more details");
            Environment.Exit(1);
        }

        public static void JsonException(string e)
        {
            new MibLog("Auto-Coder-Error-Log").Log($"There was an error trying to serialize the Json. Expection {e}");
            ShowMessageBox("There was an error trying to serialize the Json. See logs for more details");
            Environment.Exit(1);
        }

        public static void FileNotFoundException(string e)
        {
            new MibLog("Auto-Coder-Error-Log").Log($"There was an error when trying to find a json file." +
                $" Please check if it's created. Exception {e}");
            ShowMessageBox("There was an error when trying to find a json file. See logs for more details");
            Environment.Exit(1);
        }

        public static void NoValueException()
        {
            new MibLog("Auto-Coder-Error-Log").Log($"There are properties with no value");
            ShowMessageBox("There are properties with no value. Check the information in page.json file");
            Environment.Exit(1);
        }

        public static void NoInputFolderException()
        {
            new MibLog("Auto-Coder-Error-Log").Log("There are no input Folder. Verify if it's created or the path is right");
            ShowMessageBox("There are no input Folder. Verify if it's created or the path is right");
            Environment.Exit(1);
        }

        private static void ShowMessageBox(string message)
        {
            MessageBox.Show(message, _messageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
