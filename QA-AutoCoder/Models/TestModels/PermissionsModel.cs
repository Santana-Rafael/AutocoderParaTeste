using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Models
{
    public class PermissionsModel
    {
        public List<string> ReadOnlyUsers { get; set; }

        public List<string> ReadWriteUsers { get; set; }

        public List<string> NoReadUsers { get; set; } = new List<string>() { "Administrators", "OBAdministrator", "LiveTV", "FOGlobal", "FOLurin", "UserCreator",
        "AdministratorsReadOnly", "OBAdministratorReadOnly", "LiveTVReadOnly", "VODContentManagement", "EPG", "EditorialManagement", "Commercial", "Notifications",
        "CRM", "Purge", "VODContentManagementReadOnly", "EPGReadOnly", "EditorialManagementReadOnly", "CommercialReadOnly", "NotificationsReadOnly", "CRMReadOnly"};

        public void FormatUsers()
        {
            ReadOnlyUsers.ForEach(x => NoReadUsers.Remove(x));
            ReadWriteUsers.ForEach(x => NoReadUsers.Remove(x));
        }

        public void FormatToMibUserType()
        {
            ReadOnlyUsers = ReadOnlyUsers.Select(x => "MibUserType." + x).ToList();
            ReadWriteUsers = ReadWriteUsers.Select(x => "MibUserType." + x).ToList();
            NoReadUsers = NoReadUsers.Select(x => "MibUserType." + x).ToList();
        }

        public string GetUsersThatHasAccessToThePagesString()
        {
            var usersThatHasAccessToThePage = new List<string>();

            usersThatHasAccessToThePage.AddRange(ReadWriteUsers);
            usersThatHasAccessToThePage.AddRange(ReadOnlyUsers);

            return string.Join(",",usersThatHasAccessToThePage);
        }

        public string GetReadOnlyUsersString()
        {
            return FormatToMibUsers(ReadOnlyUsers);
            
        }

        public string GetReadWriteUsersString()
        {
            return FormatToMibUsers(ReadWriteUsers);
        }

        public string GetNoReadUsersString()
        {
            return FormatToMibUsers(NoReadUsers);
        }

        private string FormatToMibUsers(List<string> usersList)
        {
            string str = "";
            int lastIndex = usersList.Count - 1;

            for (int i = 0; i < usersList.Count - 1; i++)
            {
                if (i % 4 == 0)
                    str += usersList[i] + ",\n          ";
                else
                    str += usersList[i] + ",";
            }

            str += usersList[lastIndex];

            return str;
        }
    }
}
