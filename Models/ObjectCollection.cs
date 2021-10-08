using System;
using System.Collections;
using System.Collections.Generic;

namespace editor.Models
{
    public abstract class ObjectCollection<T> : IEnumerable<T> where T : class, IObgect, new()
    {
        protected readonly QuestResourses resourses;
        protected List<T> sourse => selector();

        public ObjectCollection(QuestResourses resourses)
        {
            this.resourses = resourses;
        }

        protected abstract List<T> selector();

        public IEnumerator<T> GetEnumerator()
        {
            return sourse.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return sourse.GetEnumerator();
        }

        public virtual T New(bool addInCollection = false)
        {
            var result = new T();
            result.Id = Guid.NewGuid();

            if (addInCollection)
            {
                sourse.Add(result);
            }

            return result;
        }

        public void Add(T item)
        {
            sourse.Add(item);
        }

        public void Remove(T item)
        {
            sourse.Remove(item);
        }
    }
}