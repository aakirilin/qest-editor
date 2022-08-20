namespace editor.Models.Actions
{
    public class IntegerChengeAction : IChengeVariableAction
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
                    variable.IValue += referenceValue.IValue;
                    break;
                case ChengeVariableOperations.Sub:
                    variable.IValue -= referenceValue.IValue;
                    break;
                case ChengeVariableOperations.Set:
                    variable.IValue = referenceValue.IValue;
                    break;
            }
        }
    }
}