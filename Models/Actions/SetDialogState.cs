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

        public void Execute(QuestGame game)
        {
            var dialog = game?.Dialogs?.FirstOrDefault(d => d.Id == DialogId);
            if(dialog != null)
            {
                game.SetDialogState(dialog, SelectReplicaId);
            }
        }
    }
}