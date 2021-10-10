using System;
using System.Linq;
using editor.Models.Conditions;

namespace editor.Models.Actions
{
    public class SetDialogState : IAction, IDialogState
    {
        public Guid DialogId {get; set;}
        public Guid SelectReplicaId {get; set;}
        public string Name => "Изменение состояния диалога";

        public string Description()
        {
            return Name;
        }

        public void Execute(QuestResourses resourses)
        {
            var dialog = resourses?.Dialogs?.FirstOrDefault(d => d.Id == DialogId);
            if(dialog != null)
            {
                dialog.CurrentReplicaId = SelectReplicaId;
            }
        }
    }

    
}