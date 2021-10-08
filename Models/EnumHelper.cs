using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace editor.Models
{
    public struct SelectorOption
    {
        public readonly string DiaplayName;
        public readonly string Value;

        public SelectorOption(string diaplayName, string value)
        {
            DiaplayName = diaplayName;
            Value = value;
        }
    }

    public interface ISelectHelper
    {
        string Value {get; set;}
        IEnumerable<SelectorOption> Options();
    }

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

    public class DialogHelper : ISelectHelper
    {
        private readonly IEnumerable<Dialog> dialogs;
        private readonly DialogStateCondition condition;
        public Dialog Dialog => dialogs.FirstOrDefault(d => d.Id == condition.DialogId);

        public DialogHelper(IEnumerable<Dialog> dialogs, DialogStateCondition condition)
        {
            this.condition = condition;
            this.dialogs = dialogs;
        }

        public string Value
        {
            get => condition.DialogId.ToString();
            set 
            {
                Guid id;
                if(Guid.TryParse(value, out id)){
                    condition.DialogId = id;
                }
                else{
                    condition.DialogId = Guid.Empty;
                }
                
            }
        }

        public IEnumerable<SelectorOption> Options()
        {
            return dialogs.Select(d => new SelectorOption(d.Title, d.Id.ToString()));
        }
    }

    public class ReplicaHelper : ISelectHelper
    {

        private readonly IEnumerable<Replica> replics;
        private readonly DialogStateCondition  condition;
        public ReplicaHelper(DialogHelper dialogHelper, DialogStateCondition condition)
        {
            this.condition = condition;
            this.replics = dialogHelper.Dialog?.Replics ?? new List<Replica>();
        }

        public string Value
        {
            get => condition.SelectReplicaId.ToString();
            set 
            {
                Guid id;
                if(Guid.TryParse(value, out id)){
                    condition.SelectReplicaId = id;
                }
                else{
                    condition.SelectReplicaId = Guid.Empty;
                }
                
            }
        }

        public IEnumerable<SelectorOption> Options()
        {
            return replics.Select(d => new SelectorOption(d.Text, d.Id.ToString()));
        }
    }


    public class VariableHelper : ISelectHelper
    {

        private readonly IEnumerable<Variable> variables;
        private readonly VariableCondition  condition;
        public VariableHelper(IEnumerable<Variable> variables, VariableCondition  condition)
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
