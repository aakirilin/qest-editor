using System.Text.Json.Serialization;

namespace editor.Models.Actions
{

    public class CloseDialog : IAction
    {
        [JsonIgnore]
        public string Name => "Закрыть диалог";

        public string Description()
        {
            return Name;
        }

        public void Execute(QuestGame game)
        {
            game.CloseDialog();
        }
    }
}