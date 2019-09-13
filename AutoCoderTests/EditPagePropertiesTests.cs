using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunTimeTemplate.Models;

namespace AutoCoderTests
{
    [TestClass]
    public class EditPagePropertiesTests
    {
        [TestMethod]
        public void Check_string_propertie_generation()
        {
            //Arrange
            string expectedPropertie = $"   public string Name\r\n" +
                    "   {\r\n " +
                    $"     get => Driver.Form.GetFormFieldValue(_name, FieldType.Varchar).ToString();\r\n" +
                    $"      set => Driver.Form.SetFormFieldValue(_name, value , FieldType.Varchar);\r\n" +
                    "   }\r\n";

            var field = new Field
            {
                Name = "Name",
                Type = "string",
                DataFieldType = "Varchar",
                Id = "name_field"
            };

            //act 
            var teste = new EditPagePropertiesModel(field);

            Assert.AreEqual(expectedPropertie, teste.ToString());
        }

        [TestMethod]
        public void Check_integer_propertie_generation()
        {
            //Arrange
            string expectedPropertie = $"   public string Name\r\n" +
                    "   {\r\n " +
                    $"     get => Driver.Form.GetFormFieldValue(_name, FieldType.Integer).ToInt();\r\n" +
                    $"      set => Driver.Form.SetFormFieldValue(_name, value , FieldType.Integer);\r\n" +
                    "   }\r\n";

            var field = new Field
            {
                Name = "Name",
                Type = "string",
                DataFieldType = "Integer",
                Id = "name_field"
            };

            //act 
            var teste = new EditPagePropertiesModel(field);

            Assert.AreEqual(expectedPropertie, teste.ToInt());
        }

        [TestMethod]
        public void Check_boolean_propertie_generation()
        {
            string expectedPropertie = $"   public bool IsDtp\r\n" +
                    "   {\r\n " +
                    $"     get => Convert.ToBoolean(Driver.Form.GetFormFieldValue(_isDtp, FieldType.Boolean).ToString());\r\n" +
                    $"      set => Driver.Form.SetFormFieldValue(_isDtp, value , FieldType.Boolean);\r\n" +
                    "   }\r\n";

            var field = new Field
            {
                Name = "Is DTP",
                Type = "bool",
                DataFieldType = "Boolean",
                Id = "name_field"
            };

            var teste = new EditPagePropertiesModel(field);

            Assert.AreEqual(expectedPropertie, teste.ToBoolean());
        }
    }
}
