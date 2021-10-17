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
}