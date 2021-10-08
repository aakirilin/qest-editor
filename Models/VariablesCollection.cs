using System.Collections.Generic;

namespace editor.Models
{
    public class VariablesCollection : ObjectCollection<Variable>
    {
        public VariablesCollection(QuestResourses resourses) : base(resourses)
        {
        }

        protected override List<Variable> selector()
        {
            return resourses.Variables;
        }
    }
}