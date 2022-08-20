using System;
using System.Collections.Generic;
using System.Linq;
using editor.Models.Conditions;

namespace editor.Models.EnumHelpers
{
    public class DialogHelper : ISelectHelper
    {
        private readonly IEnumerable<Dialog> dialogs;
        private readonly IDialogState dialogState;
        public Dialog Dialog => dialogs.FirstOrDefault(d => d.Id == dialogState.DialogId);

        public DialogHelper(IEnumerable<Dialog> dialogs, IDialogState dialogState)
        {
            this.dialogState = dialogState;
            this.dialogs = dialogs;
        }

        public string Value
        {
            get => dialogState.DialogId.ToString();
            set 
            {
                Guid id;
                if(Guid.TryParse(value, out id)){
                    dialogState.DialogId = id;
                }
                else{
                    dialogState.DialogId = Guid.Empty;
                }
                
            }
        }

        public IEnumerable<SelectorOption> Options()
        {
            return dialogs.Select(d => new SelectorOption(d.Title, d.Id.ToString()));
        }
    }
}
