using System.Collections.Generic;
using System.Text.Json;

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

        public string Serialize(){
            return JsonSerializer.Serialize(this);
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