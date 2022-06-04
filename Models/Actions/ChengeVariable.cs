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

        public IChengeVariableAction IntegerAction { get; set; }

        public IChengeVariableAction FloatAction { get; set; }

        public IChengeVariableAction BooleanAction { get; set; }

        public IChengeVariableAction StringAction { get; set; }

        [JsonIgnore]
        public string Name => "Изменение переменной";

        public string Description()
        {
            return Name;
        }

        public void Execute(QuestGame game)
        {
            var variable = game.GetVariable(VariableId);
            if(variable != null){
                IntegerAction.Execute(variable, ReferenceValue);
                FloatAction.Execute(variable, ReferenceValue);
                BooleanAction.Execute(variable, ReferenceValue);
                StringAction.Execute(variable, ReferenceValue);
            }
        }
    }
}