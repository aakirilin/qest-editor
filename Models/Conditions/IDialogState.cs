using System;

namespace editor.Models.Conditions
{
    public interface IDialogState
    {
        Guid DialogId { get; set; }
        Guid SelectReplicaId { get; set; }
    }
}