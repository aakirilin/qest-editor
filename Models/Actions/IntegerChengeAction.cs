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

        }
    }
}