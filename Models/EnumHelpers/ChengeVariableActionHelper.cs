using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using editor.Models.Actions;

namespace editor.Models.EnumHelpers
{
    public class ChengeVariableActionHelper : ISelectHelper
    {
        private readonly IChengeVariableAction action;

        public ChengeVariableActionHelper(IChengeVariableAction action)
        {
            this.action = action;
        }

        public string Value
        {
            get => Enum.GetName(action?.Operation ?? 0);
            set 
            {
                action.Operation = Enum.Parse<ChengeVariableOperations>(value);
            }
        }

        public IEnumerable<SelectorOption> Options()
        {
            var selcted = action?.AvailableOperations?.Select(o => o.ToString())?.ToArray();
            var enumType = typeof(ChengeVariableOperations);
            var names = Enum.GetNames(enumType);
            var members = enumType.GetMembers().Where(m => selcted?.Contains(m.Name) ?? true);


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