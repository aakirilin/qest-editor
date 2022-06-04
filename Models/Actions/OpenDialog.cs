using editor.Models.Conditions;
using System;
using System.Text.Json.Serialization;

namespace editor.Models.Actions
{
    public class OpenDialog : IAction, IDialogState
    {
        public Guid DialogId { get; set; }
        public Guid SelectReplicaId { get; set; }

        [JsonIgnore]
        public string Name => "Открыть диалог";

        public string Description()
        {
            return Name;
        }

        public void Execute(QuestGame game)
        {
            game.OpenDialog(DialogId);
        }
    }
}