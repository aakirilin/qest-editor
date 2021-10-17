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

namespace editor.Models
{
    public class QuestResourses
    {
        public List<Variable> Variables { get; set; }
        public List<Dialog> Dialogs { get; set; }
        public List<Image> Images { get; set; }

        public QuestResourses()
        {
            Initialize();
        }

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

        public static QuestResourses FromFile(string json)
        {
            return JsonSerializer.Deserialize<QuestResourses>(json, JsonSerializerOptions);
        }

        public string Serialize()
        {
            return  JsonSerializer.Serialize(this, JsonSerializerOptions);
        }

        public void Initialize(){
            Variables = new List<Variable>();
            Dialogs = new List<Dialog>();
            Images = new List<Image>();
        }

        public void CopyFrom(QuestResourses sourse){
            Variables = sourse.Variables;
            Dialogs = sourse.Dialogs;
            Images = sourse.Images;
        }
    }

    
}