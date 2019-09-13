using qa_auto_coder.Models;
using RunTimeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder
{
    public class FactoryInformation
    {
        public List<Field> PageFields { get; set; }
        public List<Block> Blocks { get; set; }
        public PageModel Page { get; set; }
        public PermissionsModel Permissions { get; set; }
        public List<APIPropertieModel> PropertieModels { get; set; }
        public APIClassModel APIClass { get; set; }
    }
}
