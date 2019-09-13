using RunTimeTemplate.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimeTemplate.Models
{
    public class BlockPropertieModel
    {
        public BlockPropertieModel(Block block)
        {
            BlockId = block.Id;
            BlockName = ModelHelpers.ConvertToPrivateVariablePattern(block.Name);
        }

        public string BlockId { get; set; }
        public string BlockName { get; set; }

        public override string ToString()
        {
            return $"    [FindsBy(How = How.Id, Using = \"{BlockId}\")]\r\n" +
                   $"    private IWebElement {BlockName} {{ get; set; }}\r\n";
        }
    }
}
