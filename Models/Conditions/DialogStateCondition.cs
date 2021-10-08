using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace editor.Models
{
    public class DialogStateCondition : ICondition
    {
        public ConditionChaildCount ChaildCount => ConditionChaildCount.None;
        public IEnumerable<ICondition> LinkConditions()
        {
            return null;
        }
        public void AddLinkCondition(ICondition condition)
        {
        }
        public void RemoveLinkCondition(ICondition condition)
        {
        }

        public string Description()
        {
            return $"Проверяет что диалог в указанном состоянии";
        } 
        public string Name => "Состояние диалога";
        public Guid DialogId { get; set; }
        public Guid SelectReplicaId { get; set; }

        public bool Result(QuestResourses resourses)
        {
            var dialog = resourses.Dialogs?.FirstOrDefault(d => d.Id == DialogId);
            if (dialog == null) return false;
            return dialog.CurrentReplicaId == SelectReplicaId;
        }
    }

    public enum ComparisonsOperators
    {
        [Display(Name = "Всегда истина")]
        AlwaysTrue,
        [Display(Name = "Всегда лож")]
        AlwaysFalse,
        [Display(Name = "Равно")]
        Equally,
        [Display(Name = "Не равно")]
        NotEqual,
        [Display(Name = "Больше")]
        Greater,
        [Display(Name = "Меньше")]
        Less,
        [Display(Name = "Больше или равно")]
        GreaterOrEqually,
        [Display(Name = "Меньше или равно")]
        LessOrEqually,
    }

    public class VariableCondition : ICondition
    {
        public ConditionChaildCount ChaildCount => ConditionChaildCount.None;

        public string Name => "Значение переменной";

        public void AddLinkCondition(ICondition condition)
        {
        }

        public string Description()
        {
            return $"Проверяет что переменная соответствует заданному значению";
        }

        public IEnumerable<ICondition> LinkConditions()
        {
            return null;
        }

        public void RemoveLinkCondition(ICondition condition)
        {
        }

        public VariableCondition()
        {
            StringComparer = new VariableStringComparer();
            IngerComparer = new VariableIngerComparer();
            FloatComparer = new VariableFloatComparer();
            BooleanComparer = new VariableBooleanComparer();
            ReferenceValue = new Variable();
        }

        public Guid VariableId { get; set; }
        public Variable ReferenceValue { get; set; }
        public VariableStringComparer StringComparer { get; }
        public VariableIngerComparer IngerComparer { get; }
        public VariableFloatComparer FloatComparer { get; }
        public VariableBooleanComparer BooleanComparer { get; }

        public bool Result(QuestResourses resourses)
        {
            var variable = resourses.Variables.FirstOrDefault(v => v.Id == VariableId);
            if (variable == null) return false;

            return StringComparer.Comparete(variable, ReferenceValue) && 
                   IngerComparer.Comparete(variable, ReferenceValue) &&
                   FloatComparer.Comparete(variable, ReferenceValue) &&
                   BooleanComparer.Comparete(variable, ReferenceValue);
        }
    }

    public interface IVariableValueComparer
    {
        ComparisonsOperators[] UseOperators { get; }
        ComparisonsOperators Operator { get; set; }
    }

    public abstract class VariableValueComparer<T> : IVariableValueComparer
    {
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

    public class VariableStringComparer : VariableValueComparer<string>
    {
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

    public class VariableIngerComparer : VariableValueComparer<float>
    {
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

        protected override bool Equally(float current, float referense)
        {
            return current == referense;
        }

        protected override bool Greater(float current, float referense)
        {
            return current > referense;
        }

        protected override bool GreaterOrEqually(float current, float referense)
        {
            return current >= referense;
        }

        protected override bool Less(float current, float referense)
        {
            return current < referense;
        }

        protected override bool LessOrEqually(float current, float referense)
        {
            return current <= referense;
        }

        protected override bool NotEqual(float current, float referense)
        {
            return current != referense;
        }

        protected override float Selector(Variable variable)
        {
            return variable.IValue;
        }
    }

    public class VariableFloatComparer : VariableValueComparer<float>
    {
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

        protected override bool Equally(float current, float referense)
        {
            return current == referense;
        }

        protected override bool Greater(float current, float referense)
        {
            return current > referense;
        }

        protected override bool GreaterOrEqually(float current, float referense)
        {
            return current >= referense;
        }

        protected override bool Less(float current, float referense)
        {
            return current < referense;
        }

        protected override bool LessOrEqually(float current, float referense)
        {
            return current <= referense;
        }

        protected override bool NotEqual(float current, float referense)
        {
            return current != referense;
        }

        protected override float Selector(Variable variable)
        {
            return variable.FValue;
        }
    }

    public class VariableBooleanComparer : VariableValueComparer<bool>
    {
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