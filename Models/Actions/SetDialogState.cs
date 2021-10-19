using System;
using System.Linq;
using System.Text.Json.Serialization;
using editor.Models.Conditions;

namespace editor.Models.Actions
{
    public class SetDialogState : IAction, IDialogState
    {
        public Guid DialogId {get; set;}
        public Guid SelectReplicaId {get; set;}

        [JsonIgnore]
        public string Name => "Изменение состояния диалога";

        public string Description()
        {
            return Name;
        }

        public void Execute(QuestResourses resourses, Dialog currentDialog, Replica currentReplica, Answer currentAnswer)
        {
            var dialog = resourses?.Dialogs?.FirstOrDefault(d => d.Id == DialogId);
            if(dialog != null)
            {
                
            }
        }
    }

    public class AddJournalRecord : IAction
    {
        public Guid JournalRecordId {get; set;}
        [JsonIgnore]
        public string Name => "Добавить запись в журнал";

        public string Description()
        {
            return Name;
        }

        public void Execute(QuestResourses resourses, Dialog currentDialog, Replica currentReplica, Answer currentAnswer)
        {
            throw new Exception();
        }
    }
}