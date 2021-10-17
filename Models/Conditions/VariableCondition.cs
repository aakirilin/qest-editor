using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace editor.Models.Conditions
{
    
    public class VariableCondition : ICondition, IVariableRefenece
    {
        [JsonIgnore]
        public ConditionChaildCount ChaildCount => ConditionChaildCount.None;
        [JsonIgnore]
        public string Name => "Значение переменной";

        public void AddLinkCondition(ICondition condition)
        {
        }

        public string Description()
        {
            return $"Проверяет что переменная соответствует заданному значению";
        }

        public IEnumerable<ICondition> LinkConditions()
        {
            return null;
        }

        public void RemoveLinkCondition(ICondition condition)
        {
        }

        public VariableCondition()
        {
            StringComparer = new VariableStringComparer();
            IngerComparer = new VariableIngerComparer();
            FloatComparer = new VariableFloatComparer();
            BooleanComparer = new VariableBooleanComparer();
            ReferenceValue = new Variable();
        }

        public Guid VariableId { get; set; }
        public Variable ReferenceValue { get; set; }
        [JsonIgnore]
        public VariableStringComparer StringComparer { get; }
        [JsonIgnore]
        public VariableIngerComparer IngerComparer { get; }
        [JsonIgnore]
        public VariableFloatComparer FloatComparer { get; }
        [JsonIgnore]
        public VariableBooleanComparer BooleanComparer { get; }

        public bool Result(QuestResourses resourses)
        {
            var variable = resourses.Variables.FirstOrDefault(v => v.Id == VariableId);
            if (variable == null) return false;

            return StringComparer.Comparete(variable, ReferenceValue) && 
                   IngerComparer.Comparete(variable, ReferenceValue) &&
                   FloatComparer.Comparete(variable, ReferenceValue) &&
                   BooleanComparer.Comparete(variable, ReferenceValue);
        }
    }
}