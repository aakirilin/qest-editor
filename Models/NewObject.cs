using System.Collections.Generic;
using System.Linq;

namespace editor.Models
{
    public abstract class NewObject<T> where T : class, IObgect, new()
    {
        protected readonly QuestResourses resourses;
        private readonly T instanse;
        protected Language localLanguage;

        public NewObject(QuestResourses resourses, T instanse)
        {
            localLanguage = new Language();
            this.resourses = resourses;
            this.instanse = instanse;
        }

        public virtual void OnInsert()
        {

        }

        public void Insert()
        {
            resourses.SelectLanguage.Strings.AddRange(localLanguage.Strings);

            var instanceType = instanse.GetType();
            var collectionProperty = resourses.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType)
                .First(p => p.PropertyType.GetGenericArguments()[0] == instanceType);

            var collection = (List<T>)collectionProperty.GetValue(resourses);
            collection.Add(instanse);
            OnInsert();
        }
    }
}