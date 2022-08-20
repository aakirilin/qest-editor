using System;
using System.Text.Json.Serialization;

namespace editor.Models.Actions
{
    public class AddJournalRecord : IAction
    {
        public Guid JournalRecordId {get; set;}
        [JsonIgnore]
        public string Name => "Добавить запись в журнал";

        public string Text { get; set;}

        public string Description()
        {
            return Name;
        }

        public void Execute(QuestGame game)
        {
            game.AddJournalRecord(this);
        }
    }
}