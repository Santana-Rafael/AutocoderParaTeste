using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_auto_coder.Models
{
    public class APIClassModel
    {
        
        public APIClassModel(string tableName, string className)
        {
            this.TableName = tableName;
            this.ClassName = className;
        }

        public string GetConstructorModel()
        {
            return $"public {ClassName}()" +
                       $": base(\"{TableName}\")" +
                   "{ }";
        }

        public string TableName { get; set; }
        public string ClassName { get; }
    }
}
