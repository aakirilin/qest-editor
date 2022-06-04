using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text;
using System;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using editor.Models.Conditions;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.IO;
using System.ComponentModel;
using System.IO.Compression;
using System.Diagnostics.CodeAnalysis;

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

        private const string variablesJsonFileName = "Variables.json";
        private const string dialogsJsonFileName = "Dialogs.json";
        private const string journalRecordsJsonFileName = "JournalRecords.json";
        private const string imagePrifix = "image-";
        public string SaveZip()
        {
            var variablesJson = JsonSerializer.Serialize(Variables, JsonSerializerHelper.JsonSerializerOptions);
            var dialogsJson = JsonSerializer.Serialize(Dialogs, JsonSerializerHelper.JsonSerializerOptions);
            var journalRecordsJson = JsonSerializer.Serialize(JournalRecords, JsonSerializerHelper.JsonSerializerOptions);

            var files = new Dictionary<string, string>();
            files.Add(variablesJsonFileName, variablesJson);
            files.Add(dialogsJsonFileName, dialogsJson);
            files.Add(journalRecordsJsonFileName, journalRecordsJson);
            foreach (var image in Images)
            {
                var imageJson = JsonSerializer.Serialize(image, JsonSerializerHelper.JsonSerializerOptions);
                files.Add($"{imagePrifix}{image.Id}.json", imageJson);
            }

            byte[] result = new byte[0];
            using (var targetStream = new MemoryStream())
            using (var archive = new ZipArchive(targetStream, ZipArchiveMode.Create, true))
            {
                foreach (var item in files)
                {
                    ZipArchiveEntry entry = archive.CreateEntry(item.Key);
                    using (StreamWriter writer = new StreamWriter(entry.Open()))
                    {
                        writer.WriteLine(item.Value);
                    }
                }

                result = targetStream.ToArray();
            }

            return Convert.ToBase64String(result);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, JsonSerializerHelper.JsonSerializerOptions);
        }

        public static QuestResourses ReadZip(string base64Data)
        {
            var result = new QuestResourses();
            var data = Convert.FromBase64String(base64Data);
            using (var buffer = new MemoryStream(data))
            using (var archive = new ZipArchive(buffer, ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
                {
                    using (var reader = new StreamReader(entry.Open()))
                    {
                        var entryData = reader.ReadToEnd();
                        if (entry.Name.StartsWith(imagePrifix))
                        {
                            var image = Deserialize<Image>(entryData);
                            result.Images.Add(image);
                        }
                        if (entry.Name.Equals(variablesJsonFileName))
                        {
                            var variables = Deserialize<List<Variable>>(entryData);
                            result.Variables = variables;
                        }
                        if (entry.Name.Equals(dialogsJsonFileName))
                        {
                            var dialogs = Deserialize<List<Dialog>>(entryData);
                            result.Dialogs = dialogs;
                        }
                        if (entry.Name.Equals(journalRecordsJsonFileName))
                        {
                            var journalRecords = Deserialize<List<JournalRecord>>(entryData);
                            result.JournalRecords = journalRecords;
                        }
                    }
                }
            }

            return result;
        }

        public void CopyFrom(QuestResourses sourse){
            Variables = sourse.Variables;
            Dialogs = sourse.Dialogs;
            Images = sourse.Images;
        }

        internal void CloseDialog()
        {
            throw new NotImplementedException();
        }

        internal void SetDialogState(Dialog dialog, Guid selectReplicaId)
        {
            throw new NotImplementedException();
        }
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


    public class VariablesIdComparer : IEqualityComparer<Variable>
    {
        public bool Equals(Variable x, Variable y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Variable obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}