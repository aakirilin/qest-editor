using System.Text.Json.Serialization;
using System;

namespace editor.Models.Conditions
{

    public class VariableBooleanComparer : VariableValueComparer<bool>
    {
        [JsonIgnore]
        public override ComparisonsOperators[] UseOperators => new ComparisonsOperators[]{
            ComparisonsOperators.Equally,
            ComparisonsOperators.NotEqual,
            ComparisonsOperators.AlwaysTrue,
            ComparisonsOperators.AlwaysFalse
        };

        protected override bool Equally(bool current, bool referense)
        {
            return current == referense;
        }

        protected override bool Greater(bool current, bool referense)
        {
            throw new NotImplementedException();
        }

        protected override bool GreaterOrEqually(bool current, bool referense)
        {
            throw new NotImplementedException();
        }

        protected override bool Less(bool current, bool referense)
        {
            throw new NotImplementedException();
        }

        protected override bool LessOrEqually(bool current, bool referense)
        {
            throw new NotImplementedException();
        }

        protected override bool NotEqual(bool current, bool referense)
        {
            return current != referense;
        }

        protected override bool Selector(Variable variable)
        {
            return variable.BValue;
        }
    }
}