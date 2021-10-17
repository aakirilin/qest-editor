using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace editor.Models.Conditions
{
    public interface ICondition
    {
        [JsonIgnore]
        ConditionChaildCount ChaildCount { get; }
        [JsonIgnore]
        string Name {get;}
        string Description();
        bool Result(QuestResourses resourses);

        IEnumerable<ICondition> LinkConditions();
        void AddLinkCondition(ICondition condition);
        void RemoveLinkCondition(ICondition condition);
    }
}