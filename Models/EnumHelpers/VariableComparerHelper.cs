using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using editor.Models.Conditions;

namespace editor.Models.EnumHelpers
{
    public class VariableComparerHelper : ISelectHelper
    {
        private readonly IVariableValueComparer comparer;

        public VariableComparerHelper(IVariableValueComparer comparer)
        {
            this.comparer = comparer;
        }

        public string Value
        {
            get => Enum.GetName(comparer.Operator);
            set 
            {
                comparer.Operator = Enum.Parse<ComparisonsOperators>(value);
            }
        }

        public IEnumerable<SelectorOption> Options()
        {
            var selcted = comparer.UseOperators.Select(o => o.ToString()).ToArray();
            var enumType = typeof(ComparisonsOperators);
            var names = Enum.GetNames(enumType);
            var members = enumType.GetMembers().Where(m => selcted.Contains(m.Name));


            foreach (MemberInfo member in members)
            {
                
                var value = member.Name;
                var name = member.Name;
                var displayNameAttribyte = member.GetCustomAttribute<DisplayAttribute>();
                if(displayNameAttribyte != null) name =  displayNameAttribyte.GetName();

                yield return new SelectorOption(name, value);
            }
        }
    }
}