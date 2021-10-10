using System;
using System.Collections.Generic;
using System.Linq;
using editor.Models.Conditions;

namespace editor.Models.EnumHelpers
{
    public class VariableHelper : ISelectHelper
    {

        private readonly IEnumerable<Variable> variables;
        private readonly IVariableRefenece  condition;
        public VariableHelper(IEnumerable<Variable> variables, IVariableRefenece  condition)
        {
            this.condition = condition;
            this.variables = variables;
        }

        public string Value
        {
            get => condition.VariableId.ToString();
            set 
            {
                Guid id;
                if(Guid.TryParse(value, out id)){
                    condition.VariableId = id;
                }
                else{
                    condition.VariableId = Guid.Empty;
                }
                
            }
        }

        public IEnumerable<SelectorOption> Options()
        {
            return variables.Select(d => new SelectorOption(d.Name, d.Id.ToString()));
        }
    }
}
