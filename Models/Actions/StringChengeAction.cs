namespace editor.Models.Actions
{
    public class StringChengeAction : IChengeVariableAction
    {
        public ChengeVariableOperations Operation {get; set;}
        public ChengeVariableOperations[] AvailableOperations => new ChengeVariableOperations[]
        {
            ChengeVariableOperations.None,
            ChengeVariableOperations.Set
        };

        public void Execute(Variable variable, Variable referenceValue){

        }
    }
}