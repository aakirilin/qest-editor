using System.Collections.Generic;

namespace editor.Models
{
    public interface ICondition
    {
        ConditionChaildCount ChaildCount { get; }
        string Name {get;}
        string Description();
        bool Result(QuestResourses resourses);

        IEnumerable<ICondition> LinkConditions();
        void AddLinkCondition(ICondition condition);
        void RemoveLinkCondition(ICondition condition);
    }
}