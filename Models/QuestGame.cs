using System.Collections.Generic;
using System;
using System.Linq;
using editor.Models.Actions;

namespace editor.Models
{
    public class QuestGame
    {
        public Guid CurentDialogId => progress.CurentDialogId;
        public Replica CurentReplica { get; set; }
        public Dialog curentDialog;
        public Dialog CurentDialog
        {
            set => curentDialog = value;
            get => curentDialog ?? GetDialog(CurentDialogId);
        }

        public IEnumerable<Dialog> Dialogs => resourses.Dialogs;

        private readonly QuestResourses resourses;

        private readonly QuestProgress progress;

        public QuestGame(QuestResourses resourses, QuestProgress progress)
        {
            this.resourses = resourses;
            this.progress = progress;

            progress.CurentDialogId = StartDialog().Id;
            CloseDialog();
        }

        public Dialog GetDialog(Guid id)
        {
            return resourses.Dialogs.First(d => d.Id == id);
        }

        public Replica GetReplica(Guid dialogId, Guid replicaId)
        {
            return GetDialog(dialogId).Replics.First(r => r.Id == replicaId);
        }

        public Replica FindCurrentReplica(Guid dialogId)
        {
            var progressDialog = progress.Dialogs.FirstOrDefault(d => d.DialogId == dialogId);

            if(progressDialog != null)
                return GetReplica(dialogId, progressDialog.CurrentReplica);

            var dialog = GetDialog(dialogId);
            //var 
            return dialog.Replics.FirstOrDefault(r => r.Id == dialog.StartingReplicaId);
        }


        public Dialog StartDialog()
        {
            return resourses.Dialogs.FirstOrDefault(d => d.Type == DialogTypes.start);
        }

        internal void AddJournalRecord(AddJournalRecord addJournalRecord)
        {
            var journalProgress = progress.JournalRecords
                .FirstOrDefault(r => r.Id == addJournalRecord.JournalRecordId);
            if (journalProgress == null)
            {
                journalProgress = new JournalProgress(addJournalRecord.JournalRecordId);
                progress.JournalRecords.Add(journalProgress);
            }
            journalProgress.Records.Add(addJournalRecord.Text);
        }

        public Replica MenuReplica()
        {
            var dialog = StartDialog();
            return FindCurrentReplica(dialog.Id);
        }

        internal void CloseDialog()
        {
            CurentReplica = MenuReplica();
        }

        internal void SetDialogState(Dialog dialog, Guid selectReplicaId)
        {            
            var dialogProgress = progress.Dialogs.FirstOrDefault(p => p.DialogId == dialog.Id);
            if(dialogProgress == null)
            {
                dialogProgress = new DialogProgress(dialog.Id);
                progress.Dialogs.Add(dialogProgress);
            }
            dialogProgress.CurrentReplica = selectReplicaId;
            OpenDialog(CurentDialogId);
        }

        internal void OpenDialog(Guid dialogId)
        {
            progress.CurentDialogId = dialogId;
            CurentDialog = GetDialog(dialogId);
            CurentReplica = FindCurrentReplica(dialogId);
        }

        internal void NextReplica(Dialog dialog, Guid selectReplicaId)
        {
            var replica = dialog.Replics.First(r => r.Id == selectReplicaId);
            CurentReplica = replica;
        }

        internal Variable GetVariable(Guid variableId)
        {
            var progressVariable = progress.Variables.FirstOrDefault(p => p.Id == variableId); 
            if(progressVariable == null)
            {
                var variable = resourses.Variables.FirstOrDefault(p => p.Id == variableId);
                progress.Variables.Add(variable);
            }
            return progressVariable;
        }
    }
}