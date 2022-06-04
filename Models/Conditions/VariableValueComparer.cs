using System;
using System.Text.Json.Serialization;

namespace editor.Models.Conditions
{
    public abstract class VariableValueComparer<T> : IVariableValueComparer
    {
        [JsonIgnore]
        public abstract ComparisonsOperators[] UseOperators { get; }
        protected abstract bool Equally(T current, T referense);
        protected abstract bool NotEqual(T current, T referense);
        protected abstract bool Greater(T current, T referense);
        protected abstract bool Less(T current, T referense);
        protected abstract bool GreaterOrEqually(T current, T referense);
        protected abstract bool LessOrEqually(T current, T referense);

        protected abstract T Selector(Variable variable);

        public ComparisonsOperators Operator { get; set; }
        public bool Comparete(Variable current, Variable referense)
        {
            var currentValue = Selector(current);
            var referenseValue = Selector(referense);

            if(Operator == ComparisonsOperators.Equally) return Equally(currentValue, referenseValue);
            else if(Operator == ComparisonsOperators.NotEqual) return NotEqual(currentValue, referenseValue);
            else if(Operator == ComparisonsOperators.Greater) return Greater(currentValue, referenseValue);
            else if(Operator == ComparisonsOperators.Less) return Less(currentValue, referenseValue);
            else if(Operator == ComparisonsOperators.GreaterOrEqually) return GreaterOrEqually(currentValue, referenseValue);
            else if(Operator == ComparisonsOperators.LessOrEqually) return LessOrEqually(currentValue, referenseValue);
            else if(Operator == ComparisonsOperators.AlwaysFalse) return false;
            else if(Operator == ComparisonsOperators.AlwaysTrue) return true;
            else throw new Exception($"Значение {Operator} на поддерживается.");
        }
    }
}