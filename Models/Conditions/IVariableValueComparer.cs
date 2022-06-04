using System.Text.Json.Serialization;

namespace editor.Models.Conditions
{
    public interface IVariableValueComparer
    {
        [JsonIgnore]
        ComparisonsOperators[] UseOperators { get; }
        ComparisonsOperators Operator { get; set; }
    }
}