using System.Text.Json.Serialization;

namespace editor.Models.Actions
{
    public interface IChengeVariableAction
    {
        ChengeVariableOperations Operation {get; set;}

        [JsonIgnore]
        ChengeVariableOperations[] AvailableOperations {get;}

        void Execute(Variable variable, Variable referenceValue);
    }
}
