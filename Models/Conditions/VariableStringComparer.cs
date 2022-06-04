using System.Text.Json.Serialization;
using System;

namespace editor.Models.Conditions
{
    public class VariableStringComparer : VariableValueComparer<string>
    {
        [JsonIgnore]
        public override ComparisonsOperators[] UseOperators => new ComparisonsOperators[]{
            ComparisonsOperators.Equally,
            ComparisonsOperators.NotEqual,
            ComparisonsOperators.AlwaysTrue,
            ComparisonsOperators.AlwaysFalse
        };

        protected override bool Equally(string current, string referense)
        {
            return current.Equals(referense);
        }

        protected override bool Greater(string current, string referense)
        {
            throw new NotImplementedException();
        }

        protected override bool GreaterOrEqually(string current, string referense)
        {
            throw new NotImplementedException();
        }

        protected override bool Less(string current, string referense)
        {
            throw new NotImplementedException();
        }

        protected override bool LessOrEqually(string current, string referense)
        {
            throw new NotImplementedException();
        }

        protected override bool NotEqual(string current, string referense)
        {
            return !current.Equals(referense);
        }

        protected override string Selector(Variable variable)
        {
            return variable.SValue;
        }
    }
}