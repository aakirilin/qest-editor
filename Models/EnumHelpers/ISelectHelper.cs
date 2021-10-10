using System.Collections.Generic;

namespace editor.Models.EnumHelpers
{
    public interface ISelectHelper
    {
        string Value {get; set;}
        IEnumerable<SelectorOption> Options();
    }
}
