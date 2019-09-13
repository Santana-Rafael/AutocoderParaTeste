using RunTimeTemplate.Helper;
using RunTimeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Models
{
    public class TestModel
    {

        private List<string> fields = new List<string>();
        private List<string> Properties = new List<string>();

        public TestModel(List<Field> fields, List<Block> blocks, List<string> Properties)
        {
            foreach (var item in fields)
            {
                this.fields.Add(ModelHelpers.ConvertToPascalCasePattern(item.Name));
            }

            this.Properties = Properties;

            fields.ForEach(field => ColumnsNames.Add(field.NameDisplayedInMibPage));
            fields.ForEach((Action<Field>)(field =>
            {
                if (field.IsRequired)
                    this._requiredFields.Add(field.NameDisplayedInMibPage);
            }));
            blocks.ForEach((Action<Block>)(block =>
           {
               this._allBlocksList.Add(block.Name);
           }));
        }

        public List<string> ColumnsNames { get; set; } = new List<string>();

        private List<string> _requiredFields = new List<string>();

        private List<string> _allBlocksList = new List<string>();

        public string RequiredFields
        {
            get
            {
                FormatToRequiredFieldListAssignmentFormat();
                return string.Join("", _requiredFields);
            }

        }

        public string GenerateEdit()
        {
            string _auxString = "";

            for (int i = 0; i < fields.Count; i++)
            {
                _auxString += $"            _editPage.{fields[i]} = model.{Properties[i]};\n";
            }

            return _auxString;
        }

        public string GenerateAssert()
        {
            string _auxString = "";

            for (int i = 0; i < fields.Count; i++)
            {
                _auxString += $"            _editPage.{fields[i]}.Should().Be(model.{Properties[i]});\n";
            }

            return _auxString;
        }

        public override string ToString()
        {
            return string.Join("", ColumnsNames);
        }

        public void FormatToListAssignmentFormat()
        {
            int lastElementIndex = ColumnsNames.Count - 1;

            for (int i = 0; i < lastElementIndex; i++)
            {
                ColumnsNames[i] = "\"" + ColumnsNames[i] + "\"" + ", ";
            }

            ColumnsNames[lastElementIndex] = "\"" + ColumnsNames[lastElementIndex] + "\"";

        }

        public void FormatToRequiredFieldListAssignmentFormat()
        {

            int lastElementIndex = _requiredFields.Count - 1;

            for (int i = 0; i < lastElementIndex; i++)
            {
                _requiredFields[i] = $" new RequiredField(\"{_requiredFields[i]}\"),\r\n" +
                    $"            ";
            }

            _requiredFields[lastElementIndex] = $" new RequiredField(\"{_requiredFields[lastElementIndex]}\")\r\n";

        }

        public string AllBlocksList
        {
            get
            {
                FormatToAllBlocksListListAssignmentFormat();
                return string.Join("", _allBlocksList);
            }
        }

        public void FormatToAllBlocksListListAssignmentFormat()
        {
            int lastElementIndex = _allBlocksList.Count - 1;

            for (int i = 0; i < lastElementIndex; i++)
            {
                _allBlocksList[i] = "\"" + _allBlocksList[i] + "\"" + $", ";
            }

            _allBlocksList[lastElementIndex] = "\"" + _allBlocksList[lastElementIndex] + "\"" ;
        }

    }
}