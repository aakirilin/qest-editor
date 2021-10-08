using System.Collections.Generic;

namespace editor.Models
{
    public class LanguageCollection : ObjectCollection<Language>
    {
        public LanguageCollection(QuestResourses resourses) : base(resourses)
        {
        }

        protected override List<Language> selector()
        {
            return resourses.Languages;
        }
    }
}