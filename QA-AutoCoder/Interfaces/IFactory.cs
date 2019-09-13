using RunTimeTemplate.Models;
using System.Collections.Generic;

namespace qa_auto_coder.Interfaces
{
    public interface IFactory
    {
        string Generate(List<Field> pageFields, PageModel page);
    }
}
