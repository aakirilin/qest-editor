namespace editor.Models.Conditions
{
    public interface IVariableValueComparer
    {
        ComparisonsOperators[] UseOperators { get; }
        ComparisonsOperators Operator { get; set; }
    }
}