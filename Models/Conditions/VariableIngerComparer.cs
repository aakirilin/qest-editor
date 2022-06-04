using System.Text.Json.Serialization;

namespace editor.Models.Conditions
{
    public class VariableIngerComparer : VariableValueComparer<int>
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

        protected override bool Equally(int current, int referense)
        {
            return current == referense;
        }

        protected override bool Greater(int current, int referense)
        {
            return current > referense;
        }

        protected override bool GreaterOrEqually(int current, int referense)
        {
            return current >= referense;
        }

        protected override bool Less(int current, int referense)
        {
            return current < referense;
        }

        protected override bool LessOrEqually(int current, int referense)
        {
            return current <= referense;
        }

        protected override bool NotEqual(int current, int referense)
        {
            return current != referense;
        }

        protected override int Selector(Variable variable)
        {
            return variable.IValue;
        }
    }
}