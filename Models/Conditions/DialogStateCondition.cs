using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace editor.Models.Conditions
{
    public class DialogStateCondition : ICondition, IDialogState
    {
        [JsonIgnore]
        public ConditionChaildCount ChaildCount => ConditionChaildCount.None;
        public IEnumerable<ICondition> LinkConditions()
        {
            return null;
        }
        public void AddLinkCondition(ICondition condition)
        {
        }
        public void RemoveLinkCondition(ICondition condition)
        {
        }

        public string Description()
        {
            return $"Проверяет что диалог в указанном состоянии";
        } 

        [JsonIgnore]
        public string Name => "Состояние диалога";
        public Guid DialogId { get; set; }
        public Guid SelectReplicaId { get; set; }

        public bool Result(QuestResourses resourses)
        {
            var dialog = resourses.Dialogs?.FirstOrDefault(d => d.Id == DialogId);
            if (dialog == null) return false;
            return dialog.CurrentReplicaId == SelectReplicaId;
        }
    }
}