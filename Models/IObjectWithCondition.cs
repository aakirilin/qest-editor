using editor.Models.Conditions;

namespace editor.Models
{
    public interface IObjectWithCondition
    {
        ICondition Condition { get; set; }
    }
}