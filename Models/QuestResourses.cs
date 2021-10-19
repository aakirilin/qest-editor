using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text;
using System;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.Linq;
using editor.Models.Conditions;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.IO;
using System.ComponentModel;

namespace editor.Models
{
    public static class JsonSerializerHelper
    {
        public static JsonSerializerOptions JsonSerializerOptions
        {
            get
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                options.Converters.Add(new IInterfaceConverter());

                return options;
            }
        }

    }

    public class QuestResourses
    {
        public List<Variable> Variables { get; set; }
        public List<Dialog> Dialogs { get; set; }
        public List<Image> Images { get; set; }
        public List<JournalRecord> JournalRecords { get; set; }

        
        public QuestResourses()
        {
            Initialize();
        }

        public void Initialize(){
            Variables = new List<Variable>();
            Dialogs = new List<Dialog>();
            Images = new List<Image>();
            JournalRecords = new List<JournalRecord>();
        }
        
        public static QuestResourses FromFile(string json)
        {
            return JsonSerializer.Deserialize<QuestResourses>(json, JsonSerializerHelper.JsonSerializerOptions);
        }

        public string Serialize()
        {
            return  JsonSerializer.Serialize(this, JsonSerializerHelper.JsonSerializerOptions);
        }

        

        public void CopyFrom(QuestResourses sourse){
            Variables = sourse.Variables;
            Dialogs = sourse.Dialogs;
            Images = sourse.Images;
        }
    }

    public class VariableProgress
    {

    }

    public class DialogProgress
    {
        public Guid DialogId {get; set;}
        public Guid CurrentReplica{get; set;}

        public DialogProgress(Guid id)
        {
            DialogId = id;
        }
    }

    public class JournalProgress
    {
        public Guid Id {get; set;}
        public List<JournalRecordProgress> Records {get; set;}

        public JournalProgress(Guid id)
        {
            Id = id;
            Records = new List<JournalRecordProgress>();
        }
    }

    public class JournalRecordProgress
    {
        public Guid DialogId {get; set;}
        public Guid ReplicaId {get; set;}
        public Guid AnswerId {get; set;}
    }

    public class QuestProgress
    {
        public List<VariableProgress> Variables { get; set; }
        public List<DialogProgress> Dialogs { get; set; }
        public List<JournalProgress> JournalRecords { get; set; }

        public QuestProgress()
        {
            Initialize();
        }

        public void Initialize(){
            Variables = new List<VariableProgress>();
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

    public class QuestGame
    {
        private readonly QuestResourses resourses;

        private readonly QuestProgress progress;

        public QuestGame(QuestResourses resourses, QuestProgress progress)
        {
            this.resourses = resourses;
            this.progress = progress;
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
            throw new Exception();
        }
    }
}