using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace editor.Models.Conditions
{
    public class RootCondition : ICondition
    {
        public RootCondition()
        {
        }
        [JsonIgnore]
        public ConditionChaildCount ChaildCount => ConditionChaildCount.One;
        public IEnumerable<ICondition> LinkConditions()
        {
            yield return Condition;
        }
        public void AddLinkCondition(ICondition condition)
        {
            Condition = condition;
        }
        public void RemoveLinkCondition(ICondition condition)
        {
            Condition = null;
        }
        public ICondition Condition {get; set;}
        public string Description()
        {
            return "Возвращает значение вложенного условия или false";
        } 
        [JsonIgnore]
        public string Name => "Корневое условие";
        public bool Result(QuestGame game)
        {
            return Condition?.Result(game) ?? true;
        }
    }
}