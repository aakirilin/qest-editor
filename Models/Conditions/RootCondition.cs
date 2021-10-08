using System.Collections.Generic;

namespace editor.Models
{
    public class RootCondition : ICondition
    {
        public RootCondition()
        {
        }

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
        public string Name => "Корневое условие";
        public bool Result(QuestResourses resourses)
        {
            return Condition?.Result(resourses) ?? false;
        }
    }
}