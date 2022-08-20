using System.Collections.Generic;
using System;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace editor.Models
{
    public class QuestProgress
    {
        public Guid CurentDialogId { get; set; }
        public List<Variable> Variables { get; set; }
        public List<DialogProgress> Dialogs { get; set; }
        public List<JournalProgress> JournalRecords { get; set; }

        public QuestProgress()
        {
            Initialize();
        }

        public void Initialize(){
            Variables = new List<Variable>();
            Dialogs = new List<DialogProgress>();
            JournalRecords = new List<JournalProgress>();
        }

        public static QuestProgress FromFile(string json)
        {
            return JsonSerializer.Deserialize<QuestProgress>(json, JsonSerializerHelper.JsonSerializerOptions);
        }

        public string Serialize()
        {
            return  JsonSerializer.Serialize(this, JsonSerializerHelper.JsonSerializerOptions);
        }
    }
}