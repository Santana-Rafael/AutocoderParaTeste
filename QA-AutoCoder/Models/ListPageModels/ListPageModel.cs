using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimeTemplate.Models
{
    public class ListPageModel
    {

        public ListPageModel(List<Field> fields)
        {
            fields.ForEach(field => ColumnsNames.Add(field.Name.ToUpper()));
        }

        public List<string> ColumnsNames { get; set; } = new List<string>();

        public override string ToString()
        {
            return string.Join("", ColumnsNames);
        }

        public void FormatToListAssignmentFormat()
        {
            int lastElementIndex = ColumnsNames.Count - 1;

            for (int i = 0; i < lastElementIndex; i++)
            {
                ColumnsNames[i] = "\"" + ColumnsNames[i] + "\"" +", ";
            }

            ColumnsNames[lastElementIndex] = "\"" + ColumnsNames[lastElementIndex] + "\"";

        }

    }
}
