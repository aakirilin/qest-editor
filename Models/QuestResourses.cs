using System.Collections.Generic;

namespace editor.Models
{
    public class QuestResourses
    {
        public List<Variable> Variables { get; set; }
        public List<Language> Languages { get; set; }
        public List<Dialog> Dialogs { get; set; }
        public Language SelectLanguage { get; set; }

        public QuestResourses()
        {
            Variables = new List<Variable>();
            Languages = new List<Language>();
            Dialogs = new List<Dialog>();
        }
    }
}