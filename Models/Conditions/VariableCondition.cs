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

        public VariableStringComparer StringComparer { get; set; }

        public VariableIngerComparer IngerComparer { get; set; }

        public VariableFloatComparer FloatComparer { get; set; }

        public VariableBooleanComparer BooleanComparer { get; set; }

        public bool Result(QuestGame game)
        {
            var variable = game.GetVariable(VariableId);
            if (variable == null) return false;

            var stringComparerResult = StringComparer.Comparete(variable, ReferenceValue);
            var ingerComparerResult = IngerComparer.Comparete(variable, ReferenceValue);
            var floatComparerResult = FloatComparer.Comparete(variable, ReferenceValue);
            var booleanComparerResult = BooleanComparer.Comparete(variable, ReferenceValue);

            return stringComparerResult && ingerComparerResult && floatComparerResult && booleanComparerResult;
        }
    }
}