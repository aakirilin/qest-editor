namespace editor.Models.Actions
{
    public class FloatChengeAction : IChengeVariableAction
    {
        public ChengeVariableOperations Operation {get; set;}
        public ChengeVariableOperations[] AvailableOperations => new ChengeVariableOperations[]
        {
            ChengeVariableOperations.None,
            ChengeVariableOperations.Add,
            ChengeVariableOperations.Sub,
            ChengeVariableOperations.Set
        };

        public void Execute(Variable variable, Variable referenceValue){
            switch (Operation)
            {
                case ChengeVariableOperations.Add:
                    variable.FValue += referenceValue.FValue;
                    break;
                case ChengeVariableOperations.Sub:
                    variable.FValue -= referenceValue.FValue;
                    break;
                case ChengeVariableOperations.Set:
                    variable.FValue = referenceValue.FValue;
                    break;
            }
        }
    }
}