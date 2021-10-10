namespace editor.Models.Actions
{
    public interface IChengeVariableAction
    {
        ChengeVariableOperations Operation {get; set;}
        ChengeVariableOperations[] AvailableOperations {get;}

        void Execute(Variable variable, Variable referenceValue);
    }
}
