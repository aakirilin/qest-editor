using System.Text.Json.Serialization;

namespace editor.Models.Conditions
{
    public class VariableFloatComparer : VariableValueComparer<float>
    {
        [JsonIgnore]
        public override ComparisonsOperators[] UseOperators => new ComparisonsOperators[]{
            ComparisonsOperators.Equally,
            ComparisonsOperators.Greater,
            ComparisonsOperators.GreaterOrEqually,
            ComparisonsOperators.Less,
            ComparisonsOperators.LessOrEqually,
            ComparisonsOperators.NotEqual,
            ComparisonsOperators.AlwaysTrue,
            ComparisonsOperators.AlwaysFalse
        };

        protected override bool Equally(float current, float referense)
        {
            return current == referense;
        }

        protected override bool Greater(float current, float referense)
        {
            return current > referense;
        }

        protected override bool GreaterOrEqually(float current, float referense)
        {
            return current >= referense;
        }

        protected override bool Less(float current, float referense)
        {
            return current < referense;
        }

        protected override bool LessOrEqually(float current, float referense)
        {
            return current <= referense;
        }

        protected override bool NotEqual(float current, float referense)
        {
            return current != referense;
        }

        protected override float Selector(Variable variable)
        {
            return variable.FValue;
        }
    }
}