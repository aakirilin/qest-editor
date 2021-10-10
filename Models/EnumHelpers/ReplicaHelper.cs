using System;
using System.Collections.Generic;
using System.Linq;
using editor.Models.Conditions;

namespace editor.Models.EnumHelpers
{
    public class ReplicaHelper : ISelectHelper
    {

        private readonly IEnumerable<Replica> replics;
        private readonly IDialogState  dialogState;
        public ReplicaHelper(DialogHelper dialogHelper, IDialogState dialogState)
        {
            this.dialogState = dialogState;
            this.replics = dialogHelper.Dialog?.Replics ?? new List<Replica>();
        }

        public string Value
        {
            get => dialogState.SelectReplicaId.ToString();
            set 
            {
                Guid id;
                if(Guid.TryParse(value, out id)){
                    dialogState.SelectReplicaId = id;
                }
                else{
                    dialogState.SelectReplicaId = Guid.Empty;
                }
                
            }
        }

        public IEnumerable<SelectorOption> Options()
        {
            return replics.Select(d => new SelectorOption(d.Text, d.Id.ToString()));
        }
    }
}
