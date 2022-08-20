using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace editor.Models
{
    public class VariablesIdComparer : IEqualityComparer<Variable>
    {
        public bool Equals(Variable x, Variable y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Variable obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}