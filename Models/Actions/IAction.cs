using System.Collections.Generic;
using System.Reflection;
using editor.Models;

namespace editor.Models.Actions
{
    public interface IAction
    {
        string Name {get;}
        string Description();
        void Execute(QuestResourses resourses);
    }

    public class CloseDialog : IAction
    {
        public string Name => "Закрыть диалог";

        public string Description()
        {
            return Name;
        }

        public void Execute(QuestResourses resourses)
        {
            throw new System.NotImplementedException();
        }
    }
}