using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace editor.Models.EnumHelpers
{
    public class EnumHelper : ISelectHelper
    {
        private readonly Type enumType;
        private readonly Action<string> Setter;
        private readonly Func<string> Getter;

        public EnumHelper(Type enumType, Action<string> setter, Func<string> getter)
        {
            this.enumType = enumType;
            Setter = setter;
            Getter = getter;
        }

        public string Value
        {
            get => Getter.Invoke();
            set => Setter.Invoke(value);
        }

        public IEnumerable<SelectorOption> Options()
        {
            var names = Enum.GetNames(enumType);


            var members = enumType.GetMembers().Where(m => names.Contains(m.Name));
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
