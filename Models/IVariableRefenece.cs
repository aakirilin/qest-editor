using System;

namespace editor.Models
{
    public interface IVariableRefenece
    {
        Guid VariableId { get; set; }
        Variable ReferenceValue { get; set; }
    }
}