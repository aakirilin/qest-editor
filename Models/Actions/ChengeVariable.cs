using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace editor.Models.Actions
{
    public class ChengeVariable : IAction, IVariableRefenece
    {
        public ChengeVariable(){
            ReferenceValue = new Variable();
            IntegerAction = new IntegerChengeAction();
            FloatAction = new FloatChengeAction();
            BooleanAction = new BooleanChengeAction();
            StringAction = new StringChengeAction();
        }
        public Guid VariableId {get; set;}

        public Variable ReferenceValue { get; set;}

        public IChengeVariableAction IntegerAction {get;}
        public IChengeVariableAction FloatAction {get;}
        public IChengeVariableAction BooleanAction {get;}
        public IChengeVariableAction StringAction {get;}

        [JsonIgnore]
        public string Name => "Изменение переменной";

        public string Description()
        {
            return Name;
        }

        public void Execute(QuestResourses resourses, Dialog currentDialog, Replica currentReplica, Answer currentAnswer)
        {
            var variable = resourses.Variables.FirstOrDefault(v => v.Id == VariableId);
            if(variable != null){
                IntegerAction.Execute(variable, ReferenceValue);
                FloatAction.Execute(variable, ReferenceValue);
                BooleanAction.Execute(variable, ReferenceValue);
                StringAction.Execute(variable, ReferenceValue);
            }
        }
    }
}